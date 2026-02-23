using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Required]
        public string Section { get; set; }

        public int? ClassTeacherId { get; set; }

        [ForeignKey("ClassTeacherId")]
        public Teacher? ClassTeacher { get; set; }
    }
}
