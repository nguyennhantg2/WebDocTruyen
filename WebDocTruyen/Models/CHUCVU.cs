namespace WebDocTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHUCVU")]
    public partial class CHUCVU
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDCHUCVU { get; set; }

        [StringLength(50)]
        public string TENCHUCVU { get; set; }
    }
}
