import React, { Fragment,useEffect,useState } from 'react';
import ReactDOM from 'react-dom';
import {BrowserRouter,Switch,Route,Redirect} from 'react-router-dom'
import "./index.scss";
import * as serviceWorker from './serviceWorker';
import {Provider} from 'react-redux'
import store from './store/index'
import App from './App';
import {routes} from './router/route';
import Login from './Pages/auth/login/login';
 
 

function getToken() {
  const tokenString = localStorage.getItem('token');
  return tokenString
}


const Root = (props) =>  {  
 
  const token = getToken();
  if(!token) {
    return (
      <Fragment>
      <Provider store={store}>
      <BrowserRouter basename={`/`}>
           <Login/>
      </BrowserRouter>
        </Provider>
    </Fragment>
    )
  }
  return(
      <Fragment>
        <Provider store={store}>
        <BrowserRouter basename={`/`}>
          <Switch>
            <Fragment>
            <App>
               <Route exact path="/" render={() => {
                          return (<Redirect to="/Patients" />)
                      }} />
                {routes.map(({ path, Component}) => (
               <Route exact key={path} path={path}>
                       <Component/> 
               </Route>
                            
                ))}
            </App>
            </Fragment> 
          </Switch>
        </BrowserRouter>
        </Provider>
    </Fragment>
  )
}

require('dotenv').config();
ReactDOM.render(<Root/>,
document.getElementById('root'));
serviceWorker.register();
