import UserAction from "./userAction";
import PationtAction from '../pationts/pationtAction';

const initialState = {
    user: null,
    users: [],
    loading:true,
    error:false
};
 
export default function(state = initialState, action){
    switch(action.type){
      case UserAction.REQUEST_User_UPDATE_FINISHED:
        return {
          ...state,
          user: action.payload,
          error: action.error,
          loading:false,
        }
        case UserAction.REQUEST_User_POST_FINISHED:
        return {
          ...state,
          user: action.payload,
          error: action.error,
          loading:false,
        }
        case UserAction.REQUEST_User_GETALL_FINISHED:
        return {
          ...state,
          users: action.payload,
          error: action.error,
          loading:false,
        }
        case UserAction.REQUEST_User_GETSINGLE_FINISHED:
        return {
          ...state,
          user: action.payload,
          error: action.error,
          loading:false,
        }
        case PationtAction.REQUEST_HEADER_GETALL:
        case PationtAction.REQUEST_HEADER_GETALL_FINISHED:
            return state

        default: return initialState
    }

}

 