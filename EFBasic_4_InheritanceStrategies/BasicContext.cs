using System.Data.Entity;

namespace EFBasic_4_InheritanceStrategies
{
    internal class BasicContext : DbContext
    {
        // tph
        public virtual DbSet<Entities.TPH.Parameter> ParametersTph { get; set; }

        // tpt
        // tpc
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<EntityBase>().HasKey(key => key.Id);

            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
