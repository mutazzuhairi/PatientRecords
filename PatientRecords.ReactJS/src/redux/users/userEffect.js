import EffectUtility from '../../utilities/EffectUtility';
import PagedResponse from '../../models/PagedResponse'
import UserDTO from './models/userView';


export default class UserEffect {

  static apiurl = process.env.REACT_APP_API_URL+`/User`;
  
  static async requestUserGetSingle(userId) {
    console.log(process.env.REACT_APP_API_URL);

    const endpoint = UserEffect.apiurl+"/"+userId;

    return EffectUtility.getToModel(UserDTO, endpoint);
  }

  static async requestUserPost(user) {
    console.log(process.env.REACT_APP_API_URL);
    const endpoint = UserEffect.apiurl;
    return EffectUtility.postToModel(UserDTO, endpoint,user);
  }

  static async requestUserUpdate(user) {
    console.log(process.env.REACT_APP_API_URL);
    const endpoint = UserEffect.apiurl;
    return EffectUtility.putToModel(UserDTO, endpoint,user);
  }

  static async requestUserGetAll(pageSize,pageNum,searchField) {
    const endpoint = UserEffect.apiurl+"View?PageSize="+pageSize+"&PageNumber="+pageNum+"&SearchField="+searchField;

    return EffectUtility.getToModel(PagedResponse, endpoint);
  }

 
}
