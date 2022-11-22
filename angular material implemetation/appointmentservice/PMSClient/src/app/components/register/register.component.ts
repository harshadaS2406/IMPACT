import { Component, OnInit } from '@angular/core';
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
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {


  
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


  constructor(
    private fb: FormBuilder,
    private adminserv:AdminService) { }

  ngOnInit(): void {

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

}
