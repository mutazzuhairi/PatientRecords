import patientRecordAction from './patientRecordAction';
import PationtAction from '../pationts/pationtAction';

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
        case patientRecordAction.REQUEST_PATIONTRECORD_GETALL_PATIENTID_FINISHED:
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

        case PationtAction.REQUEST_HEADER_GETALL:
        case PationtAction.REQUEST_HEADER_GETALL_FINISHED:
        return state
        
        default: return initialState
    }

}

 
