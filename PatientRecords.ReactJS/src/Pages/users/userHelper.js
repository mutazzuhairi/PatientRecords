export const    handleValidation = (cloneUser)=>{
    let fields = cloneUser;
    let errors = {};
    let formIsValid = true;
    if(!fields["firstName"]){
       formIsValid = false;
       errors["firstName"] = "Cannot be empty";
    }
    if(!fields["lastName"]){
       formIsValid = false;
       errors["lastName"] = "Cannot be empty";
    }
    if(!fields["userName"]){
       formIsValid = false;
       errors["userName"] = "Cannot be empty";
    }
    if(!fields["email"]){
       formIsValid = false;
       errors["email"] = "Cannot be empty";
    }
    if(!fields["email"]){
       formIsValid = false;
       errors["email"] = "Cannot be empty";
    }
    if(typeof fields["email"] !== "undefined"){
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