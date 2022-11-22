import { inject, OnInit } from '@angular/core';
import { AfterViewInit, Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { HospUserRegistrationComponent } from './hosp-user-registration/hosp-user-registration.component';
import { AdminService } from 'src/app/services/admin.service';
import { HospitalUser } from './hospuser';
import { MatSnackBar, MatSnackBarRef } from '@angular/material/snack-bar';


@Component({
  selector: 'app-hospuser',
  templateUrl: './hospuser.component.html',
  styleUrls: ['./hospuser.component.css']
})

export class HospuserComponent implements OnInit {
  objHospitalUser= new HospitalUser;
  displayedColumns: string[] = ['employeeID', 'employeeName', 'doj', 'status', 'action'];
  dataSource: MatTableDataSource<any>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private dialog: MatDialog, private adminserv: AdminService,private _snackBar: MatSnackBar) { }

  openDialog() {
    this.dialog.open(HospUserRegistrationComponent);
  }

  ngOnInit(): void {
    this.getHospitalUsers();
  }

  getHospitalUsers()
  {

    this.adminserv.getHospUser().subscribe((data) => {
      debugger;
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

    this.dialog.open(HospUserRegistrationComponent,
      {
        data: row
      });
  }

  blockUser(row: any) {
    debugger;
    this.objHospitalUser.userId=row.userId;
    this.objHospitalUser.StatusId=3;
    console.log("block:" + row.userId);
    this.adminserv.UpdateUserStatus(this.objHospitalUser).subscribe((data)=>{
      console.log(data);
    });
    this.getHospitalUsers();
  }

  ActivateUser(row: any) {
    debugger;
    this.objHospitalUser.userId=row.userId;
    this.objHospitalUser.StatusId=1;
    console.log("active:" + row.userId);
    this.adminserv.UpdateUserStatus(this.objHospitalUser).subscribe((data)=>{
      console.log(data);
    });
    this.getHospitalUsers();

  }


  DeactivateUser(row: any) {
    debugger;
    this.objHospitalUser.userId=row.userId;
    this.objHospitalUser.StatusId=2;
    console.log("active:" + row.userId);
    this.adminserv.UpdateUserStatus(this.objHospitalUser).subscribe((data)=>{
      console.log(data);
    });
    this.getHospitalUsers();

  }

  
 

}


