import { BaseModel } from 'sjs-base-model';
import PatientRecordView from '../../patientRecords/models/patientRecordView'
export default class PatientView extends BaseModel {
    id = 0;
    name = '';
    officialId = '';
    email = '';
    dateOfBirth ;
    lastEntry = PatientRecordView;
    createdDate;
    updatedDate;
    updatedBy = '';
    createdBy = '';
    constructor(data) {
      super();
  
      this.update(data);
    }
  }