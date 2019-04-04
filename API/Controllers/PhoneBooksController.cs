using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;
using BLL;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneBooksController : ControllerBase
    {
        private readonly APIContext _context;

        public PhoneBooksController(APIContext context)
        {
            _context = context;
        }

        // GET: api/PhoneBooks
        [HttpGet]
        public IEnumerable<PhoneBooks> GetPhoneBook()
        {
            return _context.PhoneBook;
        }

        // GET: api/PhoneBooks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPhoneBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneBook = await _context.PhoneBook.FindAsync(id);

            if (phoneBook == null)
            {
                return NotFound();
            }

            return Ok(phoneBook);
        }

        // PUT: api/PhoneBooks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhoneBook([FromRoute] int id, [FromBody] PhoneBooks phoneBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phoneBook.ID)
            {
                return BadRequest();
            }

            _context.Entry(phoneBook).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneBookExists(id))
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

        // POST: api/PhoneBooks
        [HttpPost]
        public async Task<IActionResult> PostPhoneBook([FromBody] PhoneBooks phoneBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PhoneBook.Add(phoneBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPhoneBook", new { id = phoneBook.ID }, phoneBook);
        }

        // DELETE: api/PhoneBooks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneBook([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var phoneBook = await _context.PhoneBook.FindAsync(id);
            if (phoneBook == null)
            {
                return NotFound();
            }

            _context.PhoneBook.Remove(phoneBook);
            await _context.SaveChangesAsync();

            return Ok(phoneBook);
        }

        private bool PhoneBookExists(int id)
        {
            return _context.PhoneBook.Any(e => e.ID == id);
        }
    }
}