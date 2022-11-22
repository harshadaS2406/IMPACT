import { data } from "@syncfusion/ej2";

export class Appointment{

    
    visitTitle:string;
    visitDescription:string;
    doctorId:number=0;
    patientId:number=0;
    visitDate:Date;
    slotId: number;
    status: string;
}

export class Users
{
    Title="";
    FirstName:"";
    LastName:"";
    GenderID:number;
    Address:"";
    status: Status[] = new Array();

}
export class Status
{
    StatusID:number;
    StatusName:"";
}


