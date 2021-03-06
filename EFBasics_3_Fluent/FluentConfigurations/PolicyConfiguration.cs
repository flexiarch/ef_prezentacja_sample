﻿using EFBasics_3_Fluent.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace EFBasics_3_Fluent.FluentConfigurations
{
    internal class PolicyConfiguration : EntityTypeConfiguration<Policy>
    {
        public PolicyConfiguration()
        {
            ToTable("Policy", "Calculations");

            HasKey(k => k.PolicyId);

            Property(k => k.PolicyId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None)
                .HasColumnType("uniqueidentifier")
                .HasColumnName("PolicyID")
                .HasColumnOrder(1)
            ;

            Property(p => p.PolicyNumber)
                .HasColumnName("PolicyNumber")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(2)
            ;

            HasIndex(ik => ik.PolicyNumber).IsClustered(false).IsUnique(true);

            Property(p => p.Premium)
                .HasColumnName("Premium")
                .HasColumnType("int")
                .IsRequired()
                .HasColumnOrder(3)
            ;

            // 1 to 0..1
            //HasOptional(ph => ph.Policyholder).WithRequired(p => p.Policy).WillCascadeOnDelete();

            // 1 to 1
            HasRequired(ph => ph.Policyholder).WithRequiredPrincipal(p => p.Policy).WillCascadeOnDelete();

            // 1 to *
            HasMany(ins => ins.Insureds)
                .WithRequired(p => p.Policy)
                .Map(fkmapping => fkmapping.MapKey("PolicyId"))
                .WillCascadeOnDelete();
        }
    }
}
