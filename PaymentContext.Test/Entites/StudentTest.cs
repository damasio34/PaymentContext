using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Test
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var subscription = new Subscription();
            // Foi criado uma construtor para tornar mais claro o que uma classe precisa para ser construída
            var student = new Student("Darlan", "Damasio", "85907745037", "darlan@damasio34.com");
            student.AddSubscription(subscription);
        }
    }
}
