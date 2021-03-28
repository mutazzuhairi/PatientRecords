import authAction from '../../../redux/auth/authAction'
import React, { Component } from 'react'
import {connect} from 'react-redux'
import {withRouter } from "react-router-dom";
import {Container,Row,Col,CardBody,Form,FormGroup,Input,Label,Button,} from "reactstrap";
import  './login.scss'
 

class Login extends Component {
    constructor(props){
        super(props);
   
        this.state = {
            errors: {},
            password:'',
            email:'',
            loading:false,
        }
     }
   
 
     componentDidUpdate(prevProps, prevState){
        if (!this.props.AuthContext.loading && prevProps.AuthContext.loading){
            if(!this.state.AuthContext && !this.props.AuthContext.error){
                const {loogedUsser} = this.props.AuthContext;
                localStorage.setItem('token', JSON.stringify("Bearer "+loogedUsser.token));
                localStorage.setItem('username', JSON.stringify(loogedUsser.loggedUser.firstName));
                this.setState({loading:false});
                this.props.history.push('/patients');
                window.location.reload();  
            }
            else{
                this.setState({loading:false});
            }
          }
       }
 

  
    loginAuth =()=>{
        this.setState({loading:true});

        var loginModel = {
            email:this.state.email,
            password:this.state.password
        }

       
        this.props.dispatch(authAction.requestPost(loginModel));
    }
 
    setPassword=(e)=>{
          this.setState({password:e.target.value});
    }

    setEmail=(e)=>{
        this.setState({email:e.target.value});
    }

    render() { 
 
      const loading=this.state.loading;
        return (  
            <div className="page-wrapper">
            <Container fluid={true} className="p-0">
              <div className="authentication-main m-0 only-login">
                <Row>
                  <Col md="12">
                 
                  <Form className="theme-form login-form">
                                <h4>LOGIN</h4>
                                <h6>Enter your Email and Password</h6>
                                <FormGroup>
                                  <Label className="col-form-label pt-0">
                                    Your Email
                                  </Label>
                                  <Input
                                    className="form-control"
                                    type="email"
                                    name="email"
                                    value={this.state.email}
                                    onChange={this.setEmail}
                                    placeholder="Email address"
                                  />
                                </FormGroup>
                                <FormGroup>
                                  <Label className="col-form-label">Password</Label>
                                  <Input
                                    className="form-control login-form-inputs"
                                    type="password"
                                    name="password"
                                    value={this.state.password}
                                    onChange={this.setPassword}
                                  />
                                </FormGroup>
                                <FormGroup className="form-row mt-3 mb-0">
                                  {loading ? (
                                    <Button
                                      color="primary btn-block"
                                      disabled={loading}
                                    >
                                      LOADING...
                                    </Button>
                                  ) : (
                                    <Button
                                      color="primary btn-block"
                                      onClick={(event) => this.loginAuth(event)}
                                      disabled={!this.state.email || !this.state.password}
                                    >
                                      LOGIN
                                    </Button>
                                  )}
                                </FormGroup>
                                <div className="login-divider"></div>
                                <div className="social mt-3">
                                </div>
                              </Form>
                 
                  </Col>
                </Row>
              </div>
            </Container>
          </div>
 
       
         )
    }
}

const mapStateToProps  = (state) => ({AuthContext:state.AuthContext})

export default connect(mapStateToProps)(withRouter(Login))