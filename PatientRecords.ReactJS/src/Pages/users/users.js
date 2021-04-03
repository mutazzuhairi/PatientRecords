import React, { Component } from 'react'
import {connect} from 'react-redux'
import userAction from '../../redux/users/userAction';
import Pagination from "react-js-pagination";
import {Col,Table,Input,Row,Label,Button} from "reactstrap";
import {withRouter } from "react-router-dom";
import LoadingIndicator from '../../component/common/loading-indicator/LoadingIndicator';
import  './users.scss'

class users extends Component {
    constructor(props){
        super(props);
        this.state = {
           headers:[
               "Firs Name",
               "Last Name",
               "User Name",
               "Email",
           ],
           pageSize:Math.floor(window.innerHeight/90),
           pageNumber:1,
           searchField:'',
       };
    
    }

    componentDidMount(){
        this.refreshList();
    }

    componentDidUpdate(prevProps, prevState){
        if (this.state.pageSize !== prevState.pageSize ||
            this.state.pageNumber !== prevState.pageNumber || 
            this.state.searchField !== prevState.searchField){
               this.refreshList();
          }
    }

    changePageSize =(event) =>{
        this.setState({pageSize:event.target.value});
    }
    changePageSearchField =(event) =>{
        this.setState({searchField:event.target.value});
    }

    goToUpdatePage =(id)=> {
        this.props.history.push('/User/'+id);
       }
 
    goToCreatePage =(id)=> {
        this.props.history.push('/User');
       }

    refreshList =()=>{
        this.props.dispatch(userAction.requestGetAll(this.state.pageSize,this.state.pageNumber,this.state.searchField));
    }
 
  
    handlePageChange(pageNumber) {
        this.setState({pageNumber: pageNumber});
      }
    render() {
        const {users,loading} = this.props.UserContext;
        const {headers} = this.state;

        var paggedData = users.data;
        return (
        <div>
       <LoadingIndicator isActive={this.props.UserContext.loading} />
       <Row>
          <Col sm="8">
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
                All Users     
            </h4>
         </Col>
         {/* <Col sm="6">
             <Button onClick={this.goToCreatePage} color="info">New User</Button>
         </Col> */}
          <Col sm="4">
                 {/* <Input
                       className="form-control justify-search"
                        type="text"
                        placeholder="Start Searching ..."
                        onChange={this.changePageSearchField}
                      /> */}
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
                                 <tr  key={item.email} onClick={() => this.goToUpdatePage(item.id)}>
                                      <td> {item.firstName}</td> 
                                      <td> {item.lastName}</td> 
                                      <td> {item.userName}</td> 
                                      <td> {item.email}</td> 
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
          activePage={users.pageNumber}
          itemsCountPerPage={users.pageSize}
          totalItemsCount={users.totalRecords}
          pageRangeDisplayed={5}
          onChange={this.handlePageChange.bind(this)}
        />
      </div>
         
            </div>
            
        )
    }
}

const mapStateToProps  = (state) => ({UserContext:state.UserContext})

export default connect(mapStateToProps )(withRouter(users))