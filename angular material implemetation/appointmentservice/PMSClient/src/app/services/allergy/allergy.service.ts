import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class AllergyService {
  constructor(private http:HttpClient) { }
  readonly BaseURI='https://localhost:44302/api/Allergies'
  readonly BaseURI1='https://localhost:44302/api/Allergies'
  allergyDetails(data:any): Observable<any>{
    

    return this.http.post<ResponseModel>(this.BaseURI+'/addAllergies',data,{responseType:'text' as 'json'})
    // return this.http.post<ResponseModel>(this.BaseURI + '/AddPatientInfodata', );



  }
  allAllergies(): Observable<any>{
    
     
    return this.http.get(this.BaseURI1+'/GetAllergyDetails');


  }

}
