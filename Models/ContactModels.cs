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
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }


        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "Ange giltig ålder!")]
        public int Age { get; set; }

        [Required]
        [StringLength(160, MinimumLength = 3)]
        [RegularExpression(@"^([a-zA-Z0-9_-.]+)@(([[0-9]{1,3}.[0-9]{1,3}.[0-9]{1,3}.)|(([a-zA-Z0-9-]+.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(]?)$", ErrorMessage = "Ange en giltig Email!")]
        public string Email { get; set; }

        [Compare("Email")]
        public string EmailConfirm { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Var god skriv ett giltigt telefonnummer")]
        public string PhoneNumber { get; set; }
    }
}