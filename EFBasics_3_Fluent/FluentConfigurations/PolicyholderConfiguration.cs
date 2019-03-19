using EFBasics_3_Fluent.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EFBasics_3_Fluent.FluentConfigurations
{
    internal class PolicyholderConfiguration : EntityTypeConfiguration<Policyholder>
    {
        public PolicyholderConfiguration()
        {
            HasKey(k => k.Id);

            Property(p => p.FirstName)
                .HasColumnName("FirstName")
                .HasColumnType("varchar")
                .IsUnicode()
                .HasMaxLength(100)
                .IsRequired()
            ;

            Property(p => p.LastName)
                .HasColumnName("LastName")
                .HasColumnType("varchar")
                .IsUnicode()
                .HasMaxLength(100)
                .IsRequired()
            ;
        }
    }
}
