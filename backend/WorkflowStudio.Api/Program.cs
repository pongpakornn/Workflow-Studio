using Microsoft.EntityFrameworkCore;
using WorkflowStudio.Api.Data;
var builder=WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WorkflowDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();builder.Services.AddCors(o=>o.AddDefaultPolicy(p=>p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
var app=builder.Build();app.UseCors();app.MapControllers();app.MapGet("/api/health",()=>Results.Ok(new{status="ok",service="workflow-studio-api"}));app.Run();
