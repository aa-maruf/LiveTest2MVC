using System.ComponentModel.DataAnnotations;

namespace LiveTest2MVC.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public required string LastName { get; set; }

        public UserRole Role { get; set; }

        //public string FullName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }


    public enum UserRole
    {
        Admin,
        Manager,
        Salesman
    }
}
