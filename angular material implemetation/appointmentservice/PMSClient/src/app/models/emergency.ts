
export class emergency{
  emergencyDetails(emergencyObj: emergency) {
    throw new Error('Method not implemented.');
  }
    PatientId:number;
    FirstName:string="";
     LastName:string="";
     EmailId:string="";
  // Createdon: Date=new Date();
  Contact!:number;
  // gender:string="";
  Address: string="";
  Relationship:string="";
  
  IsAllowed:boolean=false;

}