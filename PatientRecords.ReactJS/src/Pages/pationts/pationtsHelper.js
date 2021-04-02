export const handleValidation = (clonePationt)=>{
    let fields = clonePationt;
    let errors = {};
    let formIsValid = true;
    if(!fields["name"]){
       formIsValid = false;
       errors["name"] = "Cannot be empty";
    }
    if(!fields["officialId"]){
       formIsValid = false;
       errors["officialId"] = "Cannot be empty";
    }
    if(fields["email"] && typeof fields["email"] !== "undefined"){
       let lastAtPos = fields["email"].lastIndexOf('@');
       let lastDotPos = fields["email"].lastIndexOf('.');
       if (!(lastAtPos < lastDotPos && lastAtPos > 0 && fields["email"].indexOf('@@') == -1 && 
            lastDotPos > 2 && (fields["email"].length - lastDotPos) > 2)) {
          formIsValid = false;
          errors["email"] = "Email is not valid";
        }
   }  

   return {formIsValid,errors};
}