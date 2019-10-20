using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirthdayApp.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage ="Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is Required")]
        [Phone]
        public string Phone { get; set; }
        public bool? WillAttend { get; set; }

    }
}