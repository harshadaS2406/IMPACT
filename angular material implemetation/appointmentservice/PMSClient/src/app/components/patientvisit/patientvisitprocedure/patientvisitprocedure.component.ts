import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-patientvisitprocedure',
  templateUrl: './patientvisitprocedure.component.html',
  styleUrls: ['./patientvisitprocedure.component.css']
})
export class PatientvisitprocedureComponent implements OnInit {

 
  submitted = false;
  patientProcedureForm: any;
  sections: any;//array to reolicate diagnosis section
  secCount:number=1;
  constructor( private toast : NgToastService,private fb:FormBuilder) { }

  ngOnInit() {
    this.patientProcedureForm = this.fb.group({
      procedureCode: ['', [Validators.required]],
      procedureDesc: ['', [Validators.required]],
      hasAllergy :['', [Validators.required]]
    });
    this.sections=[{secCount:this.secCount}];
  }

  addProcedure() {
    console.log("new section added");
    this.secCount++;
    var item={secCount:this.secCount};
    this.sections.push(item);
  }

  onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.patientProcedureForm.invalid) {
        return;
    }

    this.toast.success({detail:"Success Message",summary:"Data saved!",duration:3000});

  }

  edit(){
    console.log("edit activated");
  }

}
