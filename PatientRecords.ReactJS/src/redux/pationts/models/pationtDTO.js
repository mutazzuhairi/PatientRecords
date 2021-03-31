import { BaseModel } from 'sjs-base-model';
 
export default class PatientDTO extends BaseModel {
    id = 0;
    name = '';
    officialId = '';
    email = '';
    dateOfBirth = Date;
    createdDate = new Date;
    updatedDate = new Date;
    updatedBy = '';
    createdBy = '';
    constructor(data) {
      super();
   
      this.update(data);
    }
  }