import UserEffect from './userEffect';
import ActionUtility from '../../utilities/ActionUtility';

export default class UserAction {
  static REQUEST_User_GETSINGLE = 'UserAction.REQUEST_GETSINGLE';
  static REQUEST_User_GETSINGLE_FINISHED = 'UserAction.REQUEST_GETSINGLE_FINISHED';

  static REQUEST_User_POST= 'UserAction.REQUEST_POST';
  static REQUEST_User_POST_FINISHED = 'UserAction.REQUEST_POST_FINISHED';

  static REQUEST_User_UPDATE= 'UserAction.REQUEST_UPDATE';
  static REQUEST_User_UPDATE_FINISHED = 'UserAction.REQUEST_UPDATE_FINISHED';

  static REQUEST_User_GETALL = 'UserAction.REQUEST_GETALL';
  static REQUEST_User_GETALL_FINISHED = 'UserAction.REQUEST_GETALL_FINISHED';
 
  static requestGetSingle(userId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, UserAction.REQUEST_User_GETSINGLE, UserEffect.requestUserGetSingle, userId);
    };
  }

  static requestPost(user) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, UserAction.REQUEST_User_POST, UserEffect.requestUserPost, user);
    };
  }

  
  static requestUpdate(user) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, UserAction.REQUEST_User_UPDATE, UserEffect.requestUserUpdate, user);
    };
  }

  static requestGetAll(pageNum=1,pageSize=20) {
    return async (dispatch, getState) => {
      await ActionUtility.createThunkEffect(dispatch, UserAction.REQUEST_User_GETALL, UserEffect.requestUserGetAll,pageNum,pageSize);
    };
  }
 
}
