import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patienthome',
  templateUrl: './patienthome.component.html',
  styleUrls: ['./patienthome.component.css']
})
export class PatienthomeComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  isDemographic: boolean =false;
  isEmergency: boolean = false;
  isAllergy: boolean = false;

  displayPatientDetails(id) {
    if (id == "demographic") {
      this.isDemographic = true;
      this.isEmergency = false;
      this.isAllergy = false;
   
    }
    else if (id == "emergency") {
      this.isDemographic = false;
      this.isEmergency =true;
      this.isAllergy = false;
    }
    else if (id == "allergy") {
      this.isDemographic = false;
      this.isEmergency = false;
      this.isAllergy = true;
    }
  }
}
