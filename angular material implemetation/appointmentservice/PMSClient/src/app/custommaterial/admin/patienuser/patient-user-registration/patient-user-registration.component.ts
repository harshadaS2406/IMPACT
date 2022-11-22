import { Component, Inject, OnInit } from '@angular/core';
import { FloatLabelType } from '@angular/material/form-field';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PatientUser } from 'src/app/custommaterial/admin/hospuser/hospuser';
import { AdminService } from 'src/app/services/admin.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';


interface Role {
  RoleID: number;
  RoleName: string;
}

interface Gender {
  GenderID: number;
  GenderName: string;
}


@Component({
  selector: 'app-patient-user-registration',
  templateUrl: './patient-user-registration.component.html',
  styleUrls: ['./patient-user-registration.component.css']
})
export class PatientUserRegistrationComponent implements OnInit {

  titles: string[] = ['Mr', 'Mrs', 'Ms', 'Dr'];
  roles: Role[] =
    [
      { RoleID: 1, RoleName: 'Doctor' },
      { RoleID: 2, RoleName: 'Nurse' }
    ];

  genders: Gender[] =
    [
      { GenderID: 1, GenderName: 'Male' },
      { GenderID: 2, GenderName: 'Female' },
      { GenderID: 3, GenderName: 'Others' }
    ];
  hide = true;
  showpasswordfield:boolean=true;
  objPatientUser = new PatientUser();

  PatientUserForm !: FormGroup;
  value: string;
  dob1: any;

  constructor(
    private fb: FormBuilder,
    private adminserv:AdminService,
    @Inject(MAT_DIALOG_DATA) public editData:any,
    private dialogref:MatDialogRef<PatientUserRegistrationComponent>
    ) {

  }
  ngOnInit(): void
  {
    this.PatientUserForm = this.fb.group({
      title: ['', Validators.required],
      fname: ['', Validators.required],
      lname: ['', Validators.required],
      email: ['', Validators.required],
      dob: ['', Validators.required],
      gender: ['', Validators.required],
      contactno: ['', Validators.required],
      password: ['', Validators.required],
      confirmpassword:['',Validators.required]
    });



    if (this.editData.title != null) {
      this.dob1 = new Date(this.editData.dob);
      this.showpasswordfield=false;

      // console.log(dob1);
      this.PatientUserForm.controls['title'].setValue(this.editData.title);
      this.PatientUserForm.controls['fname'].setValue(this.editData.firstName);
      this.PatientUserForm.controls['lname'].setValue(this.editData.lastName);
      this.PatientUserForm.controls['email'].setValue(this.editData.email);
      this.PatientUserForm.controls['dob'].setValue(this.dob1);
      this.PatientUserForm.controls['gender'].setValue(this.editData.genderID);
      this.PatientUserForm.controls['empid'].setValue(this.editData.employeeID);
      this.PatientUserForm.controls['contactno'].setValue(this.editData.phoneNumber);
    }

  }
    AddUser() {
      console.log("hitting");
      this.objPatientUser.title = this.PatientUserForm.get('title').value;
      this.objPatientUser.FirstName = this.PatientUserForm.get('fname').value;
      this.objPatientUser.LastName = this.PatientUserForm.get('lname').value;
      this.objPatientUser.Email = this.PatientUserForm.get('email').value;
      this.objPatientUser.DOR = this.PatientUserForm.get('dob').value;
      this.objPatientUser.RoleId = this.PatientUserForm.get('role').value;
      this.objPatientUser.GenderID = this.PatientUserForm.get('gender').value;
      this.objPatientUser.empid = this.PatientUserForm.get('empid').value;
      this.objPatientUser.PhoneNumber = this.PatientUserForm.get('contactno').value;
      this.objPatientUser.Password = this.PatientUserForm.get('password').value;
      this.objPatientUser.ConfirmPassword = this.PatientUserForm.get('confirmpassword').value;
  
  
      console.log(this.objPatientUser);
  
      this.adminserv.addPUser(this.objPatientUser).subscribe((data) => {
        debugger;
        console.log(data);
      });
    }


    closeModal() {
      this.dialogref.close();
    }

  }


