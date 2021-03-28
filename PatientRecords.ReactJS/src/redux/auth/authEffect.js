import EffectUtility from '../../utilities/EffectUtility';
import AuthResponseModel from './models/authResponseModel';

export default class authEffect {

  static apiurl = process.env.REACT_APP_API_URL+'/Authentication/Login';
 
  static async requestPationtRecordPost(Loginauth) {
    const endpoint = authEffect.apiurl;
    return EffectUtility.postToModel(AuthResponseModel, endpoint,Loginauth);
  }
 
}
