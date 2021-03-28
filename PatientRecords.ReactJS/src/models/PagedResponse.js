import { BaseModel } from 'sjs-base-model';

export default class PagedResponse extends BaseModel {
    pageNumber=0 ;
    pageSize = 0;
    firstPage = '';
    lastPage = '';
    nextPage = '';
    previousPage = '';
    totalRecords=0;
    totalPages=0;
    data=null ;
    succeeded = false;
    errorType = '';
    errorMessage = [];
    constructor(receiveDdata) {
        super();
      
        this.update(receiveDdata);
  }
}
