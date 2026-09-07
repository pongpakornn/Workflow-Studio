# Workflow Studio

Automated System Workflow Generator & Documentation Builder.

## Stack
- Next.js 14 App Router + TypeScript
- Tailwind CSS + Framer Motion
- Mermaid workflow generation
- ASP.NET Core 8 Web API + EF Core 8
- SQL Server 2022

## Run locally

```bash
docker compose up -d
npm install
npm run dev
```

For the API:

```bash
dotnet run --project backend/WorkflowStudio.Api
```

The frontend is available on port 3000 and the API defaults to port 5000/launch profile configuration.

## Implemented
- Six Mermaid generators: flowchart, use case, DFD, sequence, ERD, state machine
- Sanitized Mermaid identifiers and inline row validation
- Responsive Slate/Indigo workspace with animated interactions
- Editable workflow table, Enter-to-add, preset flows, source editor, copy/export source
- Project metadata and local save foundation
- ASP.NET Core project CRUD + debounced-save-ready row endpoint
- SQL Server schema and Docker Compose
- Web and API health endpoints

## Next milestones
Real Mermaid SVG canvas with zoom/pan/fullscreen, XLSX/CSV import mapping, high-resolution PNG/SVG and combined DOCX/PDF book export, project-list routing, persistent API autosave wiring, drag reorder, and browser/production QA.
