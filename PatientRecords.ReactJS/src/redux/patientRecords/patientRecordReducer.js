import patientRecordAction from './patientRecordAction';
  
const initialState = {
    pationtRecord: null,
    pationtRecords: [],
    loading:true,
    error:false
};
 
export default function(state = initialState, action){
    switch(action.type){
      case patientRecordAction.REQUEST_PATIONTRECORD_POST_FINISHED:
        return {
          ...state,
          pationtRecord: action.payload,
          error: action.error,
          loading:false,
        }
        case patientRecordAction.REQUEST_PATIONTRECORD_UPDATE_FINISHED:
          return {
            ...state,
            pationtRecord: action.payload,
            error: action.error,
            loading:false,
          }
        case patientRecordAction.REQUEST_PATIONTRECORD_GETALL_FINISHED:
        return {
          ...state,
          pationtRecords: action.payload,
          error: action.error,
          loading:false,
        }
        case patientRecordAction.REQUEST_PATIONTRECORD_GETSINGLE_FINISHED:
        return {
          ...state,
          pationtRecord: action.payload,
          error: action.error,
          loading:false,
        }
        default: return initialState
    }

}

 
