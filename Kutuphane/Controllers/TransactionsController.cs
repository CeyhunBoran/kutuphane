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
    public class TransactionsController : ControllerBase
    {
        private readonly KutuphaneContext _context;

        public TransactionsController(KutuphaneContext context)
        {
            _context = context;
            if (!_context.Books.Any() || !_context.Members.Any())
            {
                SeedCreate.GenerateSeedData(_context);
            }
        }

        // GET: api/Transactions
        [HttpGet]
        public async Task<ActionResult> GetTransactions()
        {
            return Ok(await _context.Transactions.Select(t => new  {
                Id = t.Id,
                Book= new { Name= t.Book.Name},
                Member= new { Name = t.Member.Name},
                DueTime = t.DueTime,
                BookId = t.BookId,
                MemberId = t.MemberId,
                ReceiveTime = t.ReceiveTime,
                RegisterationTime = t.RegisterationTime
            }).ToListAsync());
        }

        // GET: api/Transactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransaction(long id)
        {
            var transaction = await _context.Transactions.FindAsync(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return transaction;
        }

        // PUT: api/Transactions/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaction(long id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }

            _context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionExists(id))
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

        // POST: api/Transactions
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Transaction>> PostTransaction(AddTransaction transaction)
        {
            Transaction entity = new Transaction
            {
                BookId = transaction.BookId,
                MemberId = transaction.MemberId,
                DueTime = transaction.DueTime
            };
            
            _context.Transactions.Add(entity);

            var book = await _context.Books.FindAsync(entity.BookId);
            book.NumberOfBooks--;
            _context.Books.Update(book);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = entity.Id }, entity);
        }

        [HttpPut, Route("{transactionId}/Receive")]
        public async Task<ActionResult<Transaction>> ReceivedTreansaction([FromRoute] long transactionId)
        {
            Transaction entity = await _context.Transactions.FindAsync(transactionId);
            entity.ReceiveTime = DateTime.Now;

            _context.Transactions.Update(entity);

            var book = await _context.Books.FindAsync(entity.BookId);
            book.NumberOfBooks++;
            _context.Books.Update(book);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaction", new { id = entity.Id }, entity);
        }


        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Transaction>> DeleteTransaction(long id)
        {
            var transaction = await _context.Transactions.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _context.Transactions.Remove(transaction);
            await _context.SaveChangesAsync();

            return transaction;
        }

        private bool TransactionExists(long id)
        {
            return _context.Transactions.Any(e => e.Id == id);
        }
    }
}
