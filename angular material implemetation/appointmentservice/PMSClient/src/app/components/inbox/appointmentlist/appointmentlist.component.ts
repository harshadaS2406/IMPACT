import { Component, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';
import { ResponseModel } from 'src/app/models/responseModel';
import { updateappointment } from 'src/app/models/updateappointment';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-appointmentlist',
  templateUrl: './appointmentlist.component.html',
  styleUrls: ['./appointmentlist.component.css']
})
export class AppointmentlistComponent implements OnInit {

  dataTableValues: any;
  appointmentId = 0;

  totalLength: any;
  page: number = 1;

  loggedRoleId: number;
  loggedUserId: number;

  confirmBtnVisible: boolean = true;
  completedBtVisible: boolean = true;
  noShowBtnVisible: boolean = true;

  constructor(private _service: NotesService, private _toast: NgToastService) { }

  ngOnInit(): void {
    this.loggedUserId = Number(localStorage.getItem('userid'));
    this.loggedRoleId = Number(localStorage.getItem('roleid'));
    this.GettAppointmentsList();

    if (this.loggedRoleId == 3 || this.loggedRoleId == 4) {
      debugger;
      this.confirmBtnVisible = false
      this.completedBtVisible = false
      if (this.loggedRoleId == 4) {
        this.noShowBtnVisible = false
      }
    }
  }

  GettAppointmentsList() {
    this._service.getAllAppointments(this.loggedUserId, this.loggedRoleId).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        debugger;
        this.dataTableValues = response.dataSet;

        this.totalLength = response.dataSet.length;
        console.log(this.totalLength);

        //this.appointmentCount=this.response2.length;
        //console.log('appoint', this.response2.length);

      }
    });
  }

  updateAppointment(val: any) {
    this.appointmentId = val.visitId;
  }

  updateAppointmentStatus(statusId: any) {
    let updateAppointmentObj: updateappointment = new updateappointment();
    updateAppointmentObj.AppointmentId = this.appointmentId;
    updateAppointmentObj.UpdateType = statusId;
    updateAppointmentObj.UserId = this.loggedUserId;
    updateAppointmentObj.roleId = this.loggedRoleId;

    this._service.updateAppointmentStatus(updateAppointmentObj).subscribe((response: any) => {
      if (response.responseCode == 1) {
        this._toast.success({ detail: "Appointment Accepted", summary: "Successfully!", duration: 3000 });
        this.ngOnInit();
      }
      else {
        this._toast.error({ detail: "Failed to accept Appointment", summary: "Error!", duration: 3000 });
      }
    });



  }

}
