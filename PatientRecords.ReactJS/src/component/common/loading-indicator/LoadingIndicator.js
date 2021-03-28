import styles from './LoadingIndicator.scss';
import React from 'react';
import classNames from 'classnames';
 
export default class LoadingIndicator extends React.PureComponent {
  static defaultProps = {
    className: undefined,
    isActive: false,
  };

  render() {
    const { children, isActive, className } = this.props;
    const cssClasses = classNames(className, {
      [styles.wrapper]: isActive,
    });

    return (
      <div className={cssClasses}>
        {isActive && (
                    <div>
                        <div id="CargoTracking_BusyIndicator"    className="BusyIndicatorControlLayout" tabIndex="-1" contentEditable="false"></div>
                          <div     className="BusyIndicatorControl">
                           <div className="BusyIndicatorControlOuter">
                            <div className="BusyIndicatorControlInner">
                                <div  className="busy">
                                   <div className="lds-ring"><div></div><div></div><div></div><div></div></div>                  
                                </div>
                                <div className="bottomBusy">
                                    <label className="TextStyle">Loading ...</label>
                                </div>
                            </div>
                        </div>
                    </div>                                 
                 </div>
        )}
        {children}
      </div>
    );
  }
}
