using System;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    // Um pagamento por si só não pode existir
    public abstract class Payment : Entity
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, 
            string payer, Document document, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Payer = payer;
            Document = document;
            Address = address;
            Email = email;

            AddNotifications(
                this.Document, 
                this.Address, 
                this.Email, 
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(this.Payer, "Payment.Payer", "Nome do pagador inválido")
                    .IsGreaterThan(DateTime.Now, this.PaidDate, "Payment.PaidDate", "A data do pagamento deve ser futura.")
                    .IsGreaterThan(0, this.Total, "Payment.Total", "O total não pode ser zero.")
                    .IsGreaterOrEqualsThan(this.Total, this.TotalPaid, "Payment.TotalPaid", "O valor pago não pode ser maior que o valor total.")
            );            
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public string Payer { get; private set; }
        public Document Document { get; private set; }
        public Address Address { get; private set; }
        public Email Email { get; private set; }
    }
}