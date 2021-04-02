import authAction from './authAction';
 
const initialState = {
    loogedUsser: null,
    loading:true,
    error:false
};
 
export default function(state = initialState, action){
    switch(action.type){
      case authAction.REQUEST_AUTH_POST_LOGIN_FINISHED:
        return {
          ...state,
          loogedUsser: action.payload,
          error: action.error,
          loading:false,
        }
        default: return state
    }

}

 