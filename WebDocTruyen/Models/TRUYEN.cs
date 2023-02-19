namespace WebDocTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRUYEN")]
    public partial class TRUYEN
    {
        [Key]
        public int IDTRUYEN { get; set; }

        [Required]
        public string TENTRUYEN { get; set; }

        [StringLength(500)]
        public string LINKAVATAR { get; set; }

        [StringLength(200)]
        public string TACGIA { get; set; }

        public string NOIDUNG { get; set; }

        public int LUOTXEM { get; set; }
    }
}
