using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationTask.Models
{
    public class LoginModel
    {
       

        [Required]
        [EmailAddress]
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
       
    }
}