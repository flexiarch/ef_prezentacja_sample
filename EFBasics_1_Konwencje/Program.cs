/*
 * 2019-03-14 - Adam Kostecki
 * Podstawy Entity Framework
 * O konwencjach słów kilka.
 */

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using static System.Console;

/// <summary>
/// Konwencje w Entity Framework
/// System.Data.Entity.ModelConfiguration.Conventions 
//  https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.modelconfiguration.conventions?redirectedfrom=MSDN&view=entity-framework-6.2.0
/// </summary>
namespace EFBasics
{
    #region Encje
    class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Person()
        {
        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    #endregion

    #region Context
    class BasicContext : DbContext
    {
        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<IdKeyDiscoveryConvention>();
                                                                                                                                                                                                                                     //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
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
            Database.SetInitializer(new CreateDatabaseIfNotExists<BasicContext>());

            WriteLine("...instatiate context");
            using (var ctx = new BasicContext())
            {
                ctx.Persons.Add(new Person("Jan", "Kowalski"));
                ctx.Persons.Add(new Person("Paweł", "Nowak"));

                ctx.SaveChanges();
            }

            WriteLine("...end");
            ReadKey();
        }
    }
    #endregion
}
