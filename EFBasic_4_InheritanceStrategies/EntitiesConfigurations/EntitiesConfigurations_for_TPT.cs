using EFBasic_4_InheritanceStrategies.Entities.TPT;
using System.Data.Entity.ModelConfiguration;

namespace EFBasic_4_InheritanceStrategies.EntitiesConfigurations.TPT
{
    internal class ParameterConfiguration : EntityTypeConfiguration<TptParameter>
    {
        public ParameterConfiguration()
        {
            ToTable("Parameters", "TPT");
            Property(p => p.CodeName).HasColumnName("CodeName")
                .IsUnicode().HasMaxLength(64).IsRequired();
        }
    }

    internal class ParameterStringConfiguration : EntityTypeConfiguration<Tpt_ParameterString>
    {
        public ParameterStringConfiguration()
        {
            ToTable("ParametersString", "TPT");
            Property(p => p.Value).HasColumnName("ValueString").IsUnicode().HasMaxLength(512)
                .IsRequired();
        }
    }

    internal class ParameterBooleanConfiguration : EntityTypeConfiguration<Tpt_ParameterBoolean>
    {
        public ParameterBooleanConfiguration()
        {
            ToTable("ParameterBoolean", "TPT");
            Property(p => p.Value).HasColumnName("ValueBoolean")
                .IsRequired();
        }
    }

    internal class ParameterSpecialConfiguration : EntityTypeConfiguration<Tpt_ParameterSpecial>
    {
        public ParameterSpecialConfiguration()
        {
            ToTable("ParameterSpecial", "TPT");
            Property(p => p.RiskSum).HasColumnName("RiskSum").HasColumnType("decimal").HasPrecision(19, 6)
                .IsRequired();
            Property(p => p.SelectedOption).HasColumnName("SelectedOption").HasColumnType("bit")
                .IsRequired();
        }
    }
}
