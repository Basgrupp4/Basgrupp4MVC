using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Basgrupp4MVC.Models
{
    public class ContactModels
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The first name must contain 1 to 20 letters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "The last name must contain 1 to 20 letters")]
        public string LastName { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Age must be valid")]
        public int Age { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 3)]
        [EmailAddress]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Compare("Email")]
        public string EmailConfirm { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Phonenumber is not valid")]
        public string PhoneNumber { get; set; }
    }
}