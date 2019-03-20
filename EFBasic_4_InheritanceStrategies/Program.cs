using System.Data.Entity;
using static System.Console;

namespace EFBasic_4_InheritanceStrategies
{

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Dropping database if need");
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BasicContext>());

            using (var context = new BasicContext())
            {
                context.ParametersTph.Add(new Entities.TPH.ParameterBoolean("Wartość boolowa 0", false));
                context.ParametersTph.Add(new Entities.TPH.ParameterBoolean("Wartość boolowa 1", true));
                context.ParametersTph.Add(new Entities.TPH.ParameterBoolean("Wartość boolowa null", null));

                context.ParametersTph.Add(new Entities.TPH.ParameterString("Tekst 0", "Wartość tekstowa"));
                context.ParametersTph.Add(new Entities.TPH.ParameterString("Tekst 1", null));

                context.ParametersTph.Add(new Entities.TPH.ParameterSpecial("Dwie kolumny 0", 9.99m, true));
                context.ParametersTph.Add(new Entities.TPH.ParameterSpecial("Dwie kolumny 1", null, null));

                context.SaveChanges();
                WriteLine("Zapisano...");
            }
        }
    }
}
