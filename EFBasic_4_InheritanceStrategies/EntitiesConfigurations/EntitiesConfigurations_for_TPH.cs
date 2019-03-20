using EFBasic_4_InheritanceStrategies.Entities.TPH;
using System.Data.Entity.ModelConfiguration;

namespace EFBasic_4_InheritanceStrategies.EntitiesConfigurations.TPH
{
    internal class ParameterConfiguration : EntityTypeConfiguration<Parameter>
    {
        public ParameterConfiguration()
        {
            ToTable("Parameters", "TPH");

            Property(p => p.CodeName).HasColumnName("CodeName")
                .IsUnicode().HasMaxLength(64).IsRequired() ;
        }
    }

    internal class ParameterStringConfiguration : EntityTypeConfiguration<ParameterString>
    {
        public ParameterStringConfiguration()
        {
            Property(p => p.Value).HasColumnName("ValueString").IsUnicode().HasMaxLength(512);
        }
    }

    internal class ParameterBooleanConfiguration : EntityTypeConfiguration<ParameterBoolean>
    {
        public ParameterBooleanConfiguration()
        {
            Property(p => p.Value).HasColumnName("ValueBoolean");
        }
    }

    internal class ParameterSpecialConfiguration : EntityTypeConfiguration<ParameterSpecial>
    {
        public ParameterSpecialConfiguration()
        {
            Property(p => p.RiskSum).HasColumnName("RiskSum").HasColumnType("decimal").HasPrecision(19, 6);
            Property(p => p.SelectedOption).HasColumnName("SelectedOption").HasColumnType("bit");
        }
    }
}
