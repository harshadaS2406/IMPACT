import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-patientvisitmedication',
  templateUrl: './patientvisitmedication.component.html',
  styleUrls: ['./patientvisitmedication.component.css']
})
export class PatientvisitmedicationComponent implements OnInit {

  submitted = false;
  patientMedicationForm: any;
  sections: any;//array to reolicate medication section
  secCount:number=1;
  constructor( private toast : NgToastService,private fb:FormBuilder) { }

  ngOnInit() {
    this.patientMedicationForm = this.fb.group({
      drugId: ['', [Validators.required]],
      drugName: ['', [Validators.required]],
      drugGenName :['', [Validators.required]],
      drugForm :['', [Validators.required]]
    });
    this.sections=[{secCount:this.secCount}];
  }

  addMedication() {
    console.log("new section added");
    this.secCount++;
    var item={secCount:this.secCount};
    this.sections.push(item);
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.patientMedicationForm.invalid) {
        return;
    }

    this.toast.success({detail:"Success Message",summary:"Data saved!",duration:3000});

  }

  edit(){
    console.log("edit activated");
  }

}
