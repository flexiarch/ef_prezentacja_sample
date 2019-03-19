using System;

namespace EFBasics_3_Fluent.Entities
{
    public class Policyholder : IAuditable
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Policy Policy { get; set; }
        public virtual Audit Audit { get; set; }
    }
}
