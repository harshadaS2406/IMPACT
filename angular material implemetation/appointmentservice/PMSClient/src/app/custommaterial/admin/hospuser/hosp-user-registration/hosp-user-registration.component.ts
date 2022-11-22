import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { FloatLabelType } from '@angular/material/form-field';
import { MatDialog, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { HospitalUser } from '../hospuser';
import { AdminService } from 'src/app/services/admin.service';

interface Role {
  RoleID: number;
  RoleName: string;
}

interface Gender {
  GenderID: number;
  GenderName: string;
}


@Component({
  selector: 'app-hosp-user-registration',
  templateUrl: './hosp-user-registration.component.html',
  styleUrls: ['./hosp-user-registration.component.css']
})
export class HospUserRegistrationComponent implements OnInit {

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


  objHospitalUser = new HospitalUser();
  showpasswordfield:boolean=true;

  HospUserForm !: FormGroup;
  value: string;
  dob1: any;
  constructor(
    private fb: FormBuilder,
    private adminserv: AdminService,
    @Inject(MAT_DIALOG_DATA) public editData: any,
    private dialogref: MatDialogRef<HospUserRegistrationComponent>
  ) {

  }

  ngOnInit(): void {

    this.HospUserForm = this.fb.group({
      title: ['', Validators.required],
      fname: ['', Validators.required],
      lname: ['', Validators.required],
      email: ['', Validators.required],
      dob: ['', Validators.required],
      role: ['', Validators.required],
      gender: ['', Validators.required],
      empid: ['', Validators.required],
      contactno: ['', Validators.required],
      password: ['', Validators.required],
      confirmpassword: ['']
    });

    console.log(this.editData);

    if (this.editData.title != null) {
      this.dob1 = new Date(this.editData.dob);
      this.showpasswordfield=false;

      // console.log(dob1);
      this.HospUserForm.controls['title'].setValue(this.editData.title);
      this.HospUserForm.controls['fname'].setValue(this.editData.firstName);
      this.HospUserForm.controls['lname'].setValue(this.editData.lastName);
      this.HospUserForm.controls['email'].setValue(this.editData.email);
      this.HospUserForm.controls['dob'].setValue(this.dob1);
      this.HospUserForm.controls['role'].setValue(this.editData.roleId);
      this.HospUserForm.controls['gender'].setValue(this.editData.genderID);
      this.HospUserForm.controls['empid'].setValue(this.editData.employeeID);
      this.HospUserForm.controls['contactno'].setValue(this.editData.phoneNumber);
    }
  }

  AddUser() {
    console.log("hitting");
    this.objHospitalUser.title = this.HospUserForm.get('title').value;
    this.objHospitalUser.FirstName = this.HospUserForm.get('fname').value;
    this.objHospitalUser.LastName = this.HospUserForm.get('lname').value;
    this.objHospitalUser.Email = this.HospUserForm.get('email').value;
    this.objHospitalUser.DOB = this.HospUserForm.get('dob').value;
    this.objHospitalUser.RoleId = this.HospUserForm.get('role').value;
    this.objHospitalUser.GenderID = this.HospUserForm.get('gender').value;
    this.objHospitalUser.empid = this.HospUserForm.get('empid').value;
    this.objHospitalUser.PhoneNumber = this.HospUserForm.get('contactno').value;
    this.objHospitalUser.Password = this.HospUserForm.get('password').value;
    this.objHospitalUser.ConfirmPassword = this.HospUserForm.get('confirmpassword').value;


    console.log(this.objHospitalUser);

    this.adminserv.addHUser(this.objHospitalUser).subscribe((data) => {
      debugger;
      console.log(data);
    });}

    closeModal() {
      this.dialogref.close();
    }
    
}
