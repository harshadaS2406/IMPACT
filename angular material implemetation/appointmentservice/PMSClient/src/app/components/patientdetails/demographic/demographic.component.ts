import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { demographic } from 'src/app/models/demographic';

import { NgToastService } from 'ng-angular-popup';
import { PatientService } from 'src/app/services/patient/patient.service';

@Component({
  selector: 'app-demographic',
  templateUrl: './demographic.component.html',
  styleUrls: ['./demographic.component.css']
})
export class DemographicComponent implements OnInit {

  toast: any;

  constructor(private router:Router, private formBuilder:FormBuilder,private service:PatientService,private tost:NgToastService ) { }
  "patientdetails":FormGroup;
  selectedRadio:string='';
  selectedGender:string='';
  titles:any=[
    'Mr',
    'Ms',
    'Mrs',
    'Dr'
  ];
  Genders:any=[
    'Male',
    'Female',
    'Others'
  ];
  radioChangeHandler (event:any){
    debugger;
  this.selectedRadio=event.target.value;
  }
  genderChange(event:any){
    debugger;
  this.selectedGender=event.target.value;
  }
  isSubmitted=false;
  ngOnInit(): void {
    this.patientdetails=this.formBuilder.group({
      title:new FormControl('',[Validators.required]),
      firstName:new FormControl('',[Validators.required,Validators.minLength(2)]),
      lastName:new FormControl('',[Validators.required,Validators.minLength(2)]),
      contact:new FormControl('',[Validators.required,Validators.maxLength(10)]),
      dob: new FormControl('',[Validators.required]),
      age: new FormControl('',[Validators.required]),
      email: new FormControl('',[Validators.required,Validators.email]),
      gender:new FormControl('',[Validators.required]),
      race: new FormControl('',[Validators.required]),
      ethnicity: new FormControl('',[Validators.required]),
      languages: new FormControl('',[Validators.required]),
      address:new FormControl('',[Validators.required])
    });
  }
  onNext()
  {      
     this.router.navigate(['pages-patientregistration/emergency'])

  }
  // patientdemodetails(){
  //   if(this.patientdetails.valid)
  //   console.log(this.patientdetails.value);
  //   else{
  //     this.validateAllFromFields(this.patientdetails);
  //     console.log(this.patientdetails.value);
  //   }
  // }
  
patientdemodetails(){
  debugger;
  this.isSubmitted=true;
  if(!this.patientdetails.valid){
    console.log(this.patientdetails.value);
    this.tost.error({detail:"Error Message",summary:"Please Provide all values",duration:5000});

  }            

  else{
    debugger;
    // this.validateAllFromFields(this.patientdetails);
     
    let patientDetailsobj:demographic=new demographic();
    patientDetailsobj.Race=this.patientdetails.value.race;
    patientDetailsobj.Ethnicity=this.patientdetails.value.ethnicity;
    patientDetailsobj.Address=this.patientdetails.value.address; 
    patientDetailsobj.Languages=this.patientdetails.value.languages;
    patientDetailsobj.FirstName=this.patientdetails.value.firstName;
    patientDetailsobj.LastName=this.patientdetails.value.lastName;
    patientDetailsobj.Title=this.patientdetails.value.title;
    patientDetailsobj.gender=this.patientdetails.value.gender;
    console.log(patientDetailsobj);
    // this.patientdetails.reset();
    // this.service.patientDetails(patientDetailsobj).subscribe( (response:any)=>{ debugger 
   
   

    // });
    if((this.patientdetails).valid && this.isSubmitted){
      this.tost.success({detail:"Success",summary:"Demographic details added!",duration:3000});
      this.patientdetails.reset();
      this.service.patientDetails(patientDetailsobj).subscribe( (response:any)=>{ debugger 
        this.router.navigate(['/patient/home']);
     

      });
    }else{

      this.tost.error({detail:"Error Message",summary:"Failed to add!",duration:5000})

    }
  }
}
  
  private validateAllFromFields(formGroup:FormGroup){
    Object.keys(formGroup.controls).forEach(field=>{
      const control = formGroup.get(field);
      if(control instanceof FormControl){
        control.markAsDirty({onlySelf:true});
      }
      else if(control instanceof FormGroup){
        this.validateAllFromFields(control)
      }
    })
  }

}

