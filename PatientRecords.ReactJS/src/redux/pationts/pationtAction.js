import PationtEffect from './pationtEffect';
import ActionUtility from '../../utilities/ActionUtility';

export default class PationtAction {
  static REQUEST_PATIONT_GETSINGLE = 'PationtAction.REQUEST_GETSINGLE';
  static REQUEST_PATIONT_GETSINGLE_FINISHED = 'PationtAction.REQUEST_GETSINGLE_FINISHED';

  static REQUEST_PATIONT_UPDATE = 'PationtAction.REQUEST_UPDATE';
  static REQUEST_PATIONT_UPDATE_FINISHED = 'PationtAction.REQUEST_UPDATE_FINISHED';

  static REQUEST_PATIONT_POST = 'PationtAction.REQUEST_POST';
  static REQUEST_PATIONT_POST_FINISHED = 'PationtAction.REQUEST_POST_FINISHED';

  static REQUEST_PATIONT_GETALL = 'PationtAction.REQUEST_GETALL';
  static REQUEST_PATIONT_GETALL_FINISHED = 'PationtAction.REQUEST_GETALL_FINISHED';
 
  static REQUEST_HEADER_GETALL = 'HeadrerAction.REQUEST_GETALL';
  static REQUEST_HEADER_GETALL_FINISHED = 'HeadrerAction.REQUEST_GETALL_FINISHED';
 

  static requestPost(patient) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PationtAction.REQUEST_PATIONT_POST, PationtEffect.requestPationtPost, patient);
    };
  }

  static requestUpdate(patient) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PationtAction.REQUEST_PATIONT_UPDATE, PationtEffect.requestPationtUpdate, patient);
    };
  }

  static requestGetSingle(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PationtAction.REQUEST_PATIONT_GETSINGLE, PationtEffect.requestPationtGetSingle, patientId);
    };
  }

  static requestGetAll(pageNum=1,pageSize=20,searchField='',dateFilter=null) {
    return async (dispatch, getState) => {
      await ActionUtility.createThunkEffect(dispatch, PationtAction.REQUEST_PATIONT_GETALL, PationtEffect.requestPationtGetAll,pageNum,pageSize,searchField,dateFilter);
    };
  }
 
  static requestGetAllHeader(pageNum=1,pageSize=20,searchField='',dateFilter=null) {
    return async (dispatch, getState) => {
      await ActionUtility.createThunkEffect(dispatch, PationtAction.REQUEST_HEADER_GETALL, PationtEffect.requestPationtGetAll,pageNum,pageSize,searchField,dateFilter);
    };
  }
}
