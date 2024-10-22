namespace MunicipalityApp.Models{


public class MeterReading
{
    public int Id { get; set; }
    public int MeterId { get; set; }  // Foreign Key to Meter
    public decimal Reading { get; set; }
    public int CapturedById { get; set; }  // Foreign Key to MeterReader
    public DateTime CapturedDate { get; set; }
    public DateTime CreatedAt { get; set; }

    // Navigation properties
    public Meter Meter { get; set; }
    public MeterReader CapturedBy { get; set; }
}

}
