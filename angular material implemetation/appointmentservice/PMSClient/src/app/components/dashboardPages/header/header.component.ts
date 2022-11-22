import { Component, OnInit } from '@angular/core';
import{loginResponse, ResponsefromApi} from 'src/app/components/login/login';
import { LoginService } from 'src/app/login.service';
import { Observable, Subject } from 'rxjs';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  providers:[loginResponse]
})
export class HeaderComponent implements OnInit {
   
  objloginresponse:loginResponse= new loginResponse();
  loggedInUser:string ;
  resp = new ResponsefromApi();


  constructor(private loginserv:LoginService) { 

    console.log("header ctor");
  }

  ngOnInit() {
    this.loggedInUser=localStorage.getItem('name');
    console.log("User Name"+ this.loggedInUser);
    this.loginserv.getLoginResponse().subscribe((data)=>
      {
         this.objloginresponse=data as loginResponse; 
        console.log("From HeaderComponent"+this.objloginresponse.name)
        this.loggedInUser=localStorage.getItem('name').replace(/"/g, '');
        
      });
  
    console.log("ng on it");
  }



}
