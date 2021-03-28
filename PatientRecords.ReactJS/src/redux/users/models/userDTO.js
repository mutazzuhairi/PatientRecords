import { BaseModel } from 'sjs-base-model';
 
export default class UserDTO extends BaseModel {
    id = '';
    lastName = '';
    firstName = '';
    email ='';
    userName = '';
    passwordHash = '';
    createdDate = new Date();
    updatedDate = new Date();
    updatedBy = '';
    createdBy = '';
    constructor(data) {
      super();
  
      this.update(data);
    }
  }