using Microsoft.EntityFrameworkCore;
using invoiceApp.Models;
namespace invoiceApp.Data{
    public class InvoiceDbContext : DbContext {
        public InvoiceDbContext( DbContextOptions<InvoiceDbContext> options) : base(options){

        }
        public DbSet<Customer> Customers { get; set;}
        public DbSet<Invoice> Invoices { get; set;}
        public DbSet<InvoiceItem> InvoiceItems { get; set;}
    }
}