namespace WebDocTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USER")]
    public partial class USER
    {
        [Key]
        public int IDUSER { get; set; }

        [StringLength(500)]
        public string LINKAVATAR { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string USERNAME { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string PASSWORD { get; set; }

        [StringLength(50)]
        public string FULLNAME { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string EMAIL { get; set; }

        public int? GENDER { get; set; }

        public DateTime JOINDATE { get; set; }

        public int IDCHUCVU { get; set; }

    }
}
