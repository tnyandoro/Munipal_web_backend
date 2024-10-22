namespace MunicipalityApp.Models
{
public class Tariff
{
    public int Id { get; set; }
    public string UtilityType { get; set; }  
    public decimal MonthlyFixedRate { get; set; }
    public decimal MinReading { get; set; }
    public decimal MaxReading { get; set; }
    public decimal CostPerUnit { get; set; }
    public DateTime ActiveFrom { get; set; }
    public DateTime ActiveUntil { get; set; }
}
}
