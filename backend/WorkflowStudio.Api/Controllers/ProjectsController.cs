using Microsoft.AspNetCore.Mvc;using Microsoft.EntityFrameworkCore;using WorkflowStudio.Api.Data;
namespace WorkflowStudio.Api.Controllers;
[ApiController][Route("api/projects")]
public class ProjectsController(WorkflowDbContext db):ControllerBase{
 [HttpGet]public async Task<ActionResult<IEnumerable<Project>>> Get()=>Ok(await db.Projects.Include(p=>p.Rows).OrderByDescending(p=>p.UpdatedAt).ToListAsync());
 [HttpGet("{id:guid}")]public async Task<ActionResult<Project>> Get(Guid id){var p=await db.Projects.Include(x=>x.Rows).FirstOrDefaultAsync(x=>x.Id==id);return p is null?NotFound():Ok(p);}
 [HttpPost]public async Task<ActionResult<Project>> Create(Project p){p.Id=Guid.NewGuid();p.UpdatedAt=DateTime.UtcNow;await db.Projects.AddAsync(p);await db.SaveChangesAsync();return CreatedAtAction(nameof(Get),new{id=p.Id},p);}
 [HttpPut("{id:guid}")]public async Task<IActionResult> Update(Guid id,Project input){var p=await db.Projects.Include(x=>x.Rows).FirstOrDefaultAsync(x=>x.Id==id);if(p is null)return NotFound();p.Name=input.Name;p.SystemType=input.SystemType;p.Owner=input.Owner;p.Modules=input.Modules;p.UpdatedAt=DateTime.UtcNow;await db.SaveChangesAsync();return NoContent();}
 [HttpDelete("{id:guid}")]public async Task<IActionResult> Delete(Guid id){var p=await db.Projects.FindAsync(id);if(p is null)return NotFound();db.Projects.Remove(p);await db.SaveChangesAsync();return NoContent();}
 [HttpPut("{id:guid}/rows")]public async Task<IActionResult> SaveRows(Guid id,[FromBody]List<WorkflowRow> rows){var p=await db.Projects.Include(x=>x.Rows).FirstOrDefaultAsync(x=>x.Id==id);if(p is null)return NotFound();db.WorkflowRows.RemoveRange(p.Rows);foreach(var r in rows){r.Id=Guid.NewGuid();r.ProjectId=id;}await db.WorkflowRows.AddRangeAsync(rows);p.UpdatedAt=DateTime.UtcNow;await db.SaveChangesAsync();return Ok(new{savedAt=p.UpdatedAt});}
}
