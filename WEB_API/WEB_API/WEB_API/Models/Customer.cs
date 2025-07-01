

using System.ComponentModel.DataAnnotations;

namespace WEB_API.Models;

public class Customer
{
    [Key] 
    public int CustomerId { get; set; }

    [Required(ErrorMessage = "Customer Name is required...")]
    [MaxLength(100)]
    public string CustomerName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Customer Email is required...")]
    [MaxLength(100)]
    [EmailAddress]
    public string CustomerEmail { get; set; }

    [Required(ErrorMessage = "Customer Phone is required...")]
    [MaxLength(100)]
    public string CustomerPhone { get; set; }

    [Required(ErrorMessage = "Customer City is required...")]
    [MaxLength(100)]
    public string CustomerCity { get; set; }
}
