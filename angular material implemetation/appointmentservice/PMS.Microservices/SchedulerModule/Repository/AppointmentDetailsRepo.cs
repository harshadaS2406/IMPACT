using Microsoft.EntityFrameworkCore;
using SchedulerModule.EfCoreSetUp;
using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.Repository
{

    public class AppointmentDetailsRepo : IAppointmentDetailsRepo
    {

        private readonly SchedulerModelDbContext _schedulerModelDbContext;
        public AppointmentDetailsRepo(SchedulerModelDbContext schedulerModelDbContext)
        {
            _schedulerModelDbContext = schedulerModelDbContext;
        }
        public async Task<int> AddAppointmentDetails(AppointmentDetails AppointmentModel)
        {
            if(_schedulerModelDbContext!=null)
            {
                Slots slottimes = await _schedulerModelDbContext.Slots.FirstOrDefaultAsync(x => x.SlotId == AppointmentModel.SlotId);
                if (slottimes != null)
                {
                    AppointmentModel.AppointmentStartdate = AppointmentModel.visitDate.Add(slottimes.SlotStart);
                    AppointmentModel.AppointmentEnddate = AppointmentModel.visitDate.Add(slottimes.SlotEnd);
                    AppointmentModel.visitStatusId = 1;
                }

                AppointmentModel.createdOn = DateTime.Now;
                await _schedulerModelDbContext.AddAsync(AppointmentModel);
                await _schedulerModelDbContext.SaveChangesAsync();
            }
            return 0;
            
        }

        public  async Task<AppointmentDetails> GetAppointmentDetailById(int id)
        {
            if(_schedulerModelDbContext!=null)
            {
                var AptDetailsToFetch =  _schedulerModelDbContext.appointmentDetails.Where(aptId => aptId.VisitId == id).OrderBy(datetime => datetime.createdOn).FirstOrDefaultAsync();
                if (AptDetailsToFetch != null)
                {
                    return await AptDetailsToFetch;
                }
                else
                {
                    return null;
                }
            

            }
            return null;
            

        }

        public async Task<List<AppointmentDetails>> GetAllAppointmentDetails()
        {
           if(_schedulerModelDbContext!=null)
            {
                return await _schedulerModelDbContext.appointmentDetails.ToListAsync();
            }
            return null;
        }

        public async Task<int> UpdateAppointmentDetails(int id, AppointmentDetails appointmentDetailsModel)
        {
            if (_schedulerModelDbContext != null)
            {
                //var AptDetailsToUpdate = await _schedulerModelDbContext.appointmentDetails.FirstOrDefaultAsync(aptId => aptId.VisitId == id);
                //if (AptDetailsToUpdate != null)
                //{
                //    AptDetailsToUpdate.visitDate = appointmentDetailsModel.visitDate;
                //    AptDetailsToUpdate.VisitTitle = appointmentDetailsModel.VisitTitle;
                //    AptDetailsToUpdate.updatedOn = DateTime.Now;
                //    AptDetailsToUpdate.VisitDescription = appointmentDetailsModel.VisitDescription;
                //    //AptDetailsToUpdate.visitStatusId = appointmentDetailsModel.visitStatusId;
                //    //AptDetailsToUpdate.visitTime = appointmentDetailsModel.visitTime;
                //    AptDetailsToUpdate.createdBy = appointmentDetailsModel.createdBy;
                //    AptDetailsToUpdate.updatedBy = appointmentDetailsModel.updatedBy;
                //    _schedulerModelDbContext.appointmentDetails.Update(AptDetailsToUpdate);
                //    await _schedulerModelDbContext.SaveChangesAsync();
                //}

                var result = await _schedulerModelDbContext.appointmentDetails.FirstOrDefaultAsync(x => x.VisitId == id);

                if (result != null)
                {
                    Slots slottimes = await _schedulerModelDbContext.Slots.FirstOrDefaultAsync(x => x.SlotId == appointmentDetailsModel.SlotId);
                    if (slottimes != null)
                    {
                        result.visitDate = appointmentDetailsModel.visitDate;
                        result.VisitTitle = appointmentDetailsModel.VisitTitle;
                        result.VisitDescription = appointmentDetailsModel.VisitDescription;
                        result.AppointmentStartdate = appointmentDetailsModel.visitDate.Add(slottimes.SlotStart);
                        result.AppointmentEnddate = appointmentDetailsModel.visitDate.Add(slottimes.SlotEnd);

                        result.SlotId = appointmentDetailsModel.SlotId;
                    }
                    if (appointmentDetailsModel.visitStatusId != 0)
                    {
                        result.visitStatusId = appointmentDetailsModel.visitStatusId;
                    }

                    _schedulerModelDbContext.appointmentDetails.Update(result);
                    return await _schedulerModelDbContext.SaveChangesAsync();
                }


            }

            return appointmentDetailsModel.VisitId;
        }

        public void DeleteAppointmentDetails(AppointmentDetails appointment)
        {
            _schedulerModelDbContext.appointmentDetails.Remove(appointment);
            _schedulerModelDbContext.SaveChanges();
            
        }

        public async Task<List<AppointmentDetails>> GetAppointmentsByUser(int userId)
        {
            if (_schedulerModelDbContext != null)
                return await _schedulerModelDbContext.appointmentDetails.Where(x => x.patientId == userId || x.doctorId == userId).ToListAsync();
            else
                return null;
        }

        public async Task<List<ViewAppointmentModels>> GetAppointmentsLoad(int id, int roleId)
        {
            if (_schedulerModelDbContext != null)
            {
                List<AppointmentDetails> appointments = new List<AppointmentDetails>();
                List<ViewAppointmentModels> viewAppointments = new List<ViewAppointmentModels>();
                if (roleId == 3)
                {
                    appointments = await _schedulerModelDbContext.appointmentDetails.ToListAsync();
                }
                else
                {
                    appointments = await _schedulerModelDbContext.appointmentDetails.Where(x => x.doctorId == id || x.patientId == id).ToListAsync();
                }
                foreach (var item in appointments)
                {
                    ViewAppointmentModels model = new ViewAppointmentModels();
                    model.Id = item.VisitId;
                    model.Start = (DateTime)item.AppointmentStartdate;
                    model.End = (DateTime)item.AppointmentEnddate;
                    model.Text = item.VisitTitle;
                    if (item.visitStatusId ==2 )
                    {
                        model.BackColor = "#db403b";
                    }
                    else if (item.visitStatusId == 3)
                    {
                        model.BackColor = "#ADD8E6";
                    }
                    else
                    {
                        model.BackColor = "##bf00ff";
                    }
                    viewAppointments.Add(model);
                }
                return viewAppointments;
            }
            else
                return null;
        }


        public async Task<int> AcceptAppointment(int id)
        {
            if (_schedulerModelDbContext != null)
            {
                var result = await _schedulerModelDbContext.appointmentDetails.FirstOrDefaultAsync(x => x.VisitId == id);

                if (result != null)
                {

                      result.visitStatusId = 3;
                    //_schedulerModelDbContext.Entry(result).State = EntityState.Modified;  
                    _schedulerModelDbContext.appointmentDetails.Update(result);
                    await _schedulerModelDbContext.SaveChangesAsync();
                }


            }
            return 0;
        }

        public async Task<int> DeclineAppointment(int id)
        {
            if (_schedulerModelDbContext != null)
            {
                var result = await _schedulerModelDbContext.appointmentDetails.FirstOrDefaultAsync(x => x.VisitId == id);

                if (result != null)
                {
                    result.visitStatusId = 2;

                    _schedulerModelDbContext.appointmentDetails.Update(result);
                    return await _schedulerModelDbContext.SaveChangesAsync();
                }


            }
            return 0;
        }



        public bool IsAppointmentAvailable(int visitId)
        {
            return _schedulerModelDbContext.appointmentDetails.Any(e => e.VisitId == visitId);
        }

        public async Task<AppointmentDetails> GetAppointmentDetailByIdAndRoleId(int id, int roleId)
        {
            if(_schedulerModelDbContext!=null)
            {
                var appointmentDetails = await _schedulerModelDbContext.appointmentDetails.Where(i => i.VisitId == id && i.users.RoleID == roleId).FirstOrDefaultAsync();
                if(appointmentDetails!=null)
                {
                    return appointmentDetails;
                }
                return null;
            }
            return null;
        }
        public async Task<List<Slots>> GetSlots(DateTime date, int id)
        {
            if (_schedulerModelDbContext != null)
            {
                List<AppointmentDetails> slots = await _schedulerModelDbContext.appointmentDetails.Where(x => x.visitDate == date && x.doctorId == id).ToListAsync();
                List<Slots> availableSlots = new List<Slots>();
                if (slots != null)
                {
                    var slotsIds = slots.Select(x => x.SlotId).ToList();
                    availableSlots = await _schedulerModelDbContext.Slots.Where(x => !slotsIds.Contains(x.SlotId)).ToListAsync();
                }
                else
                {
                    availableSlots = await _schedulerModelDbContext.Slots.ToListAsync();
                }
                return availableSlots;
            }
            return null;


        }


        //public async Task<List<AppointmentDetails>> GetAppointmentDatesByPhysician(DateTime dateTime, int id)
        //{
        //    if(_schedulerModelDbContext!=null)
        //    {
        //        List<AppointmentDetails> AvailableSlots = await _schedulerModelDbContext.appointmentDetails.Where(i => i.visitTime == dateTime && i.doctorId == id).ToListAsync();

        //        if(AvailableSlots != null)
        //        {
        //            return AvailableSlots;
        //        }
        //        return null;

        //    }
        //    return null;
        //}


    }
}
