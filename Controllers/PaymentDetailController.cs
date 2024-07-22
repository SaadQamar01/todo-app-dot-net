using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payment_crud.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace payment_crud.Controllers
{
    [Route("api/[controller]")]
    public class PaymentDetailController : ControllerBase
    {
        private readonly PaymentDetailsContext _context;

        public PaymentDetailController(PaymentDetailsContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
        {
            if(_context.PaymentDetails == null)
            {
                return NotFound();
            }
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetails>> GetPaymentDetail(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }

            var paymentDetail = await _context.PaymentDetails.FindAsync(id);

            if (paymentDetail == null)
            {
                return NotFound();
            }

            return paymentDetail;
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<PaymentDetails>> PostPaymentDetails([FromBody] PaymentDetails paymentDetail)
        {
            if (_context.PaymentDetails == null)
            {
                return Problem("Entity set is null");
            }
            _context.PaymentDetails.Add(paymentDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetails.ToListAsync());

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutPaymentDetail(int id, [FromBody] PaymentDetails paymentDetail)
        {
            if(id != paymentDetail.PaymentDetailId)
            {
                return BadRequest();
            }
            _context.Entry(paymentDetail).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(await _context.PaymentDetails.ToListAsync());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaymentDetail(int id)
        {
            if (_context.PaymentDetails == null)
            {
                return NotFound();
            }
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            _context.PaymentDetails.Remove(paymentDetail);
            await _context.SaveChangesAsync();

            return Ok(await _context.PaymentDetails.ToListAsync());

        }

        private bool PaymentDetailExists(int id)
        {
            return (_context.PaymentDetails?.Any(e => e.PaymentDetailId == id)).GetValueOrDefault();
        }
    }
}

