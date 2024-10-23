namespace MunicipalityApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; } // Foreign Key to Customer
        public int BillId { get; set; } // Foreign Key to Bill
        public decimal PaymentAmount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Status { get; set; } // Successful or Failed

        // Navigation properties
        public Customer? Customer { get; set; }
        public Bill? Bill { get; set; }
    }
}
