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
using Tv_Connect_App.Interfaces;
using Tv_Connect_App.Models;

namespace Tv_Connect_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IPlanRepository _IPlanRepository;


        public VendorsController(DataContext context, IPlanRepository IPlanRepository)
        {
            _context = context;
            _IPlanRepository = IPlanRepository;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> Getvendors()
        {
            var VendorList = _context.vendors.ToList();
            foreach (Vendor vendor in VendorList)
            {
                vendor.Plans = _IPlanRepository.GetPlanList(vendor);
                vendor.Vendor_Pass = "*********************";
            }
            return VendorList;
            //return await _context.vendors.ToListAsync();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id)
        {
            var vendor = await _context.vendors.FindAsync(id);
            vendor.Plans = _IPlanRepository.GetPlanList(vendor);
            vendor.Plans.channel = 
            vendor.Vendor_Pass = "*********************";

            if (vendor == null)
            {
                return NotFound();
            }

            return vendor;
        }
        [Authorize(Roles = Role.Vendor + "," + Role.Admin)]
        // PUT: api/Vendors/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor vendor)
        {
            if (id != vendor.VendorId)
            {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Edit Success");
        }
       
        // POST: api/Vendors
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor)
        {
            vendor.Role = Role.Vendor;
            _context.vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.VendorId }, vendor);
        }

        [Authorize(Roles = Role.Admin)]
        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vendor>> DeleteVendor(int id)
        {
            var vendor = await _context.vendors.FindAsync(id);
            if (vendor == null)
            {
                return NotFound();
            }

            _context.vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return vendor;
        }

        private bool VendorExists(int id)
        {
            return _context.vendors.Any(e => e.VendorId == id);
        }
    }
}
