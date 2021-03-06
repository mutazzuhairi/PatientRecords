import React, { Component } from 'react'
import {connect} from 'react-redux'
import  './patientRecordUpdate.scss'
import {withRouter } from "react-router-dom";
import patientRecordAction from '../../../redux/patientRecords/patientRecordAction';
import DatePicker from "react-datepicker";
import {Col,Row,Form,FormGroup,Label,Input,Button,TextA} from "reactstrap";
import {SweetAlertPopup} from "../../../utilities/common"
import Moment from 'moment';
import LoadingIndicator from '../../../component/common/loading-indicator/LoadingIndicator';
import {handleValidation} from '../patientRecordHelper'

class PatientRecordUpdate  extends Component {
    constructor(props){
        super(props);
   
        this.state = {
            errors: {},
            pationtRecordId:this.props.match.params.id,
            clonePationtRecord:{
                diseaseName:'',
                description:'',
                timeOfEntry: new Date(),
                bill:'',
                patientId:this.props.match.params.pationtid,
                isFire:false,
            },
            name:this.props.match.params.pationtname,

        }
     }
  
     componentDidMount(){
        this.getpationtData();
    }
     
    getpationtData =()=>{
           if(this.state.pationtRecordId){
            this.props.dispatch(patientRecordAction.requestGetSingle(this.state.pationtRecordId));
            this.setState({isFire:true});
           }
    }


     setStartDate = (date)=>{
        this.setState({startDate:date});
     }

 
     
    updatePationtOnSubmit(e){
         e.preventDefault();
         var formValidation =handleValidation(this.state.clonePationtRecord);
         this.setState({errors:formValidation.errors});
         var isFormValid = formValidation.formIsValid;
         if(isFormValid){
            if(this.state.pationtRecordId){
                this.props.dispatch( patientRecordAction.requestUpdate(JSON.parse(JSON.stringify(this.state.clonePationtRecord))));
            }
            else
            this.props.dispatch( patientRecordAction.requestPost(JSON.parse(JSON.stringify(this.state.clonePationtRecord))));
            this.setState({isFire:true});
         }else{
            SweetAlertPopup("Missing Data","Please fill form with right data.");
         }
 
     }
     
 
     handleChange(field, e){         
         let fields = this.state.clonePationtRecord;
         fields[field] = e.target.value;        
         this.setState({fields});
     }

     handledateOfBirthChange(field, e){         
        let fields = this.state.clonePationtRecord;
        fields[field] = e;        
        this.setState({fields});
    }


    componentDidUpdate(prevProps, prevState){
        if (!this.props.PationtRecordContext.loading && prevProps.PationtRecordContext.loading){
            if(!this.state.pationtRecordId && !this.props.PationtRecordContext.error){
                this.props.history.push('/PatientRecords');
            }
          }
       }


     isObjectChange =()=>{  
        return (this.state.clonePationtRecord!=null && this.props.PationtRecordContext.pationtRecord!=null &&
               JSON.stringify(this.state.clonePationtRecord) !== JSON.stringify(this.props.PationtRecordContext.pationtRecord))
               || !this.state.pationtRecordId
 
     }


     componentWillReceiveProps(nextProps){
         if(this.state.pationtRecordId && nextProps.PationtRecordContext.pationtRecord?.diseaseName){
            this.setState({
                clonePationtRecord:JSON.parse(JSON.stringify(nextProps.PationtRecordContext.pationtRecord)),
            })
         }
      
      }
      goToPatientPage =()=> {
        this.props.history.push('/Patient/'+this.props.PationtRecordContext.pationtRecord.patientId);
    }

    render() {
        const {id} = this.props.match.params;
        const timeOfEntryselected =this.state.clonePationtRecord  && 
                                   this.state.clonePationtRecord.timeOfEntry? 
                                   Moment(this.state.clonePationtRecord?.timeOfEntry).toDate():
                                   null;
        return (  

            <div className="update-form">
                <LoadingIndicator isActive={this.props.PationtRecordContext.loading && this.state.isFire} />
            <Form className="theme-form" onSubmit= {this.updatePationtOnSubmit.bind(this)}>
           <Row className="form-header"> 
               <Col>
                    <h4> {this.state.name?this.state.name:this.state.clonePationtRecord?.patient?.name}   {id?(<span> - {id}</span>):(null)} </h4>
               </Col>
            <Col>  
               {this.state.pationtRecordId? <Button  onClick={this.goToPatientPage}  color="info btn-pill" className="mr-10">
                      View Patient
                     </Button> :null}  
               {this.isObjectChange()? <Button  type="submit" color="info btn-pill" className="mr-1 float-right">
                      Save
                </Button> :null}
           </Col>
           </Row> 
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputName3"
              >
                 Patient
              </Label>
              <Col sm="5">
                <h5>{this.state.name?this.state.name:this.state.clonePationtRecord?.patient?.name}</h5>
              </Col>
            </FormGroup>
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputName3"
              >
               Disease Name
              </Label>
              <Col sm="5">
                <Input
                  className="form-control btn-pill"
                  type="text"
                  value={this.state.clonePationtRecord?.diseaseName}
                  onChange={this.handleChange.bind(this, "diseaseName")}
                  />
                  <span style={{color: "red"}}>{this.state.errors["diseaseName"]}</span>
              </Col>
            </FormGroup>
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputEmail3"
              >
                Description
              </Label>
              <Col sm="5">
                <textarea
                  style={{color:"#a7a2a2"}}
                  className="form-control btn-pill"
                  rows="5"
                  cols="5"
                  type="text"
                  value={this.state.clonePationtRecord?.description}
                  onChange={this.handleChange.bind(this, "description")}
                />
                 <span style={{color: "red"}}>{this.state.errors["description"]}</span>
              </Col>
            </FormGroup>
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputEmail3"
              >
                Bill
              </Label>
              <Col sm="5">
                <Input
                  className="form-control digits"
                  type="number"
                  value={this.state.clonePationtRecord?.bill}
                  onChange={this.handleChange.bind(this, "bill")}
                />
                 <span style={{color: "red"}}>{this.state.errors["bill"]}</span>
              </Col>
            </FormGroup>

           <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputPassword3"
              >
                Time Of Entry
              </Label>
              <Col sm="5">
                <DatePicker
                  selected={timeOfEntryselected}
                  dateFormat="Pp"
                  onChange={this.handledateOfBirthChange.bind(this, "timeOfEntry")}
                  showTimeSelect
                  showPopperArrow={false}
                  className="form-control digits"
                />
                <span style={{color: "red"}}>{this.state.errors["timeOfEntry"]}</span>
              </Col>
            </FormGroup>  
          </Form>
          </div>
         )
    }
}

const mapStateToProps  = (state) => ({PationtRecordContext:state.PationtRecordContext})

export default connect(mapStateToProps)(withRouter(PatientRecordUpdate))