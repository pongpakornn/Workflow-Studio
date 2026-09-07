import {FlowType,Row} from '@/types/workflow';
const clean=(s:string)=>s.replace(/["()\\{}<>]/g,'').replace(/[^\w\s.:-]/g,'').trim();
export function generateDiagram(type:FlowType,rows:Row[]){
 const r=rows.map(x=>({...x,from:clean(x.from),to:clean(x.to),label:clean(x.label)}));
 if(r.some(x=>!x.from||!x.to)) throw new Error('Every row needs From and To values.');
 if(type==='flowchart') return 'flowchart TD\n'+r.map(x=>`  ${id(x.from)}[${x.from}] -->|${x.label}| ${id(x.to)}[${x.to}]`).join('\n');
 if(type==='usecase') return 'flowchart LR\n  actor((Actor))\n'+r.map(x=>`  actor --> ${id(x.to)}(( ${x.to} ))`).join('\n');
 if(type==='dfd') return 'flowchart LR\n'+r.map(x=>`  ${id(x.from)}[/${x.from}/] -->|${x.label}| ${id(x.to)}[${x.to}]`).join('\n');
 if(type==='sequence') {const ps=Array.from(new Set(r.flatMap(x=>[x.from,x.to])));return 'sequenceDiagram\n'+ps.map(p=>`  participant ${id(p)} as ${p}`).join('\n')+'\n'+r.map(x=>`  ${id(x.from)}->>${id(x.to)}: ${x.label}`).join('\n');}
 if(type==='state') return 'stateDiagram-v2\n'+r.map(x=>`  ${x.from} --> ${x.to}: ${x.label}`).join('\n');
 const tables=Array.from(new Set(r.flatMap(x=>[x.from,x.to]))); return 'erDiagram\n'+tables.map(t=>`  ${id(t)} {\n    string id PK\n  }`).join('\n')+'\n'+r.map(x=>`  ${id(x.from)} ||--o{ ${id(x.to)} : "${x.label}"`).join('\n');
}
const id=(s:string)=>clean(s).replace(/\s+/g,'_').replace(/^[^A-Za-z_]/,'_');
