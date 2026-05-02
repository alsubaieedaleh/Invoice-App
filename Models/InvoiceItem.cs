namespace invoiceApp.Models;

public class InvoiceItem{
    public int Id { get; set;}
    public int InvoiceId { get; set;}
    public string ItemName { get; set;}
    public string Description { get; set;}
    public decimal Price { get; set;}
    public int Amount { get; set;}
}