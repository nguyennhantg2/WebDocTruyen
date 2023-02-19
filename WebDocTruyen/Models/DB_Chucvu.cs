using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDocTruyen.Models
{
    public partial class DB_Chucvu : DbContext
    {
        public DB_Chucvu()
            : base("name=DB_Chucvu")
        {
        }

        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUCVU>()
                .Property(e => e.TENCHUCVU)
                .IsUnicode(false);
        }
    }
}
