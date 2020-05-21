using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        // Red, Green, Refactor
        [TestMethod]
        public void Should_Return_Error_When_CNPJ_Is_Invalid() 
        {
            var document = new Document("123", EDocumentType.CNPJ);
            Assert.IsTrue(document.Invalid);
        }
        [TestMethod]
        public void Should_Return_Succcess_When_CNPJ_Is_Valid() 
        {
            var document = new Document("67417080000156", EDocumentType.CNPJ);
            Assert.IsTrue(document.Valid);
        }
        [TestMethod]
        public void Should_Return_Error_When_CPF_Is_Invalid() 
        {
            var document = new Document("123", EDocumentType.CPF);
            Assert.IsTrue(document.Invalid);
        }
        /*
            Com as anotações DataTestMethod e DataRow, 
            o teste executa mais de uma vez usando a variável informada
            no DataRow. Um novo teste é executado a cada DataRow.
        */
        [TestMethod]
        [DataTestMethod]
        [DataRow("18336132015")]
        [DataRow("39213078056")]
        [DataRow("33839131049")]
        public void Should_Return_Succcess_When_CPF_Is_Valid(string cpf) 
        {
            var document = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(document.Valid);
        }
    }
}