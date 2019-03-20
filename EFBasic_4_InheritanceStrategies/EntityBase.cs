using System;
using System.ComponentModel.DataAnnotations;

namespace EFBasic_4_InheritanceStrategies
{
    public class EntityBase
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
