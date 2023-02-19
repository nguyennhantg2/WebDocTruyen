using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebDocTruyen.Models
{
    public partial class DB_Chapter : DbContext
    {
        public DB_Chapter()
            : base("name=DB_Chapter")
        {
        }

        public virtual DbSet<CHUONGTRUYEN> CHUONGTRUYENs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHUONGTRUYEN>()
                .Property(e => e.LINKTRUYEN)
                .IsUnicode(false);

            modelBuilder.Entity<CHUONGTRUYEN>()
                .Property(e => e.DUOIANH)
                .IsUnicode(false);
        }
    }
}
