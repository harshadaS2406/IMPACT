import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { ResponseModel } from '../models/responseModel';
import { NotesModel } from '../models/notes';

@Injectable({
  providedIn: 'root'
})
export class NotesService {

  constructor(private _http: HttpClient) { }

  getUsers(id: number) {
    return this._http.get<any[]>("https://localhost:44357/api/Notes/GetUsers/" + id); //dd
  }

  sendNotes(sendNotesObj: any): Observable<any> {
    return this._http.post<any>("https://localhost:44357/api/Notes/AddNote", sendNotesObj); //dd
  }

  getAllNotesBySenderId(id: number): Observable<any> {
    return this._http.get<ResponseModel>("https://localhost:44357/api/Notes/GetAllSentNotes/" + id); //dd
  }

  getAllNotesByReceiverId(id: number): Observable<any> {
    return this._http.get<ResponseModel>("https://localhost:44357/api/Notes/GetAllReceivedNotes/" + id); //dd
  }

  deleteNoteByid(id: Number): Observable<any> {
    return this._http.delete<ResponseModel>("https://localhost:44357/api/Notes/DeleteNote/" + id); //dd
  }

  getAllAppointments(id: number, roleId: number): Observable<any> {
    return this._http.get<ResponseModel>
      ("https://localhost:44357/api/DashboardAppointmentList/GetAppointmentCount/" + id + '/' + roleId) //dd
  }

  getAllAppointmentsHistory(id: number, roleId: number): Observable<any> {
    return this._http.get<ResponseModel>
      ("https://localhost:44357/api/DashboardAppointmentList/GetAppointmentHistory/" + id + '/' + roleId) //dd
  }

  updateAppointmentStatus(appointmentObj: any) {
    return this._http.put("https://localhost:44357/api/DashboardAppointmentList/UpdateAppointment", appointmentObj);
  }

}
