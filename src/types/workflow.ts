export type FlowType='flowchart'|'usecase'|'dfd'|'sequence'|'erd'|'state';
export type Row={id:string;from:string;to:string;label:string;actor?:string;columns?:string};
export type Project={id:string;name:string;systemType:string;owner:string;modules:string;updatedAt:string};
export const FLOW_TYPES:Record<FlowType,string>={flowchart:'System Flowchart',usecase:'Use Case Diagram',dfd:'Data Flow Diagram',sequence:'Sequence Diagram',erd:'ERD',state:'State Machine'};
