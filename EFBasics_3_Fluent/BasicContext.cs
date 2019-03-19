using EFBasics_3_Fluent.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EFBasics_3_Fluent
{
    public class BasicContext : DbContext
    {
        public virtual DbSet<Policy> Policy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(GetType().Assembly);
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;
            var user = Environment.UserName;


            var added = ChangeTracker
                .Entries<IAuditable>()
                .Where(_ => _.State == EntityState.Added);

            foreach (var item in added)
            {
                if (item.Entity.Audit == null)
                    item.Entity.Audit = new Audit();

                item.Entity.Audit.CreateDate = now;
                item.Entity.Audit.CreateBy = user;
            }


            var modified = ChangeTracker
                .Entries<IAuditable>()
                .Where(_ => _.State == EntityState.Modified);

            foreach (var item in modified)
            {
                item.Entity.Audit.UpdateDate = now;
                item.Entity.Audit.UpdateBy = user;
            }

            return base.SaveChanges();
        }
    }
}
