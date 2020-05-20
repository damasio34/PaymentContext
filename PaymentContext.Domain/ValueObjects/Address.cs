using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public Address(string street, string number, string neighborhood, string city, string state, string country, string zipCode)
        {
            this.Street = street;
            this.Number = number;
            this.Neighborhood = neighborhood;
            this.City = city;
            this.State = state;
            this.Country = country;
            this.ZipCode = zipCode;

            if(string.IsNullOrEmpty(this.Street))
                AddNotification("Adress.Street", "Endereço inválido");
            if(string.IsNullOrEmpty(this.Number))
                AddNotification("Adress.Number", "Endereço inválido");
            if(string.IsNullOrEmpty(this.Neighborhood))
                AddNotification("Adress.Neighborhood", "Endereço inválido");
            if(string.IsNullOrEmpty(this.City))
                AddNotification("Adress.City", "Endereço inválido");
            if(string.IsNullOrEmpty(this.State))
                AddNotification("Adress.State", "Endereço inválido");
            if(string.IsNullOrEmpty(this.Country))
                AddNotification("Adress.Country", "Endereço inválido");
            if(string.IsNullOrEmpty(this.ZipCode))
                AddNotification("Adress.ZipCode", "Endereço inválido");
        }

        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
        public string ZipCode { get; private set; }
    }
}