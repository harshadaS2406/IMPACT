import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { ChangePassword, ForgotPassword, loginrequest, loginResponse, ResponsefromApi } from '../app/components/login/login';
import { Observable, Subject } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';



@Injectable({
  providedIn: 'root'
})
export class LoginService   {
  public loginsubject = new BehaviorSubject<loginResponse>(null);
  public objloginreq = new loginrequest();
  public objloginres = new loginResponse();
  public JWT: string;
  headerschangepwd: any;
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });


  constructor(private http: HttpClient, private route: ActivatedRoute,private router:Router) {


   }
  // intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    
  //   this.JWT =this.route.snapshot.params['token'];
    
  //   console.log(this.JWT);
  //   let token = req.clone({
  //     setHeaders: {
  //       Authorization:"Basic "+ this.JWT
  //       }
  //   });
  //   return next.handle(token);
  // }

  ;
  loginUser(loginobj: loginrequest) {
    return this.http.post("https://localhost:44370/api/Login/", loginobj, { headers: this.headers });
  }



  forgotPassword(forgotpassobj: ForgotPassword) {
    return this.http.post("https://localhost:44370/api/User/ForgotPassword", forgotpassobj, { headers: this.headers });
  }



  changePassword(changePasswordobj: ChangePassword){
    console.log("coming in change password");
   // let token = localStorage.getItem("token");
    //console.log("local storage: "+ localStorage.getItem("token"))

    let headerscp = new HttpHeaders({
      'Authorization': 'Bearer ' + localStorage.getItem('token').replace(/"/g, '')
    });
   

    console.log("headers: "+headerscp.get('Authorization'));


    return this.http.post<ResponsefromApi>("https://localhost:44370/api/User/ChangePassword", changePasswordobj,{headers: headerscp});
  }

  setLoginResponse(value: loginResponse) {
    this.loginsubject.next(value);

  }

  getLoginResponse(): Observable<loginResponse> {
    return this.loginsubject.asObservable();
  }




}
