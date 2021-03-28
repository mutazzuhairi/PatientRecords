import authEffect from './authEffect';
import ActionUtility from '../../utilities/ActionUtility';

export default class authAction {
  static REQUEST_AUTH_POST_LOGIN = 'authAction.REQUEST_POST_LOGIN';
  static REQUEST_AUTH_POST_LOGIN_FINISHED = 'authAction.REQUEST_POST_LOGIN_FINISHED';
 
  static requestPost(loginAuth) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, authAction.REQUEST_AUTH_POST_LOGIN, authEffect.requestPationtRecordPost, loginAuth);
    };
  }
 
 
}
