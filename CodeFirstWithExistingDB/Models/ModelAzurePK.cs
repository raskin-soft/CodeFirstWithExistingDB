using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstWithExistingDB.Models
{
    public partial class ModelAzurePK : DbContext
    {
        public ModelAzurePK()
            : base("name=ModelAzurePK")
        {
        }

        public virtual DbSet<WithPK> WithPKs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WithPK>()
                .Property(e => e.WithName)
                .IsFixedLength();
        }
    }
}
