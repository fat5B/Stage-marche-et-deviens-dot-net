using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using stage_marche_devient.Data;
using stage_marche_devient.Models;

namespace stage_marche_devient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevisController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public DevisController(ApiDbContext context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<ActionResult<Devis>> GetDevis()
        {
            var formsdevis= await _context.DevisForm.ToListAsync();
            return Ok(formsdevis);
        }


        
        
        [HttpGet("{id}")]

        public async Task<ActionResult> GetDevisById(int id)
        {
            var formdevis = await _context.DevisForm.FirstOrDefaultAsync(s=>s.Id == id);
            return Ok(formdevis);
        }
        
        
        
        
        [HttpPost]
        public async Task<ActionResult> CreateDevisForm(Devis devis)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            _context.DevisForm.Add(devis);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetDevisForm", new {id = devis.Id},devis);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDevis(int id)
        {
            if(ModelState.IsValid)
                return BadRequest(ModelState);

            var formDevis = await _context.DevisForm.FindAsync(id);
            if(formDevis == null)
                return NotFound();
            
            _context.DevisForm.Remove(formDevis);
            await _context.SaveChangesAsync();
            return Ok(formDevis);
        }

     
    }
}
