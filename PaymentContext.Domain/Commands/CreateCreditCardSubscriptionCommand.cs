using System;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand : ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

       
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; } // Apenas os 4 últimos dígitos
        public string LastTransactionNumber { get; set; }

        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }
        public string Payer { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string PayerEmail { get; set; }
        public string PayerStreet { get; set; }
        public string PayerNumber { get; set; }
        public string PayerNeighborhood { get; set; }
        public string PayerCity { get; set; }
        public string PayerState { get; set; }
        public string PayerCountry { get; set; }
        public string PayerZipCode { get; set; }

        public void Validate() {
            
        }
    }
}