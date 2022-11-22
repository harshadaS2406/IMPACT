import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { CommentStatus } from '@syncfusion/ej2/pdfviewer';
import { LoginService } from 'src/app/login.service';
import { ForgotPassword, ResponsefromApi } from '../login/login';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {

  forgotpasswordform !: FormGroup;
  validationmsg:string;
  infomsg:string;
  regexpEmail = new RegExp('^[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}');
  objForgotPassword:ForgotPassword= new ForgotPassword();
  resp = new ResponsefromApi();



  constructor(private loginserv:LoginService) 
  { 
  }


  ngOnInit(): void {
    this.forgotpasswordform= new FormGroup({
      'Email':  new FormControl('', [Validators.pattern(this.regexpEmail)])
      
  });
  }

  submitEmail()
  {
    console.log("hit");
    
    this.objForgotPassword.EmailId=this.forgotpasswordform.get('Email').value;
    this.loginserv.forgotPassword(this.objForgotPassword).subscribe(res=>{
       this.resp = res as ResponsefromApi
      console.log("from fp: "+res);
      if(Object(this.resp)["responseCode"]==106)
      {
        this.infomsg="Reset Password link is sent to your Email Address";
      }
    });    


  }

}
