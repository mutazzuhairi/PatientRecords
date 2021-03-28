export const handleValidation = (clonePationtRecord)=>{
    let fields = clonePationtRecord;
    let errors = {};
    let formIsValid = true;
    if(!fields["diseaseName"]){
       formIsValid = false;
       errors["diseaseName"] = "Cannot be empty";
    }
    if(!fields["description"]){
       formIsValid = false;
       errors["description"] = "Cannot be empty";
    }
    if(!fields["timeOfEntry"]){
       formIsValid = false;
       errors["timeOfEntry"] = "Cannot be empty";
    }
    if(!fields["bill"]){
       formIsValid = false;
       errors["bill"] = "Cannot be empty";
    }

 
   return {formIsValid,errors};
}