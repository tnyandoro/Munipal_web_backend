namespace MunicipalityApp.Models{


public class MeterReader
{
    public int Id { get; set; }
    public string ?Name { get; set; }
    public string ?Email { get; set; }
    public string ?ContactNumber { get; set; }
    public string ?EmployeeId { get; set; }
    public string ?AssignedArea { get; set; }
    public string ?Username { get; set; }
    public string ?PasswordHash { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public ICollection<MeterReading> ?MeterReadings { get; set; }
}
}