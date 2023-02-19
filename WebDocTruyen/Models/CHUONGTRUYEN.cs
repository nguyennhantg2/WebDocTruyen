namespace WebDocTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUONGTRUYEN")]
    public partial class CHUONGTRUYEN
    {
        [Key]
        public int IDCHAP { get; set; }

        public int IDTRUYEN { get; set; }

        [Required]
        public string TENCHAP { get; set; }

        [Required]
        [StringLength(500)]
        public string LINKTRUYEN { get; set; }

        public int BATDAU { get; set; }

        public int KETTHUC { get; set; }

        [Required]
        [StringLength(10)]
        public string DUOIANH { get; set; }

        public int? LUOTXEM { get; set; }

        public int? LUOTTHEODOI { get; set; }

        public DateTime? TIMEPOST { get; set; }
    }
}
