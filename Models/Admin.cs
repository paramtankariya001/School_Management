using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; } // Should be hashed in practice

        public string FullName { get; set; }
    }
}
