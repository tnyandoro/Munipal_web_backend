using MunicipalityApp.Models;

public class Bill
{
    public int Id { get; set; }
    public int CustomerId { get; set; } // Foreign Key to Customer
    public decimal Amount { get; set; }
    public string Status { get; set; } = string.Empty; // Default value to avoid null warnings
    public DateTime GeneratedDate { get; set; }
    public DateTime DueDate { get; set; }

    // Navigation properties
    public Customer Customer { get; set; } = new Customer(); // Initialize to avoid null warnings
    public ICollection<Payment> Payments { get; set; } = new List<Payment>(); // Initialize to avoid null warnings
}
