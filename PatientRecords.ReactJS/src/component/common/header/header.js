import React, { useState,useEffect,useCallback } from 'react';
import {AlignCenter,LogOut,Search} from 'react-feather'
import {Link} from 'react-router-dom'
const Header = (props) => {
 
    const [searchValue, setsearchValue] = useState('');
    const [sidebar, setSidebar] = useState("iconsidebar-menu");
    const [username, setUsername] = useState(JSON.parse(localStorage.getItem('username')));

    const escFunction = useCallback((event) => {
        if(event.keyCode === 27) {
          setsearchValue('')
        }
    }, []);

    useEffect(() => {

      document.addEventListener("keydown", escFunction, false);
      return () => {
          document.removeEventListener("keydown", escFunction, false);
      };
    }, [escFunction]);
    
   

    const openCloseSidebar = (sidebartoggle) => {
      if (sidebartoggle === "iconsidebar-menu") {
        setSidebar("iconbar-mainmenu-close")
        document.querySelector(".iconsidebar-menu").classList.add('iconbar-mainmenu-close');
      } 
      else if(sidebartoggle === "iconbar-mainmenu-close") {
        setSidebar("iconbar-second-close")
        document.querySelector(".iconsidebar-menu").classList.add('iconbar-second-close');
        document.querySelector(".iconsidebar-menu").classList.remove('iconbar-mainmenu-close');
      }
      else {
        setSidebar("iconsidebar-menu")
        document.querySelector(".iconsidebar-menu").classList.remove('iconbar-second-close');
      }
    }
 
    const signOut=()=>{
      localStorage.clear();
      window.location.reload();
    }
     

  
    return (
        <div className="page-main-header">
        <div className="main-header-right">
          <div className="main-header-left text-center">
            <div className="logo-wrapper"><Link to="/default/sample-page"><img src={require("../../../assets/images/logo/logo.png")} alt=""/></Link></div>
          </div>
          <div className="mobile-sidebar">
            <div className="media-body text-right switch-sm">
              <label className="switch ml-3"><AlignCenter className="font-primary" onClick={() => openCloseSidebar(sidebar)} /></label>
            </div>
          </div>
          <div className="nav-right col pull-right right-menu">
            <ul className="nav-menus">
              <li>
            
              </li>
              <li><h4> Hi, {username} <span><LogOut className="LogOut" onClick={()=>signOut()} /></span></h4></li>
            </ul>
          </div>
          
        </div>
      </div>
    );
}

export default Header;