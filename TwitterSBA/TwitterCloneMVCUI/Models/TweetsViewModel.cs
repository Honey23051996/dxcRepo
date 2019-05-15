using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TwitterCloneMVCUI.Models
{
    public class TweetsViewModel
    {
        public int tweet_id { get; set; }

        
        [StringLength(25)]
        public string user_id { get; set; }

        [Required]
        [StringLength(140)]
        public string message { get; set; }

        public DateTime created { get; set; }
    }
}