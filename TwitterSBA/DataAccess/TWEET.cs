namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TWEET")]
    public partial class Tweet
    {
        [Key]
        public int tweet_id { get; set; }

        [Required]
        [StringLength(25)]
        public string Useridd { get; set; }

        [Required]
        [StringLength(140)]
        public string usermessage { get; set; }

        public DateTime created { get; set; }

        public virtual Person PERSON { get; set; }
    }
}
