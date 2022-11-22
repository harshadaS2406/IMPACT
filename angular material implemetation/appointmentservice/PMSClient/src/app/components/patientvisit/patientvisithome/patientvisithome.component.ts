import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patientvisithome',
  templateUrl: './patientvisithome.component.html',
  styleUrls: ['./patientvisithome.component.css']
})
export class PatientvisithomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  ispatientvisitdetails: boolean =false;
  ispatientdiagnosis: boolean = false;
  ispatientmedication: boolean = false;
  ispatientprocedure: boolean = false;
  ispatientvitalsigns: boolean = false;

  displayPatientVisit(id) {
    if (id == "patientvisitdetails") {
      this.ispatientvisitdetails = true;
      this.ispatientdiagnosis = false;
      this.ispatientmedication = false;
      this.ispatientprocedure = false;
      this.ispatientvitalsigns = false;
   
    }
    else if (id == "patientdiagnosis") {
      this.ispatientvisitdetails = false;
      this.ispatientdiagnosis =true;
      this.ispatientmedication = false;
      this.ispatientprocedure = false;
      this.ispatientvitalsigns = false;
    }
    else if (id == "patientmedication") {
      this.ispatientvisitdetails = false;
      this.ispatientdiagnosis = false;
      this.ispatientmedication = true;
      this.ispatientprocedure = false;
      this.ispatientvitalsigns = false;
    }
    else if (id == "patientprocedure") {
      this.ispatientvisitdetails = false;
      this.ispatientdiagnosis = false;
      this.ispatientmedication = false;
      this.ispatientprocedure = true;
      this.ispatientvitalsigns = false;
    }
    else if (id == "patientvitalsigns") {
      this.ispatientvisitdetails = false;
      this.ispatientdiagnosis = false;
      this.ispatientmedication = false;
      this.ispatientprocedure = false;
      this.ispatientvitalsigns = true;
    }
  }
}
