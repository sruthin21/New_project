using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewProject2.Models
{
    public class Student
    {
        [Key]
        [MaxLength(100)]
        public string SubjectName { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")] // Adjusted data type
        public decimal InternalMarksMaximum { get; set; }

        [Column(TypeName = "decimal(10, 2)")] // Adjusted data type
        public decimal InternalMarksSecured { get; set; }

        [Column(TypeName = "decimal(10, 2)")] // Adjusted data type
        public decimal SemesterMarksMaximum { get; set; }

        [Column(TypeName = "decimal(10, 2)")] // Adjusted data type
        public decimal SemesterMarksSecured { get; set; }
    }
}
