using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tv_Connect_App.Entities;
using Tv_Connect_App.Helpers;
using Tv_Connect_App.Models;

namespace Tv_Connect_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RechargesController : ControllerBase
    {
        private readonly DataContext _context;

        public RechargesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Recharges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recharge>>> GetRecharge()
        {
            return await _context.Recharge.ToListAsync();
        }

        // GET: api/Recharges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recharge>> GetRecharge(int id)
        {
            var recharge = await _context.Recharge.FindAsync(id);

            if (recharge == null)
            {
                return NotFound();
            }

            return recharge;
        }

        // PUT: api/Recharges/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRecharge(int id, Recharge recharge)
        //{
        //    if (id != recharge.RechargeId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(recharge).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RechargeExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Recharges
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize(Roles = Role.Vendor)]
        [HttpPost]
        public async Task<ActionResult<Recharge>> PostRecharge(Recharge recharge)
        {
            _context.Recharge.Add(recharge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecharge", new { id = recharge.RechargeId }, recharge);
        }

        // DELETE: api/Recharges/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Recharge>> DeleteRecharge(int id)
        //{
        //    var recharge = await _context.Recharge.FindAsync(id);
        //    if (recharge == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Recharge.Remove(recharge);
        //    await _context.SaveChangesAsync();

        //    return recharge;
        //}

        private bool RechargeExists(int id)
        {
            return _context.Recharge.Any(e => e.RechargeId == id);
        }
    }
}
