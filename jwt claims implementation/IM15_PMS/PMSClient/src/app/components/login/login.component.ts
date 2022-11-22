import { Component, OnInit } from '@angular/core';
import {loginrequest, loginResponse, ResponsefromApi} from './login'
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { LoginService } from 'src/app/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers:[loginrequest,loginResponse]
})
export class LoginComponent implements OnInit {

  regexpPassword = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$');
  regexpEmail = new RegExp('^[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,6}');

  loginForm !:FormGroup;
  objlogin = new loginrequest();
  objloginresposne = new loginResponse();
  resp = new ResponsefromApi();
  accessfailedcount:any;
  loginattemptsremaining:any;
  invalidcredentailsmsg: string;
  constructor(private loginserv:LoginService,private router:Router) 
  { 

    console.log("Testing regex "+this.regexpPassword.test('It$TheYear2022'));
  }

  ngOnInit(): void {
    this.loginForm= new FormGroup({
        'username':  new FormControl('', [Validators.pattern(this.regexpEmail)]),
        'password': new FormControl('', [Validators.pattern(this.regexpPassword)])
    })
  }

  submitLogin()
  {
    this.objlogin.Email=this.loginForm.get('username').value;
    
    this.objlogin.Password=this.loginForm.get('password').value;

    this.loginserv.objloginreq=this.objlogin;
    
    this.loginserv.loginUser(this.objlogin).subscribe((res)=>
    {
      console.log(res);
      this.resp= res as ResponsefromApi;
      console.log(Object( this.resp)["responseCode"]);

      if(Object(this.resp)["responseCode"]==107)
      {
        console.log(JSON.stringify(Object( this.resp)["responseInfo"].token));
        let tokenval=JSON.stringify(Object(this.resp)["responseInfo"].token);
      
        this.router.navigateByUrl('ChangePassword'); 
        
      localStorage.setItem('token',tokenval);
      }
      else if(Object(this.resp)["responseCode"]==101)
      {
        this.accessfailedcount=this.resp.ResponseInfo;
        this.loginattemptsremaining= 3-this.accessfailedcount;
        this.invalidcredentailsmsg="Invalid Credentials";
      
      }
      else if(Object(this.resp)["responseCode"]==108)
      {
        
      this.objloginresposne=res as loginResponse;
      
      console.log("from submitLogin: "+this.objloginresposne.name);
     // this.loginserv.loginsubject.next("SC");
      this.loginserv.setLoginResponse(this.objloginresposne);
      this.router.navigateByUrl('/DashboardMain');
      }
      });
  
 }

  

}
