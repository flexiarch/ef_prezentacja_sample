using System.Data.Entity;
using static System.Console;

namespace EFBasic_4_InheritanceStrategies
{

    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BasicContext>());

            using (var context = new BasicContext())
            {
                #region TPH
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterBoolean("Wartość boolowa 0", false));
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterBoolean("Wartość boolowa 1", true));
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterBoolean("Wartość boolowa null", null));
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterString("Tekst 0", "Wartość tekstowa"));
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterString("Tekst 1", null));
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterSpecial("Dwie kolumny 0", 9.99m, true));
                context.ParametersTph.Add(new Entities.TPH.Tph_ParameterSpecial("Dwie kolumny 1", null, null));
                #endregion

                #region TPT
                context.ParametersTpt.Add(new Entities.TPT.Tpt_ParameterBoolean("Wartość boolowa 0", false));
                context.ParametersTpt.Add(new Entities.TPT.Tpt_ParameterBoolean("Wartość boolowa 1", true));
                context.ParametersTpt.Add(new Entities.TPT.Tpt_ParameterString("Tekst", "Wartość tekstowa"));
                context.ParametersTpt.Add(new Entities.TPT.Tpt_ParameterSpecial("Dwie kolumny", 8.67m, false));
                #endregion

                context.SaveChanges();
                WriteLine("Zapisano...");
            }
        }
    }
}
