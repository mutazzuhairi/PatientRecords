import PatientStatisticsAction from './PatientStatisticsAction';
 
const initialState = {
    NameAndAge: null,
    AverageOfBillsRemovingOutliers: 0,
    AverageOfBills: 0,
    GET5thRecordEntryOfPatient:[],
    PatientsWithSimilarDiseases:[],
    MonthContainsHighestNumberOfVisits:'',
    loading:true,
    error:false
};
 
export default function(state = initialState, action){
    switch(action.type){
      case PatientStatisticsAction.REQUEST_PATIONT_GETNameAndAge_FINISHED:
        return {
          ...state,
          NameAndAge: action.payload,
          error: action.error,
          loading:false,
        }
        case PatientStatisticsAction.REQUEST_PATIONT_GETAverageOfBillsRemovingOutliers_FINISHED:
          return {
            ...state,
            AverageOfBillsRemovingOutliers: action.payload,
            error: action.error,
            loading:false,
          }
        case PatientStatisticsAction.REQUEST_PATIONT_GETAverageOfBills_FINISHED:
        return {
          ...state,
          AverageOfBills: action.payload,
          error: action.error,
          loading:false,
        }
        case PatientStatisticsAction.REQUEST_PATIONT_GET5thRecordEntryOfPatient_FINISHED:
        return {
          ...state,
          GET5thRecordEntryOfPatient: action.payload,
          error: action.error,
          loading:false,
        }
        case PatientStatisticsAction.REQUEST_PATIONT_GETPatientsWithSimilarDiseases_FINISHED:
          return {
            ...state,
            PatientsWithSimilarDiseases: action.payload,
            error: action.error,
            loading:false,
          }
          case PatientStatisticsAction.REQUEST_PATIONT_GETMonthContainsHighestNumberOfVisits_FINISHED:
            return {
              ...state,
              MonthContainsHighestNumberOfVisits: action.payload,
              error: action.error,
              loading:false,
            }
        default: return initialState
    }

}

 