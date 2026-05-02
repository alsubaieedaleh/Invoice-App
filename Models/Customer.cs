using System.ComponentModel.DataAnnotations;
namespace invoiceApp.Models;

public class Customer
{
    public int Id { get; set; }
     [Required(ErrorMessage = "Customer name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Invalid phone number format")]
    public string Phone { get; set; }
    [Required(ErrorMessage = "Address is required")]
    [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
    public string Address { get; set; }
}