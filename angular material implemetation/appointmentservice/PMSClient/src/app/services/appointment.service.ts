import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Appointment } from '../models/Appointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {
  private Url="Appointment";
  

  constructor(private http:HttpClient) { }


  public getAppointments():Observable<any>
  {
    
    return this.http.get<any>(`${environment.apiUrl}/${this.Url}`);
  }

  public getAppointmentsByRoleId(id:number,roleId:number):Observable<any>
  {
    
    return this.http.get<any>(`${environment.apiUrl}/${this.Url}/userAppointments/${id}/${roleId}`);
  }

  public postAppointmentDetails(data:any):Observable<any>
  {
    return this.http.post<any>(`${environment.apiUrl}/${this.Url}`,data);
  }

  public getUsers():Observable<any>
  {
    
    return this.http.get<any>("https://localhost:44370/api/User/Patient");
  }

  public getPysician():Observable<any>
  {
    
    return this.http.get<any>("https://localhost:44370/api/User/Physician");
  }

  public getSlots(date:any,id:number):Observable<any>
  {   
    return this.http.get<any>("https://localhost:44301/api/Appointment/Availableslots/"+date+"/"+id);
  }
}
