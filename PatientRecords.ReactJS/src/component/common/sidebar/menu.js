import React from 'react'
export const MENUITEMS = [
    {
        title: 'Patients', icon: <i className="pe-7s-bandaid pe-lg"></i>, path: '/Patients', type: 'sub',active: true,bookmark: true, children: [
                {title: 'All Patients', type: 'sub' ,path: '/Patients'},
                { title: 'Last Week', type: 'link', path:  '/Patients/LastWeek'},
                { title: 'Last Month', type: 'link', path:  '/Patients/LastMonth'},
                { title: 'Last Year', type: 'link', path:  '/Patients/LastYear'}

        ]
    },
      {
        title: 'Records', icon: <i className="pe-7s-note2 pe-lg"></i>, path: '/PatientRecords', type: 'sub',active: true,bookmark: true, children: [
                {title: 'All Records', type: 'sub',path: '/PatientRecords'},
                { title: 'Last Week', type: 'link', path:  '/PatientRecords/LastWeek'},
                { title: 'Last Month', type: 'link', path:  '/PatientRecords/LastMonth'},
                { title: 'Last Year', type: 'link', path:  '/PatientRecords/LastYear'}

        ]
    },
 
    {
        title: 'Users', icon: <i className="pe-7s-users"></i>,  path: '/Users', type: 'sub',active: false, children: [
                {title: 'Users', type: 'sub',path: '/Users'},
                { title: 'Roles', type: 'link', path: '/Roles' },
        ]
        
    },
]