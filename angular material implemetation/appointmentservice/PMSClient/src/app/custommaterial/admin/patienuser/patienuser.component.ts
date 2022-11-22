import { inject, OnInit } from '@angular/core';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { PatientUserRegistrationComponent } from './patient-user-registration/patient-user-registration.component';
import { AdminService } from 'src/app/services/admin.service';
import { PatientUser } from '../hospuser/hospuser';

@Component({
  selector: 'app-patienuser',
  templateUrl: './patienuser.component.html',
  styleUrls: ['./patienuser.component.css']
})
export class PatienuserComponent implements OnInit {
  objPatientUser= new PatientUser;
  displayedColumns: string[] = ['userId', 'patientName', 'dor', 'status', 'action'];
  dataSource: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private dialog: MatDialog, private adminserv: AdminService) { }

  openDialog() {
    this.dialog.open(PatientUserRegistrationComponent);
  }


  ngOnInit(): void {
    this.getPatientUser();
  }

  getPatientUser()
  {
debugger
    this.adminserv.getPatientUser().subscribe((data) => {
      debugger;
      console.log(data);
      this.dataSource = new MatTableDataSource(data);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;

    });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  editUser(row: any) {

    this.dialog.open(PatientUserRegistrationComponent,
      {
        data: row
      });
  }

  blockUser(row: any) {
    debugger;
    this.objPatientUser.UserId=row.userId;
    this.objPatientUser.StatusId=3;
    console.log("block:" + row.userId);
    this.adminserv.UpdateUserStatus(this.objPatientUser).subscribe((data)=>{
      console.log(data);
    });
    this.getPatientUser();
  }

  ActivateUser(row: any) {
    debugger;
    this.objPatientUser.UserId=row.userId;
    this.objPatientUser.StatusId=1;
    console.log("active:" + row.userId);
    this.adminserv.UpdateUserStatus(this.objPatientUser).subscribe((data)=>{
      console.log(data);
    });
    this.getPatientUser();

  }


  DeactivateUser(row: any) {
    debugger;
    this.objPatientUser.UserId=row.userId;
    this.objPatientUser.StatusId=2;
    console.log("active:" + row.userId);
    this.adminserv.UpdateUserStatus(this.objPatientUser).subscribe((data)=>{
      console.log(data);
    });
    this.getPatientUser();

  }




}


