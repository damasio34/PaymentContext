using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            if(string.IsNullOrEmpty(this.FirstName))
                AddNotification("Name.FirstName", "Nome inválido");
            if(string.IsNullOrEmpty(this.LastName))
                AddNotification("Name.LastName", "Nome inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}