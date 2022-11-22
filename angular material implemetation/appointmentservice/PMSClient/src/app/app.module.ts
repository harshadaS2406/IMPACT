import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DashboardMainComponent } from './components/dashboardPages/dashboard-main/dashboard-main.component';
import { HeaderComponent } from './components/dashboardPages/header/header.component';
import { FooterComponent } from './components/dashboardPages/footer/footer.component';
import { SidebarComponent } from './components/dashboardPages/sidebar/sidebar.component';
import { ScheduleModule, RecurrenceEditorModule,DayService,WeekService,WorkWeekService,MonthService,MonthAgendaService } from '@syncfusion/ej2-angular-schedule';
import { DayPilotModule } from 'daypilot-pro-angular';
import { DataService } from './data.service';
import { SchedulerComponent } from './components/appointments-scheduler/scheduler/scheduler.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CalendarComponent } from './components/appointmemt/calendar/calendar.component';
import { AppointmentCreationComponent } from './components/appointmemt/appointment-creation/appointment-creation.component';
import { LoginComponent } from './components/login/login.component';
import { ChangePasswordComponent } from './components/change-password/change-password.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { NotesComponent } from './components/inbox/notes/notes.component';
import { SendnotesComponent } from  './components/inbox/sendnotes/sendnotes.component';
import { ViewnotesComponent } from './components/inbox/viewnotes/viewnotes.component';
import { ReceivednotesComponent } from './components/inbox/receivednotes/receivednotes.component';
import { AppointmentlistComponent } from './components/inbox/appointmentlist/appointmentlist.component';
import { EmergencyComponent } from './components/patientdetails/emergency/emergency.component';
import { DemographicComponent } from './components/patientdetails/demographic/demographic.component';
import { LoginService } from './login.service';
 import { NgToastModule } from 'ng-angular-popup';
  import {NgxPaginationModule} from 'ngx-pagination';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CustommaterialModule } from './custommaterial/custommaterial.module';
import { RegisterComponent } from './components/register/register.component';


@NgModule({
  declarations: [
    AppComponent,
    DashboardMainComponent,
    HeaderComponent,
    FooterComponent,
    SidebarComponent,
    SchedulerComponent,
    CalendarComponent,
    AppointmentCreationComponent,
    LoginComponent,
    ChangePasswordComponent,
    ForgotPasswordComponent,
    NotesComponent,
    SendnotesComponent,
    ViewnotesComponent,
    ReceivednotesComponent,
    AppointmentlistComponent,
    EmergencyComponent,
    DemographicComponent,
    RegisterComponent,
    
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    ScheduleModule,
    RecurrenceEditorModule,
    DayPilotModule,
    RouterModule,
    NgToastModule,
    NgxPaginationModule,
    BrowserAnimationsModule,
    CustommaterialModule
    
  ],
  providers: [DayService,WeekService,WorkWeekService,MonthService,MonthAgendaService,LoginService,DataService],
  bootstrap: [AppComponent]
})
export class AppModule { }
