using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kutuphane;
using Kutuphane.DTO;

namespace Kutuphane.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly KutuphaneContext _context;

        public MembersController(KutuphaneContext context)
        {
            _context = context;
            if (!_context.Members.Any())
            {
                SeedCreate.GenerateSeedData(_context);
                _context.SaveChanges();

            }
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMembers()
        {
            return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(long id)
        {
            var member = await _context.Members.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return member;
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMember(long id, AddMember member)
        {

            Member entity = await _context.Members.FindAsync(id);

            entity.Adress = member.Adress;
            entity.Age = member.Age;
            entity.Name = member.Name;

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(id))
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

        // POST: api/Members
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Member>> PostMember(AddMember member)
        {
            Member entity = new Member
            {
                Adress = member.Adress,
                Age = member.Age,
                Name = member.Name,
                RegisterationTime = DateTime.Now
            };
            _context.Members.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(this.GetMember), new { id = entity.Id }, entity);
        }

        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(long id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return member;
        }

        private bool MemberExists(long id)
        {
            return _context.Members.Any(e => e.Id == id);
        }


        [HttpGet("{id}/NotReceivedBooks")]
        public IEnumerable<Book> GetNotReceivedBook([FromRoute] int id)
        {
            return _context.Transactions.Where(t => t.MemberId == id && t.ReceiveTime == null).Select(t => t.Book).ToList();
        }
    }
}
