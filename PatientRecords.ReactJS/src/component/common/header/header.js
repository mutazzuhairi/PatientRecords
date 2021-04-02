import React, { Component } from 'react'
import {AlignCenter,LogOut,User} from 'react-feather'
import {Link} from 'react-router-dom'
import {Form, FormGroup} from "reactstrap";
import {connect} from 'react-redux'
import {withRouter } from "react-router-dom";
import pationtAction from '../../../redux/pationts/pationtAction';


class Header extends Component{

  constructor(props){
    super(props);
    this.state={
       sidebar:'iconsidebar-menu',
       SearchResultEmpty:false,
       searchResult:false,
       searchValue:'',
       searchResponse:null,
       username:JSON.parse(localStorage.getItem('username'))
    }
  }


  openCloseSidebar = (sidebartoggle) => {
    if (sidebartoggle === "iconsidebar-menu") {
      this.setState({sidebar:"iconbar-mainmenu-close"});
      document.querySelector(".iconsidebar-menu").classList.add('iconbar-mainmenu-close');
    } 
    else if(sidebartoggle === "iconbar-mainmenu-close") {
      this.setState({sidebar:"iconbar-second-close"});
      document.querySelector(".iconsidebar-menu").classList.add('iconbar-second-close');
      document.querySelector(".iconsidebar-menu").classList.remove('iconbar-mainmenu-close');
    }
    else {
      this.setState({sidebar:"iconsidebar-menu"});
      document.querySelector(".iconsidebar-menu").classList.remove('iconbar-second-close');
    }
  }

  
  componentDidUpdate(prevProps, prevState){
    if (this.state.searchValue !== prevState.searchValue){
           this.SearchList();
      }
  }


 handleSearchKeyword = (keyword) => {
    keyword ? this.addFix() : this.removeFix(keyword);
      if (keyword.length > 0) 
      this.setState({searchValue:keyword});
      //this.checkSearchResultEmpty(pationts);

  };
 
  SearchList =()=>{
    this.props.dispatch(pationtAction.requestGetAllHeader(1,20,this.state.searchValue));
   }

  SignOut=()=>{
    localStorage.clear();
    window.location.reload();
  }
   
  checkSearchResultEmpty = (items) => {
    if (!items.length) {
      this.setState({SearchResultEmpty:true});
      document.querySelector(".empty-menu").classList.add("is-open");
    } else {
      this.setState({SearchResultEmpty:false});
      document.querySelector(".empty-menu").classList.remove("is-open");
    }
  };

  addFix = () => {
    this.setState({SearchResult:true});
    document.querySelector(".Typeahead-menu").classList.add("is-open");
    document.body.classList.add("offcanvas");
  };

  removeFix = () => {
    this.setState({SearchResult:false});
    this.setState({searchValue:""});
    document.querySelector(".Typeahead-menu").classList.remove("is-open");
    document.body.classList.remove("offcanvas");
    this.setState({searchValue:""});

  };
  goToPatientpage = (id) => {
    this.removeFix();
    this.props.history.push('/patient/'+id);

  };
  
  onFocus = event => {
    if(this.state.searchValue){
      document.querySelector(".Typeahead-menu").classList.add("is-open");
      document.body.classList.add("offcanvas");
    }

    event.target.setAttribute('autocomplete', 'off');
    console.log(event.target.autocomplete);
 
 };
 onBlur  = event => {

  document.querySelector(".Typeahead-menu").classList.remove("is-open");
  document.body.classList.remove("offcanvas");

};

 
  render(){
    const {headerPationts} = this.props.PationtContext;
    var paggedData = headerPationts.data;

    return (

        <div className="page-main-header">
        <div className="main-header-right">
          <div className="main-header-left text-center">
            <div className="logo-wrapper"><Link to="/Patients"><img src={require("../../../assets/images/logo/logo.png")} alt=""/></Link></div>
          </div>
          <div className="mobile-sidebar">
            <div className="media-body text-right switch-sm">
              <label className="switch ml-3"><AlignCenter className="font-primary" onClick={() => this.openCloseSidebar(this.state.sidebar)} /></label>
            </div>
          </div>
          <div className="nav-right col pull-right right-menu">
            <ul className="nav-menus">
            <li>
              <Form
                className="form-inline search-form"
                action="#javascript"
                method="get"
              >
                <FormGroup>
                  <div className="Typeahead Typeahead--twitterUsers">
                    <div className="u-posRelative">
                      <input
                        className="Typeahead-input form-control-plaintext"
                        id="demo-input"
                        type="text"
                        placeholder="Search For Patients..."
                        value={this.state.searchValue}
                        autoComplete="off" 
                        onFocus={this.onFocus}
                        onBlur={this.onBlur}
                        onChange={(e) => this.handleSearchKeyword(e.target.value)}
                      />
                      {  <div
                        className={`spinner-border Typeahead-spinner ${
                          this.props.PationtContext.headerLoading === true ? "show" : ""
                        }`}
                        role="status"
                      >
                        <span className="sr-only">Loading...</span>
                      </div>  }
                    </div>
                    <div
                      className="Typeahead-menu custom-scrollbar"
                      id="search-outer"
                    >
                      {paggedData && paggedData.length>0?
                         paggedData.map((data, index) => {
                            return (
                              <Link
                              key={index}
                              to={'/patient/'+data.id}
                              className="realname"
                              onMouseDown={()=>this.goToPatientpage(data.id)} >
                              <div className="ProfileCard u-cf" >
                                <div className="ProfileCard-avatar">
                                <User style={{marginTop:0}} />  &nbsp;&nbsp;&nbsp; {data.name}
                                </div>
                                <div style={{marginTop:3}}  className="ProfileCard-details">
                                  <div style={{textAlign:'center'}} className="ProfileCard-realName">
                                      {data.officialId}
                                  </div>
                                </div>
                               </div>
                              </Link>
                            );
                          })
                        :this.props.PationtContext.headerLoading === false? <span style={{color:'grey'}}>Opps!! There are no result found.</span>:""}  
                    </div>
                  </div>
                </FormGroup>
              </Form>
            </li>
              <li><h4> {this.state.username} <span><LogOut className="LogOut" onClick={()=>this.SignOut()} /></span></h4></li>
            </ul>
          </div>
          
        </div>
      </div>



       );
  }


}

const mapStateToProps  = (state) => ({PationtContext:state.PationtContext})

export default connect(mapStateToProps )(withRouter(Header))
 