using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentSIMS.Data;
using StudentSIMS.Models;

namespace StudentSIMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly StudentSIMSContext _context;

        public AddressesController(StudentSIMSContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddress()
        {
            return await _context.Addresses.ToListAsync();
        }

        [HttpGet("ByAddressId/{addressId}")]
        public async Task<ActionResult<Address>> GetAddressById(int addressId)
        {
            var address = await _context.Addresses.FindAsync(addressId);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpGet("ByStudentId/{studentId}")]
        public async Task<ActionResult<Address>> GetAddressByStudentId(int studentId)
        {
            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.StudentId == studentId);

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPut("ByAddressId/{addressId}")]
        public async Task<IActionResult> PutAddressById(int addressId, Address address)
        {
            if (addressId != address.Id)
            {
                return BadRequest();
            }

            if (!AddressExists(address.Id))
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address.Id))
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

        [HttpPut("ByStudentId/{studentId}")]
        public async Task<IActionResult> PutAddressByStudentId(int studentId, Address address)
        {
            if (studentId != address.StudentId)
            {
                return BadRequest();
            }

            if (await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId) == null)
            {
                return BadRequest();
            }

            if (!AddressExists(address.Id))
            {
                return BadRequest();
            }

            _context.Entry(address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(address.Id))
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

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == address.StudentId);

            if (student == null)
            {
                return BadRequest();
            }

            var studentAddress = await _context.Addresses.FirstOrDefaultAsync(a => a.StudentId == address.StudentId);
            if (studentAddress != null)
            {
                return BadRequest();
            }

            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.Id }, address);
        }

        [HttpDelete("ByAddressId/{addressId}")]
        public async Task<ActionResult<Address>> DeleteAddressById(int addressId)
        {
            var address = await _context.Addresses.FindAsync(addressId);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }

        [HttpDelete("ByStudentId/{studentId}")]
        public async Task<ActionResult<Address>> DeleteAddressByStudentId(int studentId)
        {
            var student = await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
            if (student == null)
            {
                return BadRequest();
            }

            var address = await _context.Addresses.FirstOrDefaultAsync(a => a.StudentId == student.StudentId);
            if (address == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();

            return address;
        }


        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.Id == id);
        }
    }
}
