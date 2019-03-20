using System;
using System.ComponentModel.DataAnnotations;

namespace EFBasic_4_InheritanceStrategies
{
    public abstract class EntityBase
    {
        [Key]
        public virtual Guid Id { get; protected set; } = Guid.NewGuid();

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EntityBase)obj);
        }

        private bool Equals(EntityBase other)
        {
            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
