using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TwitterCloneMVCUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(25)]
        public string UserID { get; set; }

        [Required]
        [StringLength(50), DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}