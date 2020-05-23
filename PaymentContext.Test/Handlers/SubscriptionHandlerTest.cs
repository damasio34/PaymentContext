using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Test.Mocks;

namespace PaymentContext.Test.Handlers
{
    [TestClass]
    public class SubscriptionHandlderTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void Should_Return_Error_When_Document_Exists() 
        {
            var studentRepository = new FakeStudentRepository();
            var emailService = new FakeEmailService();
            var handler = new SubscriptionHandler(studentRepository, emailService);
            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Iago João",
                LastName = "Peixoto",
                Document = "99999999999",
                Email = "iagojoaopeixoto_@cassianoricardo.com.br",
                BarCode = "",
                BoletoNumber = "",
                PaymentNumber = "",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "Iago João Peixoto",
                PayerDocument = "99999999999",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "iagojoaopeixoto_@cassianoricardo.com.br",
                PayerStreet = "Beco Acioly",
                PayerNumber = "413",
                PayerNeighborhood = "São Vicente de Paula",
                PayerCity = "Parintins",
                PayerState = "AM",
                PayerCountry = "Brasil",
                PayerZipCode = "69153421"
            };

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
        [TestMethod]
        public void Should_Return_Error_When_Email_Exists() 
                {
            var studentRepository = new FakeStudentRepository();
            var emailService = new FakeEmailService();
            var handler = new SubscriptionHandler(studentRepository, emailService);
            var command = new CreateBoletoSubscriptionCommand
            {
                FirstName = "Iago João",
                LastName = "Peixoto",
                Document = "45608646088",
                Email = "teste@damasio34.com",
                BarCode = "",
                BoletoNumber = "",
                PaymentNumber = "",
                PaidDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddMonths(1),
                Total = 60,
                TotalPaid = 60,
                Payer = "Iago João Peixoto",
                PayerDocument = "45608646088",
                PayerDocumentType = EDocumentType.CPF,
                PayerEmail = "teste@damasio34.com",
                PayerStreet = "Beco Acioly",
                PayerNumber = "413",
                PayerNeighborhood = "São Vicente de Paula",
                PayerCity = "Parintins",
                PayerState = "AM",
                PayerCountry = "Brasil",
                PayerZipCode = "69153421"
            };

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }
}