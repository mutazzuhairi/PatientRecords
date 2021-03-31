import { BaseModel } from 'sjs-base-model';
import PatientRecordView from '../../patientRecords/models/patientRecordView'
export default class PatientView extends BaseModel {
    id = 0;
    name = '';
    officialId = '';
    email = '';
    dateOfBirth= Date;
    lastEntry = PatientRecordView;
    createdDate= new Date;
    updatedDate= new Date;
    updatedBy = '';
    createdBy = '';
    constructor(data) {
      super();
  
      this.update(data);
    }
  }