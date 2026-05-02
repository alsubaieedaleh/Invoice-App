using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using invoiceApp.Data;
using invoiceApp.Models;

namespace invoiceApp.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly InvoiceDbContext _context;

        public InvoiceController(InvoiceDbContext context)
        {
            _context = context;
        }

      
        public IActionResult Index()
        {
            var invoices = _context.Invoices
                .Include(i => i.Customer)  
                .Include(i => i.Items)      
                .ToList();
            return View(invoices);
        }

      
        public IActionResult Create()
        {
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        
        [HttpPost]
        public IActionResult Create(Invoice invoice, List<InvoiceItem> Items)
        {
            invoice.Date = DateTime.Now;
            invoice.Items = Items;
            invoice.Total = Items.Sum(item => item.Price * item.Amount);

            _context.Invoices.Add(invoice);
            _context.SaveChanges();
            TempData["Success"] = "Invoice created successfully!"; 
            return RedirectToAction("Index");
        }

      
        public IActionResult Details(int id)
        {
            var invoice = _context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Items)
                .FirstOrDefault(i => i.Id == id);

            if (invoice == null) return NotFound();
            return View(invoice);
        }

       
        public IActionResult Delete(int id)
        {
            var invoice = _context.Invoices
                .Include(i => i.Customer)
                .FirstOrDefault(i => i.Id == id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var invoice = _context.Invoices
                .Include(i => i.Items)
                .FirstOrDefault(i => i.Id == id);
            if (invoice != null)
            {
                _context.InvoiceItems.RemoveRange(invoice.Items);
                _context.Invoices.Remove(invoice);
                _context.SaveChanges();
                TempData["Success"] = "Invoice deleted successfully!";
            }
            return RedirectToAction("Index");
        }
    }
}
