using System.ComponentModel.DataAnnotations;

namespace _200596751_Exam.Models  
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public required string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}
