import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { PatientAllergyModel } from 'src/app/models/PatientAllergyModel';
import { AllergyService } from 'src/app/services/allergy/allergy.service';

@Component({
  selector: 'app-allergy',
  templateUrl: './allergy.component.html',
  styleUrls: ['./allergy.component.css']
})
export class AllergyComponent implements OnInit {
  AllergyType!: string;
  sampleAllergy:string='this is sample';
  maxDate!: Date;
  response: any;
  result!: any[];
  res!: any;
  allallergytype!: string[];
  allallergyname!: string[];
  output!: any;
  patientAllergyId!:number;
  allergyId!:number;
  allergy_Name!: string;
  allergy_Type!: string;
  allergy_Desc!: string;
  allergy_Clinical!: string;
  allergyobj!: PatientAllergyModel;
  patientId: number=4;
  isFatal: boolean=false;
  createdOn!: Date;
  updatedOn!: Date;
  constructor(private router:Router, private formBuilder:FormBuilder,private service:AllergyService,private toast:NgToastService) {


  }
  "allergydetails":FormGroup;
   isSubmitted=false;
   isLinear = false;
  
  onDropdownChange(event:any) 
  {
    //debugger;
    console.log(event);
    console.log(this.sampleAllergy);
    this.AllergyType= String(event);
    console.log(this.AllergyType);
    this.output=this.result.find(x=>x.allergyType == this.AllergyType)
    this.allergy_Name=this.output.allergyName;
    console.log(this.allergy_Name);

    console.log(this.output);
    // this.result.find
  }



  onChange(event:any) 
    {
     // debugger;
      console.log(event);
     this.res=this.output;
     console.log(this.res)
     console.log(this.res.allergy_Name)
     this.allergyId=this.res.allergyId
     this.allergy_Desc=this.res.allergyDescription
     this.allergy_Clinical=this.res.allergyClinicalInformation

      
    }

  ngOnInit(): void {
    this.getMasterAllergy();
    this.allergydetails=this.formBuilder.group({
      allergytype: new FormControl('',[Validators.required]),
      allergyname: new FormControl('',[Validators.required]),
      allergyid: new FormControl('',[Validators.required]),
      allergydesc:new FormControl('',[Validators.required,Validators.maxLength(30)]),
      allergyclinical:new FormControl('',[Validators.required,Validators.maxLength(60)]),
      Is_Fatal:new FormControl(this.isFatal,[Validators.required])
    });
    
  }
  getMasterAllergy(){
   //debugger;
    this.service.allAllergies().subscribe((data)=>
    { 
      // console.log(data);
      
     // debugger;
      this.response=data.dataSet;
      console.log(this.response);
      
      this.result=this.response;
     
      //console.log(this.allallergytype);
      
      console.log(this.result);
      
     
    })
    }
    pallergydetails(){
    //debugger;
    this.isSubmitted=true;
    console.log(this.allergydetails.value);
    if(!this.allergydetails.valid){
      this.toast.error({detail:"Error Message",summary:"Please Provide all values",duration:5000})
    }
    
    else{

      console.log(this.allergydetails);
      if (this.allergydetails.valid) {
        this.allergyobj=new PatientAllergyModel();
         this.allergyobj.Allergyid=Number(this.allergyId);
         this.allergyobj.PatientId=this.patientId;
         this.allergyobj.AllergyName=this.res.allergyName;
         this.allergyobj.AllergyType=this.res.allergyType;
         this.allergyobj.AllergyDescription=this.allergy_Desc;
         this.allergyobj.Allergy_Clinical_Information=this.allergy_Clinical;
         this.allergyobj.Is_Allergy_Fatal=this.allergydetails.get('Is_Fatal')?.value;
        
        //  this.allergyobj.CreatedOn=this.createdOn;
        //  this.allergyobj.UpdatedOn=this.updatedOn;
         console.log(this.allergyobj);
        // console.log(this.allergydetails.value)
        // this.service.allergyDetails(this.allergyobj).subscribe((data: ResponseModel) => {
       
        // })
        if((this.allergydetails).valid && this.isSubmitted){
                this.toast.success({detail:"Success Message",summary:"Form Successfully Submitted!",duration:3000});
                this.router.navigate(["/pages-dashboard/dashboard"]);    
                //this.allergydetails.reset();
                console.log("inside service call");
               this.service.allergyDetails(this.allergyobj).subscribe( (response:any)=>{ debugger 
                
                
          
                });
              }else{
          
                this.toast.error({detail:"Error Message",summary:"Form Failed To Submit!",duration:5000})
          
              }
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
  onPrevious()
  {      
     this.router.navigate(['pages-patientregistration/emergency'])

  }


}
