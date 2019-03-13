/*
 * 2019-03-14 - Adam Kostecki
 * Podstawy Entity Framework
 * O konfigurowaniu przy użyciu DataAnnotations (atrybutów).
 * Typ kompleksowy
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static System.Console;
using System.Linq;

namespace EFBasics
{
    public interface IAuditable
    {
        Audit Audit { get; set; }
    }

    #region Encje
    [Table("Polisy", Schema = "Kalkulacje")]
    public class Policy : IAuditable
    {
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid PolicyId { get; set; } = Guid.NewGuid();

        [Index(IsClustered = false, IsUnique = true)]
        [Column(Order = 2)]
        [MaxLength(100)]
        public string PolicyNumber { get; set; }

        [Column(Order = 3)]
        public int Premium { get; set; }

        public virtual Policyholder Policyholder { get; set; }

        [Column(Order = 5)]
        public Audit Audit { get; set; }
    }

    [Table("Policyholder", Schema = "Kalkulacje")]
    public class Policyholder : IAuditable
    {
        [Key, ForeignKey("Policy")]
        public Guid PolicyId { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public virtual Policy Policy { get; set; }

        public Audit Audit { get; set; }
    }

    [ComplexType]
    public class Audit
    {
        [Required]
        [MaxLength(255)]
        public string CreateBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [MaxLength(255)]
        public string UpdateBy { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? UpdateDate { get; set; }
    }

    #endregion

    #region Context
    public class BasicContext : DbContext
    {
        public virtual DbSet<Policy> Policy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            var now = DateTime.Now;
            var user = System.Environment.UserName;


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
    #endregion

    #region Go
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("...droping and recreate database");
            /// baza testowa!
            Database.SetInitializer(new DropCreateDatabaseAlways<BasicContext>());

            WriteLine("...instatiate context");
            using (var ctx = new BasicContext())
            {
                //insert
                ctx.Policy.Add(new Policy
                {
                    PolicyNumber = "ABCDEF",
                    Premium = 123,
                    Policyholder = new Policyholder
                    {
                        FirstName = "Adam",
                        LastName = "Testowy"
                    }
                });
                ctx.SaveChanges();

                //insert i modyfikacja
                ctx.Policy.Add(new Policy
                {
                    PolicyNumber = "UKIIO",
                    Premium = 456,
                    Policyholder = new Policyholder
                    {
                        FirstName = "Jan",
                        LastName = "Testman"
                    }
                });

                var policy = ctx.Policy.Single(p => p.PolicyNumber == "ABCDEF");

                policy.Premium = 789;

                ctx.SaveChanges();

                WriteLine("Zapisano!");
            }

            using (var read = new BasicContext())
            {
                var myPolicies = read.Policy.ToList();

            }

                WriteLine("...end");
            ReadKey();
        }
    }
    #endregion
}
