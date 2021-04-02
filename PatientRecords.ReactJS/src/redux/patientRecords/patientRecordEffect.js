import patientRecordView from './models/patientRecordView';
import EffectUtility from '../../utilities/EffectUtility';
import PagedResponse from '../../models/PagedResponse'
import PatientRecordDTO from './models/patientRecordDTO';

export default class PationtRecordEffect {

  static apiurl = process.env.REACT_APP_API_URL+'/PatientRecord';
  
  static async requestPationtRecordGetSingle(patientRecordId) {
    const endpoint = PationtRecordEffect.apiurl+"/"+patientRecordId;

    return EffectUtility.getToModel(PatientRecordDTO, endpoint);
  }

  static async requestPationtRecordUpdate(patientRecord) {
    const endpoint = PationtRecordEffect.apiurl; 
    return EffectUtility.putToModel(PatientRecordDTO, endpoint,patientRecord);
  }

  static async requestPationtRecordPost(patientRecord) {
    const endpoint = PationtRecordEffect.apiurl;
    return EffectUtility.postToModel(PatientRecordDTO, endpoint,patientRecord);
  }

  static async requestPationtRecordGetAll(pageNum,pageSize,searchField,dateFilter) {
    const endpoint = PationtRecordEffect.apiurl+"View?PageSize="+pageSize+"&PageNumber="+pageNum+"&SearchField="+searchField+"&DateFilter="+dateFilter;

    return EffectUtility.getToModel(PagedResponse, endpoint);
  }

  
  static async requestPationtRecordGetAllForPatient(pageNum,pageSize,searchField,patientId) {
    const endpoint = PationtRecordEffect.apiurl+"View/AllForPatientId?PageSize="+pageSize+"&PageNumber="+pageNum+"&SearchField="+searchField+"&patientId="+patientId;

    return EffectUtility.getToModel(PagedResponse, endpoint);
  }
 
}
