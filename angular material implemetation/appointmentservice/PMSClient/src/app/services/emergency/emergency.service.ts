import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class EmergencyService {

  constructor(private http:HttpClient) { }
  readonly BaseURI='https://localhost:44302/api/EmergencyContact'
  emergencyDetails(data:any): Observable<any>{
    
debugger
    return this.http.post<ResponseModel>(this.BaseURI+'/addContacts',data,{responseType:'text' as 'json'})
    // return this.http.post<ResponseModel>(this.BaseURI + '/AddPatientInfodata', );



  }
}
