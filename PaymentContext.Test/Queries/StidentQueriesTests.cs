using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Queries;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Test.Queries
{
    [TestClass]
    public class StidentQueriesTests
    {
        private IList<Student> _students;

        public StidentQueriesTests() 
        {
            /*
                Este bloco de implementação deveria estar no repositório
            */
            this._students = new List<Student>();
            for (var i = 0; i <= 10; i++)
            {
                this._students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document($"1111111111{i}", EDocumentType.CPF),
                    new Email($"{i}@damasio34.com")
                ));
            }
        }

        [TestMethod]
        public void Should_Return_Null_When_Document_Not_Exists()
        {
            var expression = StudentQueries.GetStudentByDocument("12345678911");
            var student = this._students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreEqual(null, student);
        }

        [TestMethod]
        public void Should_Return_Student_When_Document_Exists()
        {
            var expression = StudentQueries.GetStudentByDocument("11111111111");
            var student = this._students.AsQueryable().Where(expression).FirstOrDefault();

            Assert.AreNotEqual(null, student);
        }
    }
}