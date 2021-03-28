import EffectUtility from '../../utilities/EffectUtility';
 
export default class PatientStatisticsEffect {

  static apiurl = process.env.REACT_APP_API_URL+'/PatientStatistic';
  

  static async REQUEST_GETNameAndAge(pationtId){
    return PatientStatisticsEffect.requestPationtGetSingle("NameAndAge",pationtId);
  }


  static async REQUEST_GETAverageOfBillsRemovingOutliers(pationtId){
    return PatientStatisticsEffect.requestPationtGetSingle("AverageOfBillsRemovingOutliers",pationtId);
}


static async REQUEST_GETAverageOfBills(pationtId){
  return PatientStatisticsEffect.requestPationtGetSingle("AverageOfBills",pationtId);
}

static async REQUEST_GET5thRecordEntryOfPatient(pationtId){
  return  PatientStatisticsEffect.requestPationtGetSingle("5thRecordEntryOfPatient",pationtId);
}


static async REQUEST_GETPatientsWithSimilarDiseases(pationtId){
  return  PatientStatisticsEffect.requestPationtGetSingle("PatientsWithSimilarDiseases",pationtId);
}

static async REQUEST_GETMonthContainsHighestNumberOfVisits(pationtId){
  return PatientStatisticsEffect.requestPationtGetSingle("MonthContainsHighestNumberOfVisits",pationtId);
}


  static async requestPationtGetSingle(endPointAction,pationtId) {
    const endpoint = PatientStatisticsEffect.apiurl+"/"+endPointAction+"/"+pationtId;
    return EffectUtility.getToModel(Object, endpoint);
  }

 

 
}
