using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EFBasic_4_InheritanceStrategies
{
    internal class BasicContext : DbContext
    {
        // tph - table per hierarchy
        public virtual DbSet<Entities.TPH.TphParameter> ParametersTph { get; set; }

        // tpt - table per type
        public virtual DbSet<Entities.TPT.TptParameter> ParametersTpt { get; set; }


        // tpc - table per concrette classe
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EntityBase>().HasKey(key => key.Id);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
