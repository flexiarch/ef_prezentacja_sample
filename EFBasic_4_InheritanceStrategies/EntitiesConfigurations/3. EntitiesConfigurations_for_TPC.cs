using EFBasic_4_InheritanceStrategies.Entities.TPC;
using System.Data.Entity.ModelConfiguration;

namespace EFBasic_4_InheritanceStrategies.EntitiesConfigurations.TPC
{
    internal class ParameterConfiguration : EntityTypeConfiguration<Tpc_Parameter>
    {
        public ParameterConfiguration()
        {
            Property(p => p.CodeName).HasColumnName("CodeName")
                .IsUnicode().HasMaxLength(64).IsRequired();
        }
    }

    internal class ParameterStringConfiguration : EntityTypeConfiguration<Tpc_ParameterString>
    {
        public ParameterStringConfiguration()
        {
            Map(d => d.MapInheritedProperties());
            ToTable("ParametersString", "TPC");

            Property(p => p.Value).HasColumnName("ValueString").IsUnicode().HasMaxLength(512)
                .IsRequired();

        }
    }

    internal class ParameterBooleanConfiguration : EntityTypeConfiguration<Tpc_ParameterBoolean>
    {
        public ParameterBooleanConfiguration()
        {
            Map(d => d.MapInheritedProperties());
            ToTable("ParameterBoolean", "TPC");

            Property(p => p.Value).HasColumnName("ValueBoolean")
                .IsRequired();
        }
    }

    internal class ParameterSpecialConfiguration : EntityTypeConfiguration<Tpc_ParameterSpecial>
    {
        public ParameterSpecialConfiguration()
        {
            Map(d => d.MapInheritedProperties());
            ToTable("ParameterSpecial", "TPC");

            Property(p => p.RiskSum).HasColumnName("RiskSum").HasColumnType("decimal").HasPrecision(19, 6)
                .IsRequired();
            Property(p => p.SelectedOption).HasColumnName("SelectedOption").HasColumnType("bit")
                .IsRequired();

        }
    }
}
