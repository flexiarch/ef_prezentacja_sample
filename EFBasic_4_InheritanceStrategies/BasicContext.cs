using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace EFBasic_4_InheritanceStrategies
{
    internal class BasicContext : DbContext
    {
        // tph - table per hierarchy
        public virtual DbSet<Entities.TPH.TphParameter> ParametersTph { get; set; }

        // tpt - table per type
        public virtual DbSet<Entities.TPT.Tpt_Parameter> ParametersTpt { get; set; }

        // tpc - table per concrette classe
        public virtual DbSet<Entities.TPC.Tpc_Parameter> ParametersTpc { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
