import React, { Component } from 'react'
import {connect} from 'react-redux'
import patientRecordAction from '../../redux/patientRecords/patientRecordAction';
import Pagination from "react-js-pagination";
import {Col,Table,Input,Row,Label,Button} from "reactstrap";
import {withRouter } from "react-router-dom";
import  './patientRecords.scss'
import Moment from 'moment';
import LoadingIndicator from '../../component/common/loading-indicator/LoadingIndicator'

class PatientRecords extends Component {
    constructor(props){
        super(props);
        this.state = {
           headers:[
               "Name",
               "Entry",
               "Disease",
               "Description",
               "Bill $",
               "Patient",
               "Edit",
           ],
           pageSize:Math.floor(window.innerHeight/90),
           pageNumber:1,
           searchField:'',
           dateFilter:this.props.match.params.date,
           pationtId:this.props.match.params.pationtId,
           name:this.props.match.params.name,
       };
    
    }
 
    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(prevProps, prevState){
        if (this.state.pageSize !== prevState.pageSize ||
            this.state.pageNumber !== prevState.pageNumber|| 
            this.state.searchField !== prevState.searchField){
                this.refreshList();
          }
          if (prevProps.location.key !== this.props.location.key){
            this.refreshList(Math.floor(window.innerHeight/70),1,'');
          }
    }

    changePageSize =(event) =>{
        this.setState({pageSize:event.target.value});
    }

    goToUpdatePage =(id)=> {
        this.props.history.push('/PatientRecord/'+id);
       }
 
    changePageSearchField =(event) =>{
        this.setState({searchField:event.target.value});
    }

    refreshList =(pageSize=this.state.pageSize,
                  pageNumber=this.state.pageNumber,
                  searchField=this.state.searchField)=>{

        if(this.state.pationtId!=null && this.state.name!=null ) {
            this.props.dispatch(patientRecordAction.requestGetAllfForPatientId(this.state.pationtId,pageNumber,pageSize,searchField));
        }
        else{
            this.props.dispatch(patientRecordAction.requestGetAll(pageNumber,pageSize,searchField,this.props.match.params.date));
        }
    }
 
  
    handlePageChange(pageNumber) {
        this.setState({pageNumber: pageNumber});
      }

   goToPatientPage =(e,patientId)=> {
        e.stopPropagation();
        this.props.history.push('/Patient/'+patientId);
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
              <option disabled selected value>Select size</option>
                <option>10</option>
                <option>20</option>
                <option>50</option>
                <option>100</option>
                <option>150</option>
             </select>

             <h4 style={{color:  `#7E37D8` }}>
             {this.props.match.params.name? <span>Patient Records For  {this.props.match.params.name} </span> 
             : this.props.match.params.date ? <span>Patient Records For  {this.props.match.params.date} </span>
             : "All Patient Records"}     
            </h4>
       
         </Col>
          <Col sm="4">
                 <Input
                       className="form-control justify-search"
                        type="text"
                        placeholder="Start Searching ..."
                        onChange={this.changePageSearchField}
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
                                      <td> {item.bill?.toFixed(2)}</td> 
                                      <td><Button   onClick={(e)=>this.goToPatientPage(e,item.patientId)}  color="info btn-pill" className="float-left patient-button patient-button-padding">
                                           View 
                                           </Button>
                                         </td>
                                      <td><Button onClick={()=> this.goToUpdatePage(item.id)}  color="dark btn-pill" className="float-left patient-button patient-button-padding">
                                           Edit 
                                           </Button>
                                         </td>
                                 </tr>
                             ))}
                        </tbody>
                       </Table>
                      ):( <div></div>)}
                      </div>
                      <div>
                </div>
                 </Col>
               </div>
               <div>
               {pationtRecords.totalRecords?(
             <Pagination
                  activePage={pationtRecords.pageNumber}
                  itemsCountPerPage={pationtRecords.pageSize}
                  totalItemsCount={pationtRecords.totalRecords}
                   pageRangeDisplayed={5}
                 onChange={this.handlePageChange.bind(this)}
               />


                   ):null}
     
      </div>
         
            </div>
            
        )
    }
}

const mapStateToProps  = (state) => ({PationtRecordContext:state.PationtRecordContext})

export default connect(mapStateToProps )(withRouter(PatientRecords))