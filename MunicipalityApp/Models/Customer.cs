namespace MunicipalityApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string IDNumber { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? WaterMeterId { get; set; } // Foreign Key to Water Meter
        public int? ElectricityMeterId { get; set; } // Foreign Key to Electricity Meter

        // Navigation properties
        public ICollection<Bill>? Bills { get; set; }
        public ICollection<Payment>? Payments { get; set; } // Navigation property for Payments
        public Meter? WaterMeter { get; set; }
        public Meter? ElectricityMeter { get; set; }
        public ICollection<Fault>? Faults { get; set; }
    }
}
