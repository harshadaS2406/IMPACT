import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import { emergency } from 'src/app/models/emergency';
import { EmergencyService } from  'src/app/services/emergency/emergency.service';

@Component({
  selector: 'app-emergency',
  templateUrl: './emergency.component.html',
  styleUrls: ['./emergency.component.css']
})
export class EmergencyComponent implements OnInit {
  userId:number=4;
  constructor(private router:Router, private formBuilder:FormBuilder,private service:EmergencyService,private toast:NgToastService)  { }
  "emergencydetails":FormGroup;
  isSubmitted=false;
 // this.userId=localStorage data;
  selectedRelation:string='';
  relation:any=[
    'Father',
    'Mother',
    'Brother',
    'Sister',
    'Guardian'
  ];
  selectRelationDrop (event:any){
    debugger;
  
   this.selectedRelation=event.target.value;
  }
  
  ngOnInit(): void {
    this.emergencydetails=this.formBuilder.group({
      firstName:new FormControl('',[Validators.required,Validators.minLength(2)]),
      lastName:new FormControl('',[Validators.required,Validators.minLength(2)]),
      contact: new FormControl('',[Validators.required,Validators.maxLength(10)]),
      email: new FormControl('',[Validators.required,Validators.email]),
      relation: new FormControl('',[Validators.required]),
      address:new FormControl('',[Validators.required]),
      isFatal:new FormControl('false',[Validators.required])
    })
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
  pemergencydetails(){
    debugger;
   this.isSubmitted=true;
    if(!this.emergencydetails.valid){
      console.log(this.emergencydetails.value);
      this.toast.error({detail:"Error Message",summary:"Please Provide all values",duration:5000});
    }
    else{
      // // this.validateAllFromFields(this.emergencydetails);
      // // console.log(this.emergencydetails.value);
      let emergencyObj:emergency=new emergency();
       emergencyObj.Address=this.emergencydetails.value.address; 
       emergencyObj.PatientId=this.userId; 
       emergencyObj.FirstName=this.emergencydetails.value.firstName;
       emergencyObj.LastName=this.emergencydetails.value.lastName;
      emergencyObj.EmailId=this.emergencydetails.value.email;
      emergencyObj.Contact=this.emergencydetails.value.contact;
      emergencyObj.Relationship=this.emergencydetails.value.relation;
      emergencyObj.Address=this.emergencydetails.value.address;
      emergencyObj.IsAllowed=this.emergencydetails.get('isFatal')?.value;
      console.log(emergencyObj);
      debugger
      
      if((this.emergencydetails).valid && this.isSubmitted){
        debugger;
        this.toast.success({detail:"Success Message",summary:"Form Successfully Submitted! ",duration:3000});
        this.emergencydetails.reset();
        this.service.emergencyDetails(emergencyObj).subscribe( (response:any)=>{ 
          debugger;
        
          this.router.navigate(['pages-patientregistration/allergy']);
  
        });
      }else{

        this.toast.error({detail:"Error Message",summary:"Form Failed To Submit!",duration:5000})
  
      }
    }
  }
      
      onNext()
      {      
         this.router.navigate(['pages-patientregistration/allergy'])
    
      }
      onPrevious()
      {      
         this.router.navigate(['pages-patientregistration/demographic'])
    
      }

}

