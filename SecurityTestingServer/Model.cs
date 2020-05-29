namespace SecurityTestingServer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<CheckProduct> CheckProduct { get; set; }
        public virtual DbSet<CheckTime> CheckTime { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckProduct>()
                .Property(e => e.Id)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CheckTime>()
                .Property(e => e.Id)
                .IsFixedLength();
        }
    }
}
