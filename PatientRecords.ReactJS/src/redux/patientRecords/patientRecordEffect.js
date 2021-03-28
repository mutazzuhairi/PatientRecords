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

  static async requestPationtRecordGetAll(pageNum,pageSize) {
    const endpoint = PationtRecordEffect.apiurl+"View?PageSize="+pageSize+"&PageNumber="+pageNum;

    return EffectUtility.getToModel(PagedResponse, endpoint);
  }

 
}
