namespace Example.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1(string connectionName)
            : base(connectionName)
        {
        }

        public virtual DbSet<employee> employees { get; set; }
        public virtual DbSet<main_table> main_table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employee>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<employee>()
                .HasMany(e => e.main_table)
                .WithRequired(e => e.employee)
                .WillCascadeOnDelete(false);
        }
    }
}
