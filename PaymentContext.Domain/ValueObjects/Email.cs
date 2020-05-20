using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string address)
        {
            this.Address = address;

            if(string.IsNullOrEmpty(this.Address))
                AddNotification("Email.Address", "Email inválido");
        }

        public string Address { get; private set; }
    }
}