
import users from '../Pages/users/users'
import roles from '../Pages/users/roles/roles'
import pationts from '../Pages/pationts/pationts'
import patientRecords from '../Pages/patientRecords/patientRecords'
import pationtUpdate from '../Pages/pationts/pationtUpdate/pationtUpdate'
import userUpdate from '../Pages/users/userUpdate/userUpdate'
import patientRecordUpdate from '../Pages/patientRecords/patientRecordsUpdate/patientRecordUpdate'
import PatientStatistics from '../Pages/PatientStatistics/PatientStatistics'
 

export const routes = [
    { path:"/Users", Component: users }, 
    { path:"/Roles", Component: roles }, 
    { path:"/Patients", Component: pationts }, 
    { path:"/Patients/:date", Component: pationts }, 
    { path:"/PatientRecords", Component: patientRecords }, 
    { path:"/PatientRecords/:date", Component: patientRecords }, 
    { path:"/PatientRecords/:name/:pationtId", Component: patientRecords }, 

    //For Update
    { path:"/Patient/:id", Component: pationtUpdate }, 
    { path:"/PatientRecord/:id", Component: patientRecordUpdate }, 
    { path:"/User/:id", Component: userUpdate }, 
    //For Create (same components with update)
    { path:"/Patient", Component: pationtUpdate }, 
    { path:"/patientRecord/:pationtname/:pationtid", Component: patientRecordUpdate }, 
    { path:"/User", Component: userUpdate }, 
    { path:"/Statistics/:id", Component: PatientStatistics }, 
 
]
