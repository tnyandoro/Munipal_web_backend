namespace MunicipalityApp.Models
{
    public class Meter
    {
        public int Id { get; set; }
        public string ?MeterNumber { get; set; }
        public string ?UtilityType { get; set; }  // Water or Electricity
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public ICollection<Customer> ?WaterCustomers { get; set; }  // Add this navigation property
        public ICollection<Customer> ?ElectricityCustomers { get; set; }  // Add this navigation property
        public ICollection<MeterReading> ?MeterReadings { get; set; }
    }
}
