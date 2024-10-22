namespace MunicipalityApp.Models{


public class Fault
{
    public int Id { get; set; }
    public int CustomerId { get; set; }  // Foreign Key to Customer
    public string Description { get; set; }
    public string Status { get; set; }  // Open, InProgress, Resolved
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Customer Customer { get; set; }
}

}
