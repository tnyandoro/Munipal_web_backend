namespace MunicipalityApp.Models
{
public class Bill
{
    public int Id { get; set; }
    public int CustomerId { get; set; }  // Foreign Key to Customer
    public decimal Amount { get; set; }
    public string Status { get; set; }  // Pending or Paid
    public DateTime GeneratedDate { get; set; }
    public DateTime DueDate { get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
}