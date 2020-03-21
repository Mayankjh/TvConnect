using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tv_Connect_App.Helpers;
using Tv_Connect_App.Interfaces;
using Tv_Connect_App.Models;

namespace Tv_Connect_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IChannelRepository _IChannelRepository;

        public PlansController(DataContext context, IChannelRepository IChannelRepository)
        {

            _context = context;
            _IChannelRepository = IChannelRepository;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plan>>> Getplans()
        {
            
        var PlanList =   _context.plans.ToList();
            foreach(Plan plan in PlanList)
            {
                plan.Channel = _IChannelRepository.GetChannelList(plan);
            }
            return PlanList;
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plan>> GetPlan(int id)
        {
            var plan = await _context.plans.FindAsync(id);
            plan.Channel = _IChannelRepository.GetChannelList(plan);
            if (plan == null)
            {
                return NotFound();
            }

            return plan;
        }

        // PUT: api/Plans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan(int id, Plan plan)
        {
            if (id != plan.PlanId)
            {
                return BadRequest();
            }

            _context.Entry(plan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanExists(id))
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

        // POST: api/Plans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Plan>> PostPlan(Plan plan)
        {
            _context.plans.Add(plan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlan", new { id = plan.PlanId }, plan);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Plan>> DeletePlan(int id)
        {
            var plan = await _context.plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            _context.plans.Remove(plan);
            await _context.SaveChangesAsync();

            return plan;
        }

        private bool PlanExists(int id)
        {
            return _context.plans.Any(e => e.PlanId == id);
        }
    }
}
