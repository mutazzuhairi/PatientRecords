import React, { Component } from 'react'
import {connect} from 'react-redux'
import patientRecordAction from '../../redux/patientRecords/patientRecordAction';
import Pagination from "react-js-pagination";
import {Col,Table,Input,Row,Label} from "reactstrap";
import {withRouter } from "react-router-dom";
import  './patientRecords.scss'
import Moment from 'moment';
import LoadingIndicator from '../../component/common/loading-indicator/LoadingIndicator'

class PatientRecords extends Component {
    constructor(props){
        super(props);
        this.state = {
           headers:[
               "Patient",
               "Entry",
               "Disease",
               "Description",
               "Bill",
           ],
           pageSize:Math.floor(window.innerHeight/70),
           pageNumber:1,
       };
    
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(prevProps, prevState){
        if (this.state.pageSize !== prevState.pageSize ||
            this.state.pageNumber !== prevState.pageNumber) {
               this.refreshList();
          }
    }

    changePageSize =(event) =>{
        this.setState({pageSize:event.target.value});
    }

    goToUpdatePage =(id)=> {
        this.props.history.push('/patientRecordUpdate/'+id);
       }
 
 

    refreshList =()=>{
        this.props.dispatch(patientRecordAction.requestGetAll(this.state.pageNumber,this.state.pageSize));
    }
 
  
    handlePageChange(pageNumber) {
        this.setState({pageNumber: pageNumber});
      }


    render() {
        const {pationtRecords,loading} = this.props.PationtRecordContext;
        const {headers} = this.state;

        var paggedData = pationtRecords.data;
        return (
        <div>
       <LoadingIndicator isActive={this.props.PationtRecordContext.loading} />
       <Row>
          <Col sm="8">
          <Label>Page Size: </Label>  
              <select onChange={this.changePageSize} >
              <option disabled defaultValue value>Select size</option>
                <option>10</option>
                <option>20</option>
                <option>50</option>
                <option>100</option>
                <option>150</option>
             </select>
         </Col>
          <Col sm="4">
                 <Input
                       className="form-control justify-search"
                        type="text"
                        placeholder="Start Searching ..."
                      />
                 </Col>
         </Row>     
          <div className="card-block row">
           <Col sm="12" xl="6">
              </Col>
                   <Col className="margin-top-20" sm="12" lg="12" xl="12">
                       <div className="table-responsive">
                             {headers && paggedData ? (
                       <Table>
                         <thead className="thead-light">
                             <tr>
                             {headers.map((item, i) => {  
                            return (
                                <th key={i} scope="col">{item}</th>
                                 )
                             })}
                             </tr>
                        </thead>
                        <tbody>
                            {paggedData.map(item => (
                                 <tr key={item.id} onClick={() => this.goToUpdatePage(item.id)}>
                                      <td> {item.patient?.name}</td> 
                                      <td> {Moment(item.timeOfEntry).format('YYYY-MM-DD HH:mm:ss')}</td> 
                                      <td> {item.diseaseName}</td> 
                                      <td> {item.description}</td> 
                                      <td> {item.bill}</td> 
                                 </tr>
                             ))}
                        </tbody>
                       </Table>
                      ):( <div>Loading ...</div>)}
                      </div>
                      <div>
                </div>
                 </Col>
               </div>
               <div>
        <Pagination
          activePage={pationtRecords.pageNumber}
          itemsCountPerPage={pationtRecords.pageSize}
          totalItemsCount={pationtRecords.totalRecords}
          pageRangeDisplayed={5}
          onChange={this.handlePageChange.bind(this)}
        />
      </div>
         
            </div>
            
        )
    }
}

const mapStateToProps  = (state) => ({PationtRecordContext:state.PationtRecordContext})

export default connect(mapStateToProps )(withRouter(PatientRecords))