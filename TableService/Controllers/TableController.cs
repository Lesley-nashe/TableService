using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TableService.Context;
using TableService.Models.Models;

namespace TableService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TableController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("tables")]
        public async Task<ActionResult<IEnumerable<TableModel>>> GetTables()
        {
            return await _context.TableItems.ToListAsync();
        }

        [HttpPut("table/{tableId}")]
        public async Task<IActionResult> UpdateTable(string TableId, TableModel table)
        {
            if (table is null || TableId != table.TableId)
                return BadRequest("Invalid Table data or mismatched ID.");

            var tableUpdate = await _context.TableItems.FindAsync(TableId);

            tableUpdate.Capacity = table.Capacity;
            tableUpdate.Available = table.Available;

            _context.TableItems.Update(tableUpdate);
            await _context.SaveChangesAsync();

            return Ok(tableUpdate);
        }

    }
}
