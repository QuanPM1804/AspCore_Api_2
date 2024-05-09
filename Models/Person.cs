using System.ComponentModel.DataAnnotations;

namespace AspCore_Api_2.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName => LastName + ' ' + FirstName;
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string BirthPlace { get; set; }
    }
}
