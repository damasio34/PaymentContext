using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test
{
    [TestClass]
    public class StudentTest
    {
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTest()
        {
            var name = new Name("Otávio César", "Assunção");
            var document = new Document("69364057546", EDocumentType.CPF);
            var email = new Email("ootaviocesarassuncao@conexao.com");
            var address = new Address(
                "Rua C", 
                "232", 
                "Distrito Industrial Simão da Cunha", 
                "Sabará", 
                "MG", 
                "Brasil", 
                "34735-030"
            );
            this._student = new Student(name, document, email, address);
            this._subscription = new Subscription();
        }

        [TestMethod]
        public void Should_Return_Success_When_Student_Is_Valid()
        {
            var name = new Name("Darlan", "Damasio");
            var document = new Document("85907745037", EDocumentType.CPF);
            var email = new Email("darlan@damasio34.com");
            var address = new Address(
                "Rua C", 
                "232", 
                "Distrito Industrial Simão da Cunha", 
                "Sabará", 
                "MG", 
                "Brasil", 
                "34735-030"
            );
            // Foi criado uma construtor para tornar mais claro o que uma classe precisa para ser construída
            var student = new Student(name, document, email, address);
            
            Assert.IsTrue(student.Valid);
        }

        [TestMethod]
        public void Should_Return_Errro_When_Had_Active_Subscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, this._student);

            this._subscription.AddPayment(payment);
            this._student.AddSubscription(this._subscription);
            this._student.AddSubscription(this._subscription);
            
            Assert.IsTrue(this._student.Invalid);
        }

        [TestMethod]
        public void Should_Return_Success_When_Had_No_Active_Subscription()
        {
            var payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, this._student);

            this._subscription.AddPayment(payment);
            this._student.AddSubscription(this._subscription);

            Assert.IsTrue(this._student.Valid);
        }

        [TestMethod]
        public void Should_Return_Error_When_Subscription_Has_No_Payment()
        {
            var subscription = new Subscription();
            this._student.AddSubscription(subscription);

            Assert.IsTrue(this._student.Invalid);
        }
    }
}
