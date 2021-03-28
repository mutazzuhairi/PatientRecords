import { BaseModel } from 'sjs-base-model';
import PatientDTO from '../../pationts/models/pationtDTO';

export default class PatientRecordDTO extends BaseModel {
    id = 0;
    patientId = 0;
    diseaseName = '';
    bill = 0.0;
    description = '';
    patient = PatientDTO;
    timeOfEntry = new Date();
    createdDate = new Date();
    updatedDate = new Date();
    updatedBy = '';
    createdBy = '';
    constructor(data) {
      super();
  
      this.update(data);
    }
  }