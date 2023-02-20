using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace CodeFirstWithExistingDB.Models
{
    public partial class ModelAzureNoPK : DbContext
    {
        public ModelAzureNoPK()
            : base("name=ModelAzureNoPK")
        {
        }

        public virtual DbSet<WithoutPK> WithoutPKs { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WithoutPK>()
                .Property(e => e.WithoutName)
                .IsFixedLength();
        }
    }
}
