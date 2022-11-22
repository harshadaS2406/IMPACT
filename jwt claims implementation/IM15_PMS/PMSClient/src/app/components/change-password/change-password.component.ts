import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { LoginService } from 'src/app/login.service';
import { ChangePassword,ResponsefromApi } from '../login/login';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  

  changepasswordForm !:FormGroup;
  regexpattern:string='^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$'
  objChangePassword:ChangePassword= new ChangePassword();
  resp= new ResponsefromApi();
  infomsg:string;
  constructor(private loginserv:LoginService,private route:ActivatedRoute,private router:Router) 
  { 
  }


  ngOnInit(): void {
    this.changepasswordForm= new FormGroup({
      'currentpassword':  new FormControl('', [Validators.pattern(this.regexpattern)]),
      'newpassword': new FormControl('',[Validators.pattern(this.regexpattern)]),
      'confirmpassword': new FormControl('',Validators.pattern(this.regexpattern))
  })
      

//    console.log("cp "+this.objChangePassword.userid)
  }

  submitPassword()
  {

    this.objChangePassword.currentpassword=this.changepasswordForm.get('currentpassword').value;
    
    this.objChangePassword.newpassword=this.changepasswordForm.get('newpassword').value;
    
    this.objChangePassword.confirmpassword=this.changepasswordForm.get('newpassword').value;

//    this.objChangePassword.userid=this.route.snapshot.params['id'];



    this.loginserv.changePassword(this.objChangePassword).subscribe(res=>{
       
      this.resp = res as ResponsefromApi

    

      console.log("from changepassword : "+res);
      if(Object(this.resp)["responseCode"]==105)
      {
         this.infomsg="Password Changed Successfully";
         this.router.navigateByUrl('/DashboardMain');
        }
    });    


  }

}
