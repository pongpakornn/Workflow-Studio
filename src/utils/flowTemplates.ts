import {Row} from '@/types/workflow';
export const presets:Record<string,Row[]>={
 'Approval Flow':[{id:'1',from:'Start',to:'Submit Request',label:'create'},{id:'2',from:'Submit Request',to:'Manager Review',label:'pending'},{id:'3',from:'Manager Review',to:'Approved',label:'approve'},{id:'4',from:'Manager Review',to:'Rejected',label:'reject'}],
 'CRUD Flow':[{id:'1',from:'Client',to:'Controller',label:'HTTP request'},{id:'2',from:'Controller',to:'Service',label:'validate'},{id:'3',from:'Service',to:'SQL Server',label:'query'},{id:'4',from:'SQL Server',to:'Controller',label:'result'}],
 'Auth Flow':[{id:'1',from:'Login Page',to:'Auth Controller',label:'credentials'},{id:'2',from:'Auth Controller',to:'Auth Service',label:'authenticate'},{id:'3',from:'Auth Service',to:'SQL Server',label:'lookup user'},{id:'4',from:'Auth Service',to:'Dashboard',label:'token'}]
};
