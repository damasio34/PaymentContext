using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this._subscriptions = new List<Subscription>();

            /* 
                Quando tenho os inputs das propriedades apenas no contrutor, garanto ter apenas um ponto de entrada, 
                possibilidando a validação dos dados em apenas uma vez.
                Open Close Principle: A classe está aberta para extensões, mas fechada para modificações, 
                ou seja, ninguém de fora da classe pode alterar esses dados.
            */

            AddNotifications(name, document, email);
        }

        /*
            Foram trocadas as propriedades FirstName e LastName pelo ValueObject Name, 
            a fim de centralizar todas as regras e validações relacionadas ao nome do aluno.            
        */
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
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

            var hasSubscriptionActive = false;
            foreach (var sub in this._subscriptions)
            {
                if(sub.Active) 
                {
                    hasSubscriptionActive = true;
                    break;
                    // sub.Inactivate();
                }
            }

            if(hasSubscriptionActive)
                AddNotification("Student.Subscriptions", "Você já tem uma assunatira ativa");
            else
                this._subscriptions.Add(subscription);
        }
    }
}