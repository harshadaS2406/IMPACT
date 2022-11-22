export class PatientAllergyModel{
    Allergyid !:number;
    PatientAllergyDetailsId!:number;
    AllergyType:string='';
    Is_Allergy_Fatal:boolean=false;
    AllergyDescription :string='';
    AllergyName:string='';
    Allergy_Clinical_Information:string='';
    PatientId: number;
   
 }