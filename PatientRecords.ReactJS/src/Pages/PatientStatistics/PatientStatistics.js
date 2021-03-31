import PatientStatisticsAction from '../../redux/PatientStatistics/PatientStatisticsAction'
import React, { Component } from 'react'
import {connect} from 'react-redux'
import {withRouter } from "react-router-dom";
import Moment from 'moment';
import LoadingIndicator from '../../component/common/loading-indicator/LoadingIndicator';
import  './PatientStatistics.scss'
import {Col,Table,CardBody,Row,Card,CardHeader,Container} from "reactstrap";
class PatientStatistics   extends Component {
    constructor(props){
        super(props);
   
        this.state = {
            errors: {},
            pationtId:this.props.match.params.id,
        }
     }
  
     componentDidMount(){
        //this.getpationtData();
    }
     
    getPatientData =()=>{
            this.props.dispatch(PatientStatisticsAction.requestGetNameAndAge(this.state.pationtId));
            this.props.dispatch(PatientStatisticsAction.requestGetAverageOfBillsRemovingOutliers(this.state.pationtId));
            this.props.dispatch(PatientStatisticsAction.requestGetAverageOfBills(this.state.pationtId));
            this.props.dispatch(PatientStatisticsAction.requestGet5thRecordEntryOfPatient(this.state.pationtId));
            this.props.dispatch(PatientStatisticsAction.requestGetPatientsWithSimilarDiseases(this.state.pationtId));
            this.props.dispatch(PatientStatisticsAction.requestGetMonthContainsHighestNumberOfVisits(this.state.pationtId));
    }
 
    
    componentDidMount(){
        this.getPatientData();
    }

    componentDidUpdate(prevProps, prevState){
        if (this.state.pageSize !== prevState.pageSize ||
            this.state.pageNumber !== prevState.pageNumber) {
               this.getPatientData();
          }
    }

  
    
        
    render() {
          
        const context = this.props.PatientStatisticsContext;
        const {NameAndAge,
               AverageOfBillsRemovingOutliers,
               AverageOfBills,
               MonthContainsHighestNumberOfVisits,
               PatientsWithSimilarDiseases,
               GET5thRecordEntryOfPatient
            } = context;
      
        return (  
            <div>

<Container fluid={true}>
        <Row>
          <Col sm="12">
            <Card>
              <CardHeader>

 
                <h5 className="patient-name">  {NameAndAge?.map((item, i) => {  
                            return (
                                      <span >{item.Name} {item.Age && item.Age >0? (<span> - {item.Age} years</span>):(null)} </span>
                                 )
                             })}
                 </h5>
                    
                  
                             
 
                
              </CardHeader>
              <CardBody className="typography">
                <Row>
                  <Col sm="12" xl="6">
        
                    <h5>Average of bills: </h5>
                    <h5>Average of bills removing outliers: </h5>
                    <h5>Highest number of visits (Month): </h5>
                    <h5>5th record entry of patient: </h5>
                  </Col>
                  <Col sm="12" xl="6">
                  <h5>{AverageOfBills!=0? AverageOfBills?.map((item, i) => {  
                            return (
                                <div className="report-data">{ !isNaN(item.AverageOfBills)?item.AverageOfBills:0} $</div>
                                 )
                             }):null} </h5>

                     <h5>
                        {AverageOfBillsRemovingOutliers!=0? AverageOfBillsRemovingOutliers?.map((item, i) => {  
                            return (
                                      <div className="report-data">{ !isNaN(item.AverageOfBills)?item.AverageOfBills:0} $</div>
                                 )
                             }):null}</h5>

                       <h5>
                       {MonthContainsHighestNumberOfVisits!=''? MonthContainsHighestNumberOfVisits?.map((item, i) => {  
                            return (
                                      <div className="report-data">{item.MonthName}</div>
                                 )
                             }):null}</h5>
                  </Col>



                </Row>

                <Row>
                  <Col sm="12">
                  <div className="th-record">
                    <Table>
                         <thead className="thead-light">
                             <tr>
                                 <th>DiseaseName</th>
                                 <th>Description</th>
                                 <th>Entry</th>
                                 <th>Bill</th>
                             </tr>
                        </thead>
                        <tbody>

                          {GET5thRecordEntryOfPatient!=null?GET5thRecordEntryOfPatient.map((item, i) => {  
                            return (
                               <tr key={item.id} >
                                <td> {item.DiseaseName}</td> 
                                <td> {item.Description}</td> 
                                <td> {Moment(item.TimeOfEntry).format('YYYY-MM-DD')}</td> 
                                <td> {item.Bill}</td> 
                              </tr>                                      
                                 )
                             }):null}
 
                        </tbody>
                       </Table>
                    </div>
                  </Col>
 

               </Row>


               <Row className="th-record">
                  <Col sm="12" xl="6">
                  <h5>List of other patients with similar diseases: </h5>
                  </Col>

                  <Col sm="12" xl="6">
                   </Col>

               </Row>

               <Row>
                  <Col sm="12">
                  <div className="th-record">
                    <Table>
                         <thead className="thead-light">
                             <tr>
                                 <th>Name</th>
                                 <th>Email</th>
                                 <th>Official Id</th>
                             </tr>
                        </thead>
                        <tbody>
   

                        {PatientsWithSimilarDiseases!=null?PatientsWithSimilarDiseases?.map((item, i) => {  
                            return (
                                <tr key={item.OfficialId} >
                                <td> {item.Name}</td> 
                                <td> {item.Email}</td> 
                                <td> {item.OfficialId}</td> 
                              </tr>  
                                 )
                             }):null}

                        </tbody>
                       </Table>
                    </div>
                  </Col>
 

               </Row>
            
                  
              </CardBody>
            </Card>
          </Col>

          </Row>

        </Container>

 
                
              <LoadingIndicator isActive={this.props.PatientStatisticsContext.loading} />
          </div>
         )
    }
}

const mapStateToProps  = (state) => ({PatientStatisticsContext:state.PatientStatisticsContext})

export default connect(mapStateToProps)(withRouter(PatientStatistics))