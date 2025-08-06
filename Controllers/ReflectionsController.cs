using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyJournalApi.Data;
using MyJournalApi.Models;

namespace MyJournalApi.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ReflectionsController : ControllerBase
  {
    private readonly ApplicationDbContext _context;

    public ReflectionsController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reflection>>> Index()
    {
      var reflections = await _context.Reflections.ToListAsync();
      return Ok(reflections);
    }

    [HttpPost]
    public async Task<ActionResult<Reflection>> Create([FromBody] CreateReflectionRequest request)
    {
      var reflection = new Reflection
      {
        Date = request.Date,
        Mood = request.Mood,
        High = request.High,
        Low = request.Low,
        Log = request.Log
      };

      _context.Reflections.Add(reflection);
      await _context.SaveChangesAsync();

      return CreatedAtAction(nameof(Show), new { id = reflection.Id }, reflection);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Reflection>> Show(int id)
    {
      var reflection = await _context.Reflections.FindAsync(id);
      
      if (reflection == null)
      {
        return NotFound();
      }

      return Ok(reflection);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Reflection>> Update(int id, [FromBody] UpdateReflectionRequest request)
    {
      var reflection = await _context.Reflections.FindAsync(id);
      
      if (reflection == null)
      {
          return NotFound();
      }

      // We use PUT here to replace the full resource; switch to PATCH if you teach JSON-Patch later
      reflection.Date = request.Date ?? reflection.Date;
      reflection.Mood = request.Mood ?? reflection.Mood;
      reflection.High = request.High ?? reflection.High;
      reflection.Low = request.Low ?? reflection.Low;
      reflection.Log = request.Log ?? reflection.Log;

      await _context.SaveChangesAsync();
      
      return Ok(reflection);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Destroy(int id)
    {
      var reflection = await _context.Reflections.FindAsync(id);
      
      if (reflection == null)
      {
        return NotFound();
      }

      _context.Reflections.Remove(reflection);
      await _context.SaveChangesAsync();
      
      return NoContent(); // HTTP 204 - successful deletion with no content
    }

    public class CreateReflectionRequest
    {
      public string Date { get; set; } = "";
      public string Mood { get; set; } = "";
      public string High { get; set; } = "";
      public string Low { get; set; } = "";
      public string Log { get; set; } = "";
    }

    public class UpdateReflectionRequest
    {
      public string Date { get; set; } = "";
      public string Mood { get; set; } = "";
      public string High { get; set; } = "";
      public string Low { get; set; } = "";
      public string Log { get; set; } = "";
    }
  }
}