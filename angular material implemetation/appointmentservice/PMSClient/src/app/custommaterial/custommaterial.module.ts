import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatTabsModule} from '@angular/material/tabs';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { AdminheaderComponent } from './admin/adminheader/adminheader.component';
import { HospuserComponent } from './admin/hospuser/hospuser.component';
import { PatienuserComponent } from './admin/patienuser/patienuser.component';
import { AdminComponent } from './admin/admin/admin.component';
import {MatTableModule} from '@angular/material/table';
import {MatPaginatorModule} from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from "@angular/material/form-field";
import {MatDialogModule} from '@angular/material/dialog';
import { HospUserRegistrationComponent } from './admin/hospuser/hosp-user-registration/hosp-user-registration.component';
import {MatRadioModule} from '@angular/material/radio';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule,DateAdapter } from '@angular/material/core';
import {MatSelectModule} from '@angular/material/select';
import { DateFormat } from "./admin/classes/date-format";

import {MatSnackBarModule} from '@angular/material/snack-bar';
import { PatientUserRegistrationComponent } from './admin/patienuser/patient-user-registration/patient-user-registration.component';




@NgModule({
  declarations: [
    
    AdminheaderComponent,
    HospuserComponent,
    PatienuserComponent,
    AdminComponent,
    HospUserRegistrationComponent,
    PatientUserRegistrationComponent
  ],
  imports: [
    CommonModule,
    MatTabsModule,
    MatToolbarModule,
   MatIconModule,
   MatTableModule,
   MatFormFieldModule,
   MatPaginatorModule,
   MatInputModule,
   MatButtonModule,
   MatDialogModule,
   MatRadioModule,
   FormsModule,
   ReactiveFormsModule,
   MatDatepickerModule,
   MatNativeDateModule,
   MatInputModule,
   MatSelectModule,
   MatSnackBarModule
    ],  
  exports: [
  ]
})
export class CustommaterialModule {

  constructor(private dateAdapter: DateAdapter<Date>) {
    dateAdapter.setLocale("en-in"); // DD/MM/YYYY
  }
 }
