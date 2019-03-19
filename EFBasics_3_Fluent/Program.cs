using EFBasics_3_Fluent.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using static System.Console;

namespace EFBasics_3_Fluent
{
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
                ctx.Policy
                .Add(new Policy
                {
                    PolicyNumber = "ABCDEF",
                    Premium = 123,
                    Policyholder = new Policyholder
                    {
                        FirstName = "Adam",
                        LastName = "Testowy"
                    }
                })
                .Insureds.AddRange
                (
                    new InsuredPerson("Kasia", "Testowa", null),
                    new InsuredPerson("Piotr", "Jakiś", new DateTime(1980, 5, 1))
                );

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
}
