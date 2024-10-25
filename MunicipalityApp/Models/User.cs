namespace MunicipalityApp.Models
{
    public class User
    {
        public int Id { get; set; }

        public string? Username { get; set; } // Nullable if not required, otherwise remove the '?'

        public string? PasswordHash { get; set; } // Assuming this can be null for cases like external login

        public string? Email { get; set; } // Nullable, but often you'd want this required

        public int RoleId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        // Navigation properties
        public Role? Role { get; set; } // Optional navigation to Role, set as nullable
    }
}
