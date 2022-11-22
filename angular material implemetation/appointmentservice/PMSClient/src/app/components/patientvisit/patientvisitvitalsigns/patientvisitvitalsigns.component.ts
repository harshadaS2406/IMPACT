import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-patientvisitvitalsigns',
  templateUrl: './patientvisitvitalsigns.component.html',
  styleUrls: ['./patientvisitvitalsigns.component.css']
})
export class PatientvisitvitalsignsComponent implements OnInit {
  
  submitted = false;
  patientVitalSignsForm: any;
  

  constructor() { }

  ngOnInit(): void {
  }
  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.patientVitalSignsForm.invalid) {
        return;
    }

    alert('Your password has been successfully updated. You may now login your account')//change to angular toast alert
  }

}
