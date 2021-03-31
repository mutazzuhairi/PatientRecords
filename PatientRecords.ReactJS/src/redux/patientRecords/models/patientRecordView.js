import { BaseModel } from 'sjs-base-model';
import pationtView from '../../pationts/models/pationtView';

export default class PatientRecordView extends BaseModel {
    id = 0;
    patientId = 0;
    diseaseName = '';
    bill = 0.0;
    description = '';
    patientDTO = pationtView;
    timeOfEntry =  Date;
    createdDate = new Date;
    updatedDate = new Date;
    updatedBy = '';
    createdBy = '';
    constructor(data) {
      super();
  
      this.update(data);
    }
  }