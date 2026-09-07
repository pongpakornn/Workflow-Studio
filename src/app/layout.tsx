import './globals.css';
import type {Metadata} from 'next';
export const metadata:Metadata={title:'Workflow Studio',description:'Automated System Workflow Generator & Documentation Builder'};
export default function RootLayout({children}:{children:React.ReactNode}){return <html lang="en"><body>{children}</body></html>}
