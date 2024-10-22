namespace MunicipalityApp.Models
{


public class Role
{
    public int Id { get; set; }
    public string RoleName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // Navigation properties
    public ICollection<User> Users { get; set; }
}

}