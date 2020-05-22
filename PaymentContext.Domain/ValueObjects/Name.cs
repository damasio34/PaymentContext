using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome deve conter ao menos 3 caracteres.")
                .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres.")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Nome deve conter ao menos 3 caracteres.")                
            );

            /*
                Troquei a implementação acima pela comentada abaixo usando a biblioteca flunt, 
                com a proposta de não precisar testar (pois de acordo com a documentação, 
                a biblioteca já executa esses testes) e também facilita na leitura do código.

            */

            // if(string.IsNullOrEmpty(this.FirstName))
            //     AddNotification("Name.FirstName", "Nome inválido");
            // if(string.IsNullOrEmpty(this.LastName))
            //     AddNotification("Name.LastName", "Nome inválido");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() =>  $"{this.FirstName} {this.LastName}";
    }
}