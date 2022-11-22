import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { UserModel } from 'src/app/models/User';
import { AppointmentService } from 'src/app/services/appointment.service';
import * as $ from 'jquery'
import { pipe } from 'rxjs';
import { Appointment } from 'src/app/models/Appointment';
@Component({
  selector: 'app-appointment-creation',
  templateUrl: './appointment-creation.component.html',
  styleUrls: ['./appointment-creation.component.css']
})
export class AppointmentCreationComponent implements OnInit {
  MeetingTitle="";
  Pname:"";
  PhName:"";
  Description:"";
  APTdate:Date;
  Patient :UserModel[];
  physician: UserModel[];
  PatientName:string;
  slots:any;
  meetingTitle:string;
  visitDate:any;
  phyId:any;
  UnavailableSlots = ["11/21/2022:11", "11/22/2020:0", "11/23/2020:17"]; //your dates from database with only hr
  AppointmentForm = this.fb.group({
    MeetingTitle: new FormControl("",[Validators.required]),
    Description: new FormControl(),
    Pname: new FormControl(),
    PhName: new FormControl(),
    APTdate : new FormControl(),
    slotTiming:new FormControl(),
  });
  
  
  data:any;
  AptData:any;
  appointment: Appointment;
  constructor(private Appointmentservice:AppointmentService,private fb: FormBuilder) { 


  
  }

  ngOnInit(): void {
    this.getPatient();
    this.getPysician();
    this.getApt();

    

    
    
    
  }

  PostAppointmentData()
  {
    if(this.AppointmentForm.valid){
      console.log(this.AppointmentForm);
      this.appointment= new Appointment();
      this.appointment.doctorId=Number(this.AppointmentForm.get('PhName')?.value);
      this.appointment.patientId=Number(this.AppointmentForm.get('Pname')?.value);
      this.appointment.visitDate=this.AppointmentForm.get('APTdate')?.value;
      this.appointment.visitTitle=this.AppointmentForm.get('MeetingTitle')?.value;
      this.appointment.visitDescription=this.AppointmentForm.get('Description')?.value;
      this.appointment.slotId=Number(this.AppointmentForm.get('slotTiming')?.value);
      console.log(this.appointment);
      this.Appointmentservice.postAppointmentDetails(this.appointment).subscribe(res=>{
        
        alert(res);
      })
    }
    
    else{
      alert("Please fill all details");
    }
  }

  getPatient()
  {
    this.Appointmentservice.getUsers().subscribe(res =>{
    
      this.Patient = res;
      
      console.log(this.Patient);
      
    })
  }


  getApt()
  {
    this.Appointmentservice.getAppointments().subscribe(res =>{
      
      this.AptData = res;
      
      console.log(this.AptData);
      this.AptData.forEach(e => {
        console.log(e);
        console.log(e.visitDate);
        this.visitDate = e.visitDate;
        this.phyId = e.doctorId;


      });
    })
  }
  getPysician()
  {
    this.Appointmentservice.getPysician().subscribe(res =>{
      
      this.physician = res;
      
      console.log(this.physician);
    })
  }



formatDate(datestr)
{
    // var date = new Date(datestr);
    // var day = (date.getDate());
    // day = (day>9?day:"0"+day);
    // var month = date.getMonth()+1; 
    // month = month>9?month:"0"+month;
    // return month+"/"+day+"/"+date.getFullYear();
}
getAvailableSlots(date:any,id:number)
{
  //this.getApt();
  this.Appointmentservice.getSlots(date,id).subscribe(res =>{
    this.slots=res;
    console.log(this.slots);
  })
}


OnDateTimeChange(event:any)
{
   let pId = this.AppointmentForm.get("PhName")?.value;
   this.getAvailableSlots(event,pId);
   console.log(event);
   console.log(pId);

}



}
