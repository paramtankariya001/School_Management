using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Subject { get; set; }
        
        [Required]
        public string Department { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }
        
        public string Phone { get; set; }
        public string Qualification { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Address { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
