namespace WebDocTruyen.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LICHSUWEB")]
    public partial class LICHSUWEB
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDHISTORY { get; set; }

        [Required]
        [StringLength(500)]
        public string ACTION { get; set; }

        public int IDUSER { get; set; }

        public DateTime TIME { get; set; }
    }
}
