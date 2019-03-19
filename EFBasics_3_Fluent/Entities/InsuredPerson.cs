using System;

namespace EFBasics_3_Fluent.Entities
{
    public class InsuredPerson
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }

        public virtual Policy Policy { get; set; }

        protected InsuredPerson()
        {
        }

        public InsuredPerson(string firstName, string lastName, DateTime? birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
    }
}
