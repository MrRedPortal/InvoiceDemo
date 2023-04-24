using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace InvoiceDemo.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController : ControllerBase
    {
        private readonly InvoiceDBContext _context;

        public InvoiceController(InvoiceDBContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public ActionResult<IEnumerable<Invoices>> GetInvoices()
        {
            return _context.Invoices.ToList();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public ActionResult<Invoices> GetInvoices(int id)
        {
            var invoice = _context.Invoices.Find(id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // POST: api/TodoItems
        [HttpPost]
        public ActionResult<Invoices> PostInvoices(Invoices invoice)
        {
            _context.Invoices.Add(invoice);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetInvoices), new { id = invoice.InvoiceId }, invoice);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public IActionResult PutInvoices(int id, Invoices invoice)
        {
            if (id != invoice.InvoiceId)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public IActionResult DeleteInvoices(int id)
        {
            var invoice = _context.Invoices.Find(id);

            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
