import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/responseModel';

@Injectable({

  providedIn: 'root'
})
export class PatientService {

  
  constructor(private http:HttpClient) { }
  readonly BaseURI='https://localhost:44360/api/Patient'
  readonly PatientDiagnosisUrl='https://localhost:44302/api/PatientDiagnosis'
  
  patientDetails(data:any): Observable<any>{
    
    return this.http.post<ResponseModel>(this.BaseURI+'/AddPatientInfo',data,{responseType:'text' as 'json'})
    // return this.http.post<ResponseModel>(this.BaseURI + '/AddPatientInfodata', );

  }

  getDiagnosis():Observable<any>{
    return this.http.get<ResponseModel>(this.PatientDiagnosisUrl +'/GetAllDiagnosisDetails')
  }
  
}