namespace MunicipalityApp.Models
{
public class CommunityServiceUpdate
{
    public int Id { get; set; }
    public string UpdateType { get; set; }  // News, Community Update
    public string Description { get; set; }
    public DateTime PublishedAt { get; set; }
}
}