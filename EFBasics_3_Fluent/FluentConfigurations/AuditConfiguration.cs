using EFBasics_3_Fluent.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EFBasics_3_Fluent.FluentConfigurations
{
    internal class AuditConfiguration : ComplexTypeConfiguration<Audit>
    {
        public AuditConfiguration()
        {
            Property(p => p.CreateBy)
                .HasColumnName(nameof(Audit) + "_Creator")
                .HasColumnType("varchar").HasMaxLength(50)
                .IsRequired()
            ;

            Property(p => p.CreateDate)
                .HasColumnName(nameof(Audit) + "_CreateDt")
                .HasColumnType("datetime2")
                .IsRequired()
            ;

            Property(p => p.UpdateBy)
                .HasColumnName(nameof(Audit) + "_Updater")
                .HasColumnType("varchar").HasMaxLength(50)
                .IsOptional()
            ;

            Property(p => p.UpdateDate)
                .HasColumnName(nameof(Audit) + "_UpdateDt")
                .HasColumnType("datetime2")
                .IsOptional()
            ;
        }
    }
}
