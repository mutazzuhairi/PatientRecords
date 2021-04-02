import React, { Component } from 'react'
import {connect} from 'react-redux'
import  './userUpdate.scss'
import {withRouter } from "react-router-dom";
import userAction from '../../../redux/users/userAction';
import {Col,Row,Form,FormGroup,Label,Input,Button} from "reactstrap";
import {SweetAlertPopup} from "../../../utilities/common"
import LoadingIndicator from '../../../component/common/loading-indicator/LoadingIndicator';
import {handleValidation} from '../userHelper'

class UserUpdate  extends Component {
    constructor(props){
        super(props);
   
        this.state = {
            errors: {},
            userId:this.props.match.params.id,
            cloneUser:{
                firstName:'',
                lastName:'',
                userName:'',
                email:'',
                
            },
        }
     }
 
     componentDidMount(){
        this.getUserData();
    }
     
    getUserData =()=>{
        if(this.state.userId){
            this.props.dispatch(userAction.requestGetSingle(this.state.userId));
        }
    }

  
     
    updateUserOnSubmit(e){
         e.preventDefault();
         var formValidation = handleValidation(this.state.cloneUser);
         this.setState({errors:formValidation.errors});
         var isFormValid = formValidation.formIsValid;
         if(isFormValid){
             if(this.state.userId)
                this.props.dispatch( userAction.requestUpdate(JSON.parse(JSON.stringify(this.state.cloneUser))));
             else
             this.props.dispatch( userAction.requestPost(JSON.parse(JSON.stringify(this.state.cloneUser))));
         }else{
            SweetAlertPopup("Missing Data","Please fill form with right data.");
         }
     }
 
 

     
     handleChange(field, e){         
         let fields = this.state.cloneUser;
         fields[field] = e.target.value;        
         this.setState({fields});
     }


     isObjectChange =()=>{  
        return (this.state.cloneUser!=null && this.props.UserContext.user!=null &&    
               JSON.stringify(this.state.cloneUser) !== JSON.stringify(this.props.UserContext.user))||
               !this.state.userId
 
     }


     componentWillReceiveProps(nextProps){
         if(this.state.userId){
            this.setState({
                cloneUser:JSON.parse(JSON.stringify(nextProps.UserContext.user)),
            })
         }
      }
 
    render() {
        const {id} = this.props.match.params;
  
        return (  

            <div className="update-form">
                            <LoadingIndicator isActive={this.props.UserContext.loading} />

            <Form className="theme-form" onSubmit= {this.updateUserOnSubmit.bind(this)}>
           <Row className="form-header">
               <Col>
               <h4> {this.state.cloneUser?.userName} - {id} </h4>
               </Col>
               <Col>    

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
                First Name
              </Label>
              <Col sm="5">
                {/* <Input
                  className="form-control btn-pill"
                  type="text"
                  placeholder="Name"
                  value={this.state.cloneUser?.firstName}
                  onChange={this.handleChange.bind(this, "firstName")}
                  disabled
                  />
                  <span style={{color: "red"}}>{this.state.errors["firstName"]}</span> */}
                  <h5>{this.state.cloneUser?.firstName}</h5>
              </Col>
            </FormGroup>
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputName3"
              >
                Last Name
              </Label>
              <Col sm="5">
                {/* <Input
                  className="form-control btn-pill"
                  type="text"
                  placeholder="Name"
                  value={this.state.cloneUser?.lastName}
                  onChange={this.handleChange.bind(this, "lastName")}
                  disabled
                  />
                  <span style={{color: "red"}}>{this.state.errors["lastName"]}</span> */}
                  <h5>{this.state.cloneUser?.lastName}</h5>
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
                {/* <Input
                  className="form-control btn-pill"
                  type="email"
                  placeholder="Email"
                  value={this.state.cloneUser?.email}
                  onChange={this.handleChange.bind(this, "email")}
                  disabled
                />
                 <span style={{color: "red"}}>{this.state.errors["email"]}</span> */}
                 <h5>{this.state.cloneUser?.email}</h5>

              </Col>
            </FormGroup>
         
            <FormGroup className="row">
              <Label
                className="col-sm-3 col-form-label"
                htmlFor="inputOfficialId3"
              >
                User Name
              </Label>
              <Col sm="5">
                {/* <Input
                  className="form-control btn-pill"
                  type="text"
                  placeholder="userName"
                  value={this.state.cloneUser?.userName}
                  onChange={this.handleChange.bind(this, "userName")}
                  disabled
                />
                 <span style={{color: "red"}}>{this.state.errors["userName"]}</span> */}
                 <h5>{this.state.cloneUser?.userName}</h5>

              </Col>
            </FormGroup>
        
          </Form>
          </div>
         )
    }
}

const mapStateToProps  = (state) => ({UserContext:state.UserContext})

export default connect(mapStateToProps)(withRouter(UserUpdate))