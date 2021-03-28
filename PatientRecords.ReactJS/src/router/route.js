
import users from '../Pages/users/users'
import pationts from '../Pages/pationts/pationts'
import patientRecords from '../Pages/patientRecords/patientRecords'
import pationtUpdate from '../Pages/pationts/pationtUpdate/pationtUpdate'
import userUpdate from '../Pages/users/userUpdate/userUpdate'
import patientRecordUpdate from '../Pages/patientRecords/patientRecordsUpdate/patientRecordUpdate'
import PatientStatistics from '../Pages/PatientStatistics/PatientStatistics'
 

export const routes = [
    { path:"/users", Component: users }, 
    { path:"/patients", Component: pationts }, 
    { path:"/patientRecords", Component: patientRecords }, 
    //For Update
    { path:"/pationtUpdate/:id", Component: pationtUpdate }, 
    { path:"/patientRecordUpdate/:id", Component: patientRecordUpdate }, 
    { path:"/userUpdate/:id", Component: userUpdate }, 
    //For Create (same components with update)
    { path:"/pationtUpdate", Component: pationtUpdate }, 
    { path:"/patientRecordUpdate/:pationtname/:pationtid", Component: patientRecordUpdate }, 
    { path:"/userUpdate", Component: userUpdate }, 
    { path:"/Statistics/:id", Component: PatientStatistics }, 

]
