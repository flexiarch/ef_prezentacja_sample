using System;
using System.Collections.Generic;

namespace EFBasics_3_Fluent.Entities
{
    public class Policy : IAuditable
    {
        public Guid PolicyId { get; set; } = Guid.NewGuid();
        public string PolicyNumber { get; set; }
        public int Premium { get; set; }
        public virtual Policyholder Policyholder { get; set; }
        public virtual ICollection<InsuredPerson> Insureds { get; set; } = new List<InsuredPerson>();

        public Audit Audit { get; set; }
    }
}
