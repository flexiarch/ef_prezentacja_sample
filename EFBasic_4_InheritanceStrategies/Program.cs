using EFBasic_4_InheritanceStrategies.Entities.TPC;
using EFBasic_4_InheritanceStrategies.Entities.TPH;
using EFBasic_4_InheritanceStrategies.Entities.TPT;
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
                context.ParametersTph.Add(new Tph_ParameterBoolean("Wartość boolowa 0", false));
                context.ParametersTph.Add(new Tph_ParameterBoolean("Wartość boolowa 1", true));
                context.ParametersTph.Add(new Tph_ParameterBoolean("Wartość boolowa null", null));
                context.ParametersTph.Add(new Tph_ParameterString("Tekst 0", "Wartość tekstowa"));
                context.ParametersTph.Add(new Tph_ParameterString("Tekst 1", null));
                context.ParametersTph.Add(new Tph_ParameterSpecial("Dwie kolumny 0", 9.99m, true));
                context.ParametersTph.Add(new Tph_ParameterSpecial("Dwie kolumny 1", null, null));
                #endregion

                #region TPT
                context.ParametersTpt.Add(new Tpt_ParameterBoolean("Wartość boolowa 0", false));
                context.ParametersTpt.Add(new Tpt_ParameterBoolean("Wartość boolowa 1", true));
                context.ParametersTpt.Add(new Tpt_ParameterString("Tekst", "Wartość tekstowa"));
                context.ParametersTpt.Add(new Tpt_ParameterSpecial("Dwie kolumny", 8.67m, false));
                #endregion


                #region TPC
                context.ParametersTpc.Add(new Tpc_ParameterBoolean("Wartość boolowa 0", false));
                context.ParametersTpc.Add(new Tpc_ParameterBoolean("Wartość boolowa 1", true));
                context.ParametersTpc.Add(new Tpc_ParameterString("Tekst", "Wartość tekstowa"));
                context.ParametersTpc.Add(new Tpc_ParameterSpecial("Dwie kolumny", 8.67m, false)); 
                #endregion

                context.SaveChanges();
                WriteLine("Zapisano...");
            }
        }
    }
}
