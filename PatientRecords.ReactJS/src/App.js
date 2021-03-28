import React, { Fragment } from 'react';
import Loader from './component/common/loader/loader'
import Header from './component/common/header/header'
import Sidebar from './component/common/sidebar/sidebar'
import Footer from './component/common/footer/footer'
import 'react-toastify/dist/ReactToastify.css';

const App = ({children}) =>  {
  return (
    <Fragment> 
    <Loader/>
    <div className="page-wrapper">
      <div className="page-body-wrapper">
        <Header/>
        <Sidebar/>
          <div className="page-body">
              {children} 
          </div>
        <Footer/> 
      </div>  
    </div>
    </Fragment>
  );
}


export default App;
