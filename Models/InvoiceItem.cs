using System.ComponentModel.DataAnnotations;

namespace invoiceApp.Models;

public class InvoiceItem{
    public int Id { get; set;}
    public int InvoiceId { get; set;}

    [Required(ErrorMessage = "Item name is required")]
    public string ItemName { get; set;}

    public string? Description { get; set;}   

    [Required(ErrorMessage = "Price is required")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set;}

    [Required(ErrorMessage = "Amount is required")]
    [Range(1, int.MaxValue, ErrorMessage = "Amount must be at least 1")]
    public int Amount { get; set;}
}
