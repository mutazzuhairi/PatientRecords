import React, { Component } from 'react'
import {connect} from 'react-redux'
import pationtAction from '../../redux/pationts/pationtAction';
import Pagination from "react-js-pagination";
import {Col,Table,Input,Row,Label,Button} from "reactstrap";
import {withRouter } from "react-router-dom";
import  './pationts.scss'
import Moment from 'moment';
import LoadingIndicator from '../../component/common/loading-indicator/LoadingIndicator'
class Pationts extends  Component   {
    constructor(props){
        super(props);
        this.state = {
           headers:[
               "Name",
               "Official Id",
               "Birth",
               "Email",
               "Last Entry",
               "Statistics",
               "Records",
               "Edit",
           ],
           pageSize:Math.floor(window.innerHeight/90),
           pageNumber:1,
           searchField:'',
           lastEntryShow:false,
           statisticShow:false,
           dateFilter:this.props.match.params.date,
       };
    
    }

    changePageSearchField =(event) =>{
        this.setState({searchField:event.target.value});
    }
    handleClose=()=>{
        this.setState({lastEntryShow:false});
    }

    handleShow=()=>{
        this.setState({lastEntryShow:true});
    }
 
 
    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(prevProps, prevState){
        if (prevProps.location.key !== this.props.location.key||
            this.state.pageSize !== prevState.pageSize ||
            this.state.pageNumber !== prevState.pageNumber|| 
            this.state.searchField !== prevState.searchField){
               this.refreshList();
          }
    }

    changePageSize =(event) =>{
        this.setState({pageSize:event.target.value});
    }

    goToCreatePage =()=> {
        this.props.history.push('/Patient');
       }
    goToUpdatePage =(e,id)=> {
        if(e){
            e.stopPropagation();
        }
       this.props.history.push('/Patient/'+id);
   }

    refreshList =()=>{
        this.props.dispatch(pationtAction.requestGetAll(this.state.pageNumber,this.state.pageSize,this.state.searchField,this.state.dateFilter));
    }
 
 
    handlePageChange(pageNumber) {
        this.setState({pageNumber: pageNumber});
      }

   goToStatisticsPage =(e,id)=> {
        e.stopPropagation();
        this.props.history.push('/Statistics/'+id);
    }

    goToPatientRecords =(e,id,name)=> {
        e.stopPropagation();
        this.props.history.push('/PatientRecords/'+name+'/'+id);
    }

    render() {
        const {pationts,loading} = this.props.PationtContext;
        const {headers} = this.state;

        var paggedData = pationts.data;
 
        return (
        <div>
       <LoadingIndicator isActive={this.props.PationtContext.loading} />
       <Row>
          <Col sm="3">
          <Label>Page Size: </Label>  
              <select onChange={this.changePageSize}>
              <option disabled selected value>Select size</option>
                <option>10</option>
                <option>20</option>
                <option>50</option>
                <option>100</option>
                <option>150</option>
             </select>
             <h4 style={{color:  `#7E37D8` }}>
             {this.props.match.params.date ? <span>Patients For {this.props.match.params.date} </span>
             : "All Patients"}     
            </h4>
         </Col>
         <Col sm="6">
             <Button onClick={this.goToCreatePage} color="info">New Pationt</Button>
         </Col>
          <Col sm="3">
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
                                <th className="patient-button" key={i} scope="col">{item}</th>
                                 )
                             })}
                             </tr>
                        </thead>
                        <tbody>
                            {paggedData.map(item => (
                               
                     
                               <tr key={item.officialId} onClick={() => this.goToUpdatePage(null,item.id)} >
                                      <td> {item.name}</td> 
                                      <td> {item.officialId}</td> 
                                      <td> {item.dateOfBirth? Moment(item.dateOfBirth).format('YYYY-MM-DD'):null}</td> 
                                      <td> {item.email}</td> 
                                      <td> {item.lastEntry?.timeOfEntry? Moment(item.lastEntry?.timeOfEntry).format('YYYY-MM-DD HH:mm:ss'):null}</td> 
                                      <td><Button   onClick={(e)=>this.goToStatisticsPage(e,item.id)}  color="info btn-pill" className="float-left patient-button patient-button-padding">
                                           View 
                                           </Button>
                                         </td>
                                      <td><Button   onClick={(e)=>this.goToPatientRecords(e,item.id,item.name)}  color="info btn-pill" className="float-left patient-button patient-button-padding">
                                           View 
                                           </Button>
                                         </td>
                                      <td><Button onClick={(e) => this.goToUpdatePage(e,item.id)}  color="dark btn-pill" className="float-left patient-button patient-button-padding">
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
        <Pagination
          activePage={pationts.pageNumber}
          itemsCountPerPage={pationts.pageSize}
          totalItemsCount={pationts.totalRecords}
          pageRangeDisplayed={5}
          onChange={this.handlePageChange.bind(this)}
        />
      </div>
         
            </div>
            
        )
    }
}

const mapStateToProps  = (state) => ({PationtContext:state.PationtContext})

export default connect(mapStateToProps )(withRouter(Pationts))