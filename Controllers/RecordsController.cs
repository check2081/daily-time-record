using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimePulse.Models;

namespace TimePulse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordsController : ControllerBase
    {
        private readonly RecordContext _context;

        public RecordsController(RecordContext context)
        {
            _context = context;
        }

        // GET: api/Records
        [HttpGet]
        [HttpDelete]
        public async Task<ActionResult<IEnumerable<Record>>> GetRecord(DateTime? @in, bool truncate = false)
        {
            var ar = new List<Record>();

            if (@in != null) {
                var @record = await _context.Record.FirstOrDefaultAsync(r => r.In.Value.Date == @in.Value.Date);
                if (@record != null)
                {
                    ar.Add(@record);
                }
                return ar;
            } else if (truncate)
            {
                var @record = await _context.Record.LastAsync();
                if (@record != null)
                {
                    _context.Record.Remove(@record);
                    _context.SaveChanges();
                }
                return ar;
            }

            return await _context.Record.ToListAsync();
        }

        // GET: api/Records/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Record>> GetRecord(long id)
        {
            var @record = await _context.Record.FindAsync(id);

            if (@record == null)
            {
                return NotFound();
            }

            return @record;
        }

        // PUT: api/Records/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecord(long id, Record @record)
        {
            if (id != @record.Id)
            {
                return BadRequest();
            }

            _context.Entry(@record).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Records
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Record>> PostRecord(Record @record)
        {
            _context.Record.Add(@record);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetRecord", new { id = @record.Id }, @record);
            return CreatedAtAction(nameof(GetRecord), new { id = record.Id }, record);
        }

        // DELETE: api/Records/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord(long id)
        {
            var @record = await _context.Record.FindAsync(id);
            if (@record == null)
            {
                return NotFound();
            }

            _context.Record.Remove(@record);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecordExists(long id)
        {
            return _context.Record.Any(e => e.Id == id);
        }
    }
}
