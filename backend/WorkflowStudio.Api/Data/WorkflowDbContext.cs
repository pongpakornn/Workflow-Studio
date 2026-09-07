using Microsoft.EntityFrameworkCore;
namespace WorkflowStudio.Api.Data;
public class WorkflowDbContext:DbContext{public WorkflowDbContext(DbContextOptions<WorkflowDbContext> o):base(o){}public DbSet<Project> Projects=>Set<Project>();public DbSet<WorkflowRow> WorkflowRows=>Set<WorkflowRow>();}
public class Project{public Guid Id{get;set;}=Guid.NewGuid();public string Name{get;set;}="";public string SystemType{get;set;}="";public string Owner{get;set;}="";public string Modules{get;set;}="";public DateTime UpdatedAt{get;set;}=DateTime.UtcNow;public List<WorkflowRow> Rows{get;set;}=[];}
public class WorkflowRow{public Guid Id{get;set;}=Guid.NewGuid();public Guid ProjectId{get;set;}public string FlowType{get;set;}="flowchart";public string From{get;set;}="";public string To{get;set;}="";public string Label{get;set;}="";public int SortOrder{get;set;}public Project? Project{get;set;}}
