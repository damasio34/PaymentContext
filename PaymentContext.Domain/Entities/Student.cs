using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;

        public Student(string firstName, string lastName, string document, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Document = document;
            this.Email = email;
            this._subscriptions = new List<Subscription>();

            /* 
                Quando tenho os inputs das propriedades apenas no contrutor, garanto ter apenas um ponto de entrada, 
                possibilidando a validação dos dados em apenas uma vez.
                Open Close Principle: A classe está aberta para extensões, mas fechada para modificações, 
                ou seja, ninguém de fora da classe pode alterar esses dados.
            */
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        /*
            O tipo da lista foi alterado para IReadOnlyCollection, 
            pois como há um método para inserção de novas assinaturas, 
            esse deve ser o único canal de entrada possível para novas assinaturas, 
            garantindo assim que serão feitas todas as validações.
        */
        public IReadOnlyCollection<Subscription> Subscriptions => this._subscriptions.ToArray();
        
        public void AddSubscription(Subscription subscription)
        {
            /*
                Regra: Não pode haver duas assinaturas ativas
                    Se já tiver uma assinatura ativa, cancela
                    Toodas as outras assinaturas em inativas e coloca esta como ativa
            */

            foreach (var sub in this._subscriptions.Where(p => p.Active))
            {
                sub.Inactivate();
            }

            this._subscriptions.Add(subscription);
        }
    }
}