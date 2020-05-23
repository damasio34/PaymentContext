using System;
using System.Linq.Expressions;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Domain.Queries 
{
    public static class StudentQueries 
    {
        public static Expression<Func<Student, bool>> GetStudentByDocument(string document)
            => p => p.Document.Number == document;
    }
}