import { Component, OnInit } from '@angular/core';
import { ResponseModel } from 'src/app/models/responseModel';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-dashboard-main',
  templateUrl: './dashboard-main.component.html',
  styleUrls: ['./dashboard-main.component.css']
})
export class DashboardMainComponent implements OnInit {

  dashboardValues: any;
  response2!: any;
  response3!: any;
  appointmentCount: number = 0;
  appointmentHistoryCount: number = 0;

  loggedRoleId: number;
  loggedUserId: number;

  constructor(private _service: NotesService,) { }

  ngOnInit(): void {
    this.loggedUserId = Number(localStorage.getItem('userid'));
    this.loggedRoleId = Number(localStorage.getItem('roleid'));
    this.loadAppointments();
    this.loadAppointmentsHistory()
  }

  loadAppointments() {
    this._service.getAllAppointments(this.loggedUserId, this.loggedRoleId).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        debugger;
        this.response2 = response.dataSet;
        console.log(this.response2);

        this.appointmentCount = this.response2.length;
        console.log('appoint', this.response2.length);

      }
    });
  }

  loadAppointmentsHistory() {
    this._service.getAllAppointmentsHistory(this.loggedUserId, this.loggedRoleId).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        debugger;
        this.response3 = response.dataSet;
        console.log(this.response2);

        this.appointmentHistoryCount = this.response3.length;
        console.log('appoint', this.response3.length);

      }
    });
  }

}
