using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription();
            var name = new Name("Darlan", "Damasio");
            var document = new Document("85907745037", EDocumentType.CPF);
            var email = new Email("darlan@damasio34.com");
            // Foi criado uma construtor para tornar mais claro o que uma classe precisa para ser construída
            var student = new Student(name, document, email);
            student.AddSubscription(subscription);
        }
    }
}
