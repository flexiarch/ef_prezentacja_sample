using EFBasics_3_Fluent.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBasics_3_Fluent.FluentConfigurations
{
    internal class InsuredPersonConfiguration : EntityTypeConfiguration<InsuredPerson>
    {
        public InsuredPersonConfiguration()
        {
            ToTable("Insureds", "Policy");
            HasKey(key => key.Id);

            Property(key => key.Id)
                .HasColumnName("InsuredId")
                .HasColumnType("uniqueidentifier")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnOrder(1)
            ;

            Property(p => p.FirstName)
                .HasColumnType("varchar").IsUnicode()
                .HasMaxLength(50)
                .IsRequired()
            ;

            Property(p => p.LastName)
                .HasColumnType("varchar").IsUnicode()
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnName("LastName")
            ;

            Property(p => p.BirthDate)
                .HasColumnType("datetime").IsOptional()
                .HasColumnName("DateOfBirth")
            ;
        }
    }
}
