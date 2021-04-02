import PationtEffect from './patientRecordEffect';
import ActionUtility from '../../utilities/ActionUtility';

export default class PationtRecordAction {
  static REQUEST_PATIONTRECORD_GETSINGLE = 'PationtRecordAction.REQUEST_GETSINGLE';
  static REQUEST_PATIONTRECORD_GETSINGLE_FINISHED = 'PationtRecordAction.REQUEST_GETSINGLE_FINISHED';

  static REQUEST_PATIONTRECORD_UPDATE = 'PationtRecordAction.REQUEST_UPDATE';
  static REQUEST_PATIONTRECORD_UPDATE_FINISHED = 'PationtRecordAction.REQUEST_UPDATE_FINISHED';

  static REQUEST_PATIONTRECORD_POST = 'PationtRecordAction.REQUEST_POST';
  static REQUEST_PATIONTRECORD_POST_FINISHED = 'PationtRecordAction.REQUEST_POST_FINISHED';

  static REQUEST_PATIONTRECORD_GETALL = 'PationtRecordAction.REQUEST_GETALL';
  static REQUEST_PATIONTRECORD_GETALL_FINISHED = 'PationtRecordAction.REQUEST_GETALL_FINISHED';
 
  static REQUEST_PATIONTRECORD_GETALL_PATIENTID = 'PationtRecordAction.REQUEST_GETALL_PATIENTID';
  static REQUEST_PATIONTRECORD_GETALL_PATIENTID_FINISHED = 'PationtRecordAction.REQUEST_GETALL_PATIENTID_FINISHED';

  static requestGetSingle(patientRecordId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PationtRecordAction.REQUEST_PATIONTRECORD_GETSINGLE, PationtEffect.requestPationtRecordGetSingle, patientRecordId);
    };
  }

  static requestUpdate(patientRecord) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PationtRecordAction.REQUEST_PATIONTRECORD_UPDATE, PationtEffect.requestPationtRecordUpdate, patientRecord);
    };
  }

  static requestPost(patientRecord) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PationtRecordAction.REQUEST_PATIONTRECORD_POST, PationtEffect.requestPationtRecordPost, patientRecord);
    };
  }

  static requestGetAll(pageNum=1,pageSize=20,searchField='',dateFilter=null) {
    return async (dispatch, getState) => {
      await ActionUtility.createThunkEffect(dispatch, PationtRecordAction.REQUEST_PATIONTRECORD_GETALL, PationtEffect.requestPationtRecordGetAll,pageNum,pageSize,searchField,dateFilter);
    };
  }

  static requestGetAllfForPatientId(patientId,pageNum=1,pageSize=20,searchField='') {
    return async (dispatch, getState) => {
      await ActionUtility.createThunkEffect(dispatch, PationtRecordAction.REQUEST_PATIONTRECORD_GETALL_PATIENTID, PationtEffect.requestPationtRecordGetAllForPatient,pageNum,pageSize,searchField,patientId);
    };
  }
 
}
