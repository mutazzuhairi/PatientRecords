import PationtAction from './pationtAction';
 
const initialState = {
    pationt: null,
    pationts: [],
    headerPationts:[],
    headerLoading:false,
    loading:true,
    error:false
};
 
export default function(state = initialState, action){
    switch(action.type){
      case PationtAction.REQUEST_PATIONT_POST_FINISHED:
        return {
          ...state,
          pationt: action.payload,
          error: action.error,
          loading:false,
        }
        case PationtAction.REQUEST_PATIONT_UPDATE_FINISHED:
          return {
            ...state,
            pationt: action.payload,
            error: action.error,
            loading:false,
          }
        case PationtAction.REQUEST_PATIONT_GETALL_FINISHED:
        return {
          ...state,
          pationts: action.payload,
          error: action.error,
          loading:false,
        }
        case PationtAction.REQUEST_PATIONT_GETSINGLE_FINISHED:
        return {
          ...state,
          pationt: action.payload,
          error: action.error,
          loading:false,
        }
        case PationtAction.REQUEST_HEADER_GETALL_FINISHED:
          return {
            ...state,
            headerPationts: action.payload,
            error: action.error,
            headerLoading:false,
          }
      case PationtAction.REQUEST_HEADER_GETALL:
          return {
            ...state,
            headerPationts:[],
            headerLoading:true,
          }
 
        default: return initialState
    }

}

 