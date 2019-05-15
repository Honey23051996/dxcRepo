namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Following")]
    public partial class Following
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string userid { get; set; }

        [Required]
        [StringLength(25)]
        public string followingid { get; set; }

        public virtual Person PERSON { get; set; }

        public virtual Person PERSON1 { get; set; }
    }
}
