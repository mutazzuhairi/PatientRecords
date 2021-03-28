import {combineReducers} from 'redux'
import UserContext from './users/userReducer'
import PationtContext from './pationts/pationtReducer'
import PationtRecordContext from './patientRecords/patientRecordReducer'
import PatientStatisticsContext from './PatientStatistics/PatientStatisticsReducer'
import AuthContext from './auth/authReducer'

const reducers = combineReducers({
    UserContext,
    PationtContext,
    PationtRecordContext,
    PatientStatisticsContext,
    AuthContext
});

export default reducers;