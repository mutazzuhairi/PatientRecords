import React, { Component } from 'react'
import {connect} from 'react-redux'
import  './pationtUpdate.scss'
import {withRouter } from "react-router-dom";
import PationtAction from '../../../redux/pationts/pationtAction';
import DatePicker from "react-datepicker";
import {Col,Row,Form,FormGroup,Label,Input,Button, InputGroup} from "reactstrap";
import {SweetAlertPopup} from "../../../utilities/common"
import Moment from 'moment';
import LoadingIndicator from '../../../component/common/loading-indicator/LoadingIndicator';
import {handleValidation} from '../pationtsHelper'
class pationtUpdate  extends Component {
    constructor(props){
        super(props);
   
        this.state = {
            errors: {},
            pationtId:this.props.match.params.id,
            clonePationt:{
                name:'',
                officialId:'',
                email:'',
                dateOfBirth: null,
            },
            isFire:false,
        }
     }
  
     componentDidMount(){
        this.getpationtData();
    }
     
    getpationtData =()=>{
        if(this.state.pationtId){
            this.props.dispatch(PationtAction.requestGetSingle(this.props.match.params.id));
            this.setState({isFire:true});
        }
    }


     setStartDate = (date)=>{
        this.setState({startDate:date});
     }

 
    updatePationtOnSubmit(e){
         e.preventDefault();
         var formValidation = handleValidation(this.state.clonePationt);
         this.setState({errors:formValidation.errors});
         var isFormValid = formValidation.formIsValid;
         if(isFormValid){
            if(this.state.pationtId)
               this.props.dispatch( PationtAction.requestUpdate(JSON.parse(JSON.stringify( this.state.clonePationt))));
           else
               this.props.dispatch( PationtAction.requestPost(JSON.parse(JSON.stringify( this.state.clonePationt))));
               this.setState({isFire:true});
         }else{
            SweetAlertPopup("Missing Data","Please fill form with right data.");
         }
     }


     componentDidUpdate(prevProps, prevState){
        if (!this.props.PationtContext.loading && prevProps.PationtContext.loading){
            if(!this.state.pationtId && !this.props.PationtContext.error){
                this.props.history.push('/Patients');
            }
          }
          if(prevProps.location.key !== this.props.location.key){
            this.setState({pationtId:this.props.match.params.id});
            this.getpationtData();
          }
       }
 
    
     handleChange(field, e){         
         let fields = this.state.clonePationt;
         fields[field] = e.target.value;        
         this.setState({fields});
     }

     handledateOfBirthChange(field, e){         
        let fields = this.state.clonePationt;
        fields[field] = e;        
        this.setState({fields});
    }

    
    goToCreatePage =()=> {
        this.props.history.push('/PatientRecordUpdate/'+this.props.PationtContext.pationt.name+"/"+this.state.pationtId);
    }

    goToStatisticsPage =()=> {
        this.props.history.push('/Statistics/'+this.state.pationtId);
    }

    goToPatientRecords =()=> {
      this.props.history.push('/PatientRecords/'+this.state.pationtId+'/'+this.props.PationtContext.pationt.name);
  }
 
     isObjectChange =()=>{  
        return (this.state.clonePationt!=null && this.props.PationtContext.pationt!=null &&  
               JSON.stringify(this.state.clonePationt) !== JSON.stringify(this.props.PationtContext.pationt))
               || !this.state.pationtId
 
     }


     componentWillReceiveProps(nextProps){
         if(this.state.pationtId && nextProps.PationtContext.pationt?.name){ 
        this.setState({
            clonePationt:JSON.parse(JSON.stringify(nextProps.PationtContext.pationt)),
        })}
    
      }
 
    render() {
        const {id} = this.props.match.params;
        const dateOfBirthselected =this.state.clonePationt  && 
                                   this.state.clonePationt.dateOfBirth? 
                                   Moment(this.state.clonePationt?.dateOfBirth).toDate():
                                   null;
        return (  

            <div className="update-form">
              <LoadingIndicator isActive={this.props.PationtContext.loading && this.state.isFire} />
               <Form className="theme-form" onSubmit= {this.updatePationtOnSubmit.bind(this)}>
                  <Row className="form-header">
                     <Col>
                        <h4> {this.state.clonePationt?.name} {id?(<span> - {id}</span>):(null)} </h4>
                     </Col>
                     <Col> 
                     {this.state.pationtId? <Button  onClick={this.goToStatisticsPage}  color="info btn-pill" className="mr-10">
                     View Statistics
                     </Button> :null} 

                     {this.state.pationtId? <Button  onClick={this.goToPatientRecords}  color="info btn-pill" className="mr-10">
                     View Records
                     </Button> :null} 

                     {this.state.pationtId? <Button  onClick={this.goToCreatePage}  color="info btn-pill" className="mr-10">
                      Create Record
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
                    Name
                </Label>
                  <Col sm="5">
                   <Input
                     className="form-control btn-pill"
                     type="text"
                     value={this.state.clonePationt?.name}
                     onChange={this.handleChange.bind(this, "name")}
                     />
                      <span style={{color: "red"}}>{this.state.errors["name"]}</span>
                   </Col>
                  </FormGroup>

                  <FormGroup className="row">
                  <Label
                     className="col-sm-3 col-form-label"
                     htmlFor="inputName3"
                    >
                   Official Id
                    </Label>
              <Col sm="5">
                <Input
                  className="form-control btn-pill"
                  type="text"
                  value={this.state.clonePationt?.officialId}
                  onChange={this.handleChange.bind(this, "officialId")}
                  />
                  <span style={{color: "red"}}>{this.state.errors["officialId"]}</span>
              </Col>
            </FormGroup>
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputEmail3"
              >
                Email
              </Label>
              <Col sm="5">
                <Input
                  className="form-control btn-pill"
                  type="email"
                  value={this.state.clonePationt?.email}
                  onChange={this.handleChange.bind(this, "email")}
                />
                 <span style={{color: "red"}}>{this.state.errors["email"]}</span>
              </Col>
            </FormGroup>
           <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputPassword3"
              >
                Birth Date
              </Label>
              <Col sm="5">
       
                <DatePicker
                  selected={dateOfBirthselected}
                  onChange={this.handledateOfBirthChange.bind(this, "dateOfBirth")}
                  className="form-control digits"
                  maxDate={new Date()}
                />
                <span style={{color: "red"}}>{this.state.errors["dateOfBirth"]}</span>
              </Col>
            </FormGroup>  
          </Form>
          </div>
         )
    }
}

const mapStateToProps  = (state) => ({PationtContext:state.PationtContext})

export default connect(mapStateToProps)(withRouter(pationtUpdate))