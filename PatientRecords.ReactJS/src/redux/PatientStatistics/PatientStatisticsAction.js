import PatientStatisticsEffect from './PatientStatisticsEffect';
import ActionUtility from '../../utilities/ActionUtility';


export default class PatientStatisticsAction {
  static REQUEST_PATIONT_GETNameAndAge = 'PatientStatisticsAction.REQUEST_GETNameAndAge';
  static REQUEST_PATIONT_GETNameAndAge_FINISHED = 'PatientStatisticsAction.REQUEST_GETNameAndAge_FINISHED';

  static REQUEST_PATIONT_GETAverageOfBillsRemovingOutliers = 'PatientStatisticsAction.REQUEST_GETAverageOfBillsRemovingOutliers';
  static REQUEST_PATIONT_GETAverageOfBillsRemovingOutliers_FINISHED = 'PatientStatisticsAction.REQUEST_GETAverageOfBillsRemovingOutliers_FINISHED';

  static REQUEST_PATIONT_GETAverageOfBills= 'PatientStatisticsAction.REQUEST_GETAverageOfBills';
  static REQUEST_PATIONT_GETAverageOfBills_FINISHED = 'PatientStatisticsAction.REQUEST_GETAverageOfBills_FINISHED';

  static REQUEST_PATIONT_GET5thRecordEntryOfPatient = 'PatientStatisticsAction.REQUEST_GET5thRecordEntryOfPatient';
  static REQUEST_PATIONT_GET5thRecordEntryOfPatient_FINISHED = 'PatientStatisticsAction.REQUEST_GET5thRecordEntryOfPatient_FINISHED';

  static REQUEST_PATIONT_GETPatientsWithSimilarDiseases = 'PatientStatisticsAction.REQUEST_GETPatientsWithSimilarDiseases';
  static REQUEST_PATIONT_GETPatientsWithSimilarDiseases_FINISHED = 'PatientStatisticsAction.REQUEST_GETPatientsWithSimilarDiseases_FINISHED';

  static REQUEST_PATIONT_GETMonthContainsHighestNumberOfVisits = 'PatientStatisticsAction.REQUEST_GETMonthContainsHighestNumberOfVisits';
  static REQUEST_PATIONT_GETMonthContainsHighestNumberOfVisits_FINISHED = 'PatientStatisticsAction.REQUEST_GETMonthContainsHighestNumberOfVisits_FINISHED';
 

  static requestGetNameAndAge(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PatientStatisticsAction.REQUEST_PATIONT_GETNameAndAge, 
                                                      PatientStatisticsEffect.REQUEST_GETNameAndAge, patientId);
    };
  }

  
  static requestGetAverageOfBillsRemovingOutliers(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PatientStatisticsAction.REQUEST_PATIONT_GETAverageOfBillsRemovingOutliers, 
                                                       PatientStatisticsEffect.REQUEST_GETAverageOfBillsRemovingOutliers, patientId);
    };
  }


  static requestGetAverageOfBills(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PatientStatisticsAction.REQUEST_PATIONT_GETAverageOfBills, 
                                                       PatientStatisticsEffect.REQUEST_GETAverageOfBills, patientId);
    };
  }


  static requestGet5thRecordEntryOfPatient(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PatientStatisticsAction.REQUEST_PATIONT_GET5thRecordEntryOfPatient, 
                                                       PatientStatisticsEffect.REQUEST_GET5thRecordEntryOfPatient, patientId);
    };
  }


  static requestGetPatientsWithSimilarDiseases(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PatientStatisticsAction.REQUEST_PATIONT_GETPatientsWithSimilarDiseases, 
                                                      PatientStatisticsEffect.REQUEST_GETPatientsWithSimilarDiseases, patientId);
    };
  }


  static requestGetMonthContainsHighestNumberOfVisits(patientId) {
    return async (dispatch, getState) => {
     await ActionUtility.createThunkEffect(dispatch, PatientStatisticsAction.REQUEST_PATIONT_GETMonthContainsHighestNumberOfVisits, 
                                                       PatientStatisticsEffect.REQUEST_GETMonthContainsHighestNumberOfVisits, patientId);
    };
  }
 
}
