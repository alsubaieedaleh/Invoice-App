using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using invoiceApp.Data;
using invoiceApp.Models;
namespace invoiceApp.Controllers;

public class CustomerController : Controller {

    private readonly InvoiceDbContext _context;

    public CustomerController(InvoiceDbContext context){
        _context = context; 
    }


    public IActionResult Index() {
        var customers  = _context.Customers.ToList();
        return View(customers);
    }
    public IActionResult Create()
    {
        return View();
    }
       [HttpPost]
    public IActionResult Create(Customer customer){
         var exists = _context.Customers.Any(c => c.Phone == customer.Phone);
        if (exists){
            ModelState.AddModelError("Phone", "A customer with this phone number already exists!");
        }

        if (ModelState.IsValid){
            _context.Customers.Add(customer);
            _context.SaveChanges();
            TempData["Success"] = "Customer created successfully!";
            return RedirectToAction("Index");
        }
        return View(customer);
    }

    public IActionResult Edit(int id){
        var customer = _context.Customers.Find(id);
        if (customer == null){
            return NotFound();
        }
        return View(customer);
    }
        [HttpPost]
    public IActionResult Edit(Customer customer){
        var exists = _context.Customers.Any(c => c.Phone == customer.Phone && c.Id != customer.Id);
        if (exists){
            ModelState.AddModelError("Phone", "A customer with this phone number already exists!");
        }

        if (ModelState.IsValid){
            _context.Customers.Update(customer);
            _context.SaveChanges();
            TempData["Success"] = "Customer updated successfully!";
            return RedirectToAction("Index");
        }
        return View(customer);
    }

      public IActionResult Delete(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null) return NotFound();
            return View(customer);
        }
         [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                 TempData["Success"] = "Customer deleted successfully!";
            }
            return RedirectToAction("Index");
        }
} 