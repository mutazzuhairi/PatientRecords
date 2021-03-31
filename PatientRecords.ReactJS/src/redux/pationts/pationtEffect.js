import PationtDTO from './models/pationtDTO';
import EffectUtility from '../../utilities/EffectUtility';
import PagedResponse from '../../models/PagedResponse'

export default class PationtEffect {

  static apiurl = process.env.REACT_APP_API_URL+'/Patient';
  
  static async requestPationtGetSingle(pationtId) {

    const endpoint = PationtEffect.apiurl+"/"+pationtId;

    return EffectUtility.getToModel(PationtDTO, endpoint);
  }


  static async requestPationtPost(pationt) {
    const endpoint = PationtEffect.apiurl;
    return EffectUtility.postToModel(PationtDTO, endpoint, pationt);
  }

  static async requestPationtUpdate(pationt) {
    const endpoint = PationtEffect.apiurl;
    return EffectUtility.putToModel(PationtDTO, endpoint, pationt);
  }

  static async requestPationtGetAll(pageNum,pageSize,searchField,dateFilter) {
    const endpoint = PationtEffect.apiurl+"view?PageSize="+pageSize+"&PageNumber="+pageNum+"&SearchField="+searchField+"&DateFilter="+dateFilter;

    return EffectUtility.getToModel(PagedResponse, endpoint);
  }

 
}
