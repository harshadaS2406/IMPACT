import { Component, OnInit } from '@angular/core';
import { ResponseModel } from 'src/app/models/responseModel';
import { NotesService } from 'src/app/services/notes.service';

@Component({
  selector: 'app-appointmenthistorylist',
  templateUrl: './appointmenthistorylist.component.html',
  styleUrls: ['./appointmenthistorylist.component.css']
})
export class AppointmenthistorylistComponent implements OnInit {

  dataTableValues: any;

  totalLength: any;
  page: number = 1;

  loggedRoleId: number;
  loggedUserId: number;

  constructor(private _service: NotesService) { }

  ngOnInit(): void {
    this.loggedUserId = Number(localStorage.getItem('userid'));
    this.loggedRoleId = Number(localStorage.getItem('roleid'));
    this.GettAppointmentsHistoryList();
  }

  GettAppointmentsHistoryList() {
    this._service.getAllAppointmentsHistory(this.loggedUserId, this.loggedRoleId).subscribe((response: ResponseModel) => {
      if (response.responseCode == 1) {
        debugger;
        this.dataTableValues = response.dataSet;

        this.totalLength = response.dataSet.length;
        console.log(this.totalLength);
      }
    });
  }

}
