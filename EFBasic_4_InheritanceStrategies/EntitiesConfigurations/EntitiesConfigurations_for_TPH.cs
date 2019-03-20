using EFBasic_4_InheritanceStrategies.Entities.TPH;
using System.Data.Entity.ModelConfiguration;

namespace EFBasic_4_InheritanceStrategies.EntitiesConfigurations.TPH
{
    internal class ParameterConfiguration : EntityTypeConfiguration<TphParameter>
    {
        public ParameterConfiguration()
        {
            ToTable("Parameters", "TPH");

            Property(p => p.CodeName).HasColumnName("CodeName")
                .IsUnicode().HasMaxLength(64).IsRequired();

            //Ewentualna zmiana nazwy kolumny 'discriminator' i jej typu danych:
            /*
            Map<ParameterString>(p => p.Requires("Type").HasValue<int>(0));
            Map<ParameterBoolean>(p => p.Requires("Type").HasValue<int>(1));
            Map<ParameterSpecial>(p => p.Requires("Type").HasValue<int>(2));
            */
        }
    }

    internal class ParameterStringConfiguration : EntityTypeConfiguration<Tph_ParameterString>
    {
        public ParameterStringConfiguration()
        {
            Property(p => p.Value).HasColumnName("ValueString").IsUnicode().HasMaxLength(512);
        }
    }

    internal class ParameterBooleanConfiguration : EntityTypeConfiguration<Tph_ParameterBoolean>
    {
        public ParameterBooleanConfiguration()
        {
            Property(p => p.Value).HasColumnName("ValueBoolean");
        }
    }

    internal class ParameterSpecialConfiguration : EntityTypeConfiguration<Tph_ParameterSpecial>
    {
        public ParameterSpecialConfiguration()
        {
            Property(p => p.RiskSum).HasColumnName("RiskSum").HasColumnType("decimal").HasPrecision(19, 6);
            Property(p => p.SelectedOption).HasColumnName("SelectedOption").HasColumnType("bit");
        }
    }
}
