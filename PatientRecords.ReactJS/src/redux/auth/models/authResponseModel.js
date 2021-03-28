import { BaseModel } from 'sjs-base-model';
import userView from '../../users/models/userView';

export default class AuthResponseModel extends BaseModel {
    id = 0;
    isAuthSuccessful =false;
    token = '';
    errorMessage = '';
    loggedUser =  userView;
    constructor(data) {
      super();
      this.update(data);
    }
  }