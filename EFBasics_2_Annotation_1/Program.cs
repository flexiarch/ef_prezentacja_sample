/*
 * 2019-03-14 - Adam Kostecki
 * Podstawy Entity Framework
 * O konfigurowaniu przy użyciu DataAnnotations (atrybutów).
 */

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using static System.Console;

/// <summary>
/// Data annotations
/// /// </summary>
namespace EFBasics
{
    #region Encje
    [Table("Polisy", Schema = "Kalkulacje")]
    class Policy
    {
        [Key]
        public int PolicyNumber { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "Za krótka")]
        [MaxLength(10, ErrorMessage = "Za długa")]
        public string Policyholder { get; set; }

        [Required(ErrorMessage = "Jest wymagana")]
        [Range(100, 150, ErrorMessage = "Kwota musi być w przedziale 100 a 150")]
        public int Premium { get; set; }

        [NotMapped]
        public int InnerValue { get; set; }
    }
    #endregion

    #region Context
    class BasicContext : DbContext
    {
        public virtual DbSet<Policy> Policy { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
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
                ctx.Policy.Add(new Policy
                {
                    Policyholder = "ABCDEF",
                    Premium = 123
                });

                try
                {
                    ctx.SaveChanges();
                    WriteLine("Zapisano!");
                }
                catch (DbEntityValidationException validation)
                {
                    WriteLine("Zakończono niepowodzeniem z powodu znalezionych błędów:\n");
                    int i = 0;
                    foreach (var errorsPerType in validation.EntityValidationErrors)
                    {
                        WriteLine (
                            $"{++i}. Walidatory typu: '{errorsPerType.Entry.Entity.GetType().Name}' zgłosił następujące problemy:\n"
                        );
                        foreach (var error in errorsPerType.ValidationErrors)
                        {
                            WriteLine($"Właściwość: '{error.PropertyName}' - {error.ErrorMessage}");
                        }
                    }
                }
            }

            WriteLine("...end");
            ReadKey();
        }
    }
    #endregion
}
