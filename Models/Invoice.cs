using System.ComponentModel.DataAnnotations;

namespace invoiceApp.Models;

public class Invoice {
    public int Id { get; set;}

    [Required(ErrorMessage = "Please select a customer")]
    public int CustomerId { get; set;}

    public Customer? Customer { get; set; }
    public DateTime Date { get; set;}
    public List<InvoiceItem> Items { get; set;} = new List<InvoiceItem>();
    public decimal Total { get; set;}
}
