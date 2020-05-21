using Flunt.Validations;
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

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.Street, 3, "Adress.Street", "A rua deve conter ao menos 3 caracteres.")
                .IsNotNullOrEmpty(this.Number, "Adress.Number", "Número inválido.")
                .IsNotNullOrEmpty(this.Neighborhood, "Adress.Neighborhood", "Bairro inválido.")
                .IsNotNullOrEmpty(this.City, "Adress.City", "Cidade inválida.")
                .IsNotNullOrEmpty(this.State, "Adress.State", "Estado inválido.")
                .IsNotNullOrEmpty(this.Country, "Adress.Country", "País inválido")
                .IsNotNullOrEmpty(this.ZipCode, "Adress.ZipCode", "CEP inválido.")
            );
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