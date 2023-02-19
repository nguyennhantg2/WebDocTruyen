using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDocTruyen.Models
{
    public partial class DB_Truyen : DbContext
    {
        public DB_Truyen()
            : base("name=DB_Truyen")
        {
        }

        public virtual DbSet<LICHSUDOCTRUYEN> LICHSUDOCTRUYENs { get; set; }
        public virtual DbSet<LICHSUWEB> LICHSUWEBs { get; set; }
        public virtual DbSet<TRUYEN> TRUYENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TRUYEN>()
                .Property(e => e.LINKAVATAR)
                .IsUnicode(false);
        }
    }
}
