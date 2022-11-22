import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { HospitalUser, PatientUser } from '../custommaterial/admin/hospuser/hospuser';
import { Observable } from 'rxjs';
import { ResponsefromApi } from '../components/login/login';


@Injectable({
  providedIn: 'root'
})
export class AdminService {
  headers = new HttpHeaders({ 'Content-Type': 'application/json' });

  constructor(private http: HttpClient) { }

  addHUser(objHospitalUser: HospitalUser)
  {
    debugger;
    console.log("service hit");
    return this.http.post<any>("https://localhost:44370/api/User/Register", objHospitalUser, { headers: this.headers });
  }


  addPUser(objHospitalUser: PatientUser)
  {
    debugger;
    console.log("service hit");
    return this.http.post<any>("https://localhost:44370/api/User/Register", objHospitalUser, { headers: this.headers });
  }

  getHospUser()
  {
    return this.http.get<any>("https://localhost:44370/api/User/GetHospitalUsers");
 
  }

  getPatientUser()
  {
    debugger
    return this.http.get<any>("https://localhost:44370/api/User/GetPatientUsers");

  }

  UpdateUserStatus(hospuser:any)
  {
    return this.http.post<any>("https://localhost:44370/api/User/UpdateUserStatus", hospuser, { headers: this.headers });

  }
}
