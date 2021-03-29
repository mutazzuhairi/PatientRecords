import React from 'react'
export const MENUITEMS = [
    {
        title: 'Patients', icon: <i className="pe-7s-bandaid pe-lg"></i>, path: '/Patients', type: 'sub',active: true,bookmark: true, children: [
                {title: 'All Patients', type: 'sub'},
                { title: 'Last Week', type: 'link', path:  '/Patients/LastWeek'},
                { title: 'Last Month', type: 'link', path:  '/Patients/LastMonth'},
                { title: 'Last Year', type: 'link', path:  '/Patients/LastYear'}

        ]
    },
      {
        title: 'Records', icon: <i className="pe-7s-note2 pe-lg"></i>, path: '/patientRecords', type: 'sub',active: true,bookmark: true, children: [
                {title: 'All Records', type: 'sub'},
                { title: 'Last Week', type: 'link', path:  '/patientRecords/LastWeek'},
                { title: 'Last Month', type: 'link', path:  '/patientRecords/LastMonth'},
                { title: 'Last Year', type: 'link', path:  '/patientRecords/LastYear'}

        ]
    },
 
    {
        title: 'Users', icon: <i className="pe-7s-users"></i>,  path: '/users', type: 'sub',active: false, children: [
                {title: 'Users', type: 'sub'},
                { title: 'Roles', type: 'link', path: '/users' },
        ]
        
    },
]