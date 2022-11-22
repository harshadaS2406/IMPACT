import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentCreationComponent } from './components/appointmemt/appointment-creation/appointment-creation.component';
import { AppointmentSchedulerComponent } from './components/appointmemt/appointment-scheduler/appointment-scheduler.component';
import { CalendarComponent } from './components/appointmemt/calendar/calendar.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { DashboardMainComponent } from './components/dashboardPages/dashboard-main/dashboard-main.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { AppointmentlistComponent } from './components/inbox/appointmentlist/appointmentlist.component';
//import { AppointmentlistComponent } from './components/inbox/appointmentlist/appointmentlist.component';
import { NotesComponent } from './components/inbox/notes/notes.component';
import { LoginComponent } from './components/login/login.component';
import { DemographicComponent } from './components/patientdetails/demographic/demographic.component';
import { EmergencyComponent } from './components/patientdetails/emergency/emergency.component';

const routes: Routes = [
  {path:'',component:LoginComponent},
  {path:'DashboardMain', component:DashboardMainComponent},
  {path:'ChangePassword',component:ChangePasswordComponent},
  {path:'ForgotPassword',component:ForgotPasswordComponent},
  {path:'Calender', component:CalendarComponent},
  {path:'Appointment-creation/:id', component:AppointmentCreationComponent},
  {path:'patientdetails', component:DemographicComponent},
  {path:'emergencycontact', component:EmergencyComponent},
  {path:'Appointment-creation', component:AppointmentCreationComponent},
  {path:'notes', component:NotesComponent},
  {path:'appointmentlist', component:AppointmentlistComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
