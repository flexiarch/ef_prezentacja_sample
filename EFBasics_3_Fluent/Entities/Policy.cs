using System;

namespace EFBasics_3_Fluent.Entities
{
    public class Policy : IAuditable
    {
        public Guid PolicyId { get; set; } = Guid.NewGuid();
        public string PolicyNumber { get; set; }
        public int Premium { get; set; }
        public virtual Policyholder Policyholder { get; set; }
        public Audit Audit { get; set; }
        public Audit Audit2 { get; set; }
    }
}
