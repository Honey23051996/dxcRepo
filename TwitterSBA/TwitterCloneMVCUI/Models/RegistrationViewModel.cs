using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TwitterCloneMVCUI.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [StringLength(25)]
        public string UserID { get; set; }

        [Required]
        [StringLength(50), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(50), DataType(DataType.Password), Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }

        [Required]
        [StringLength(50), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}