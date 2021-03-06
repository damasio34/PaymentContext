using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }

        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }

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

        public void Validate()
        {
            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(this.FirstName, 3, "Name.FirstName", "Nome deve conter ao menos 3 caracteres.")
                .HasMaxLen(this.FirstName, 40, "Name.FirstName", "Nome deve conter até 40 caracteres.")
                .HasMinLen(this.LastName, 3, "Name.LastName", "Nome deve conter ao menos 3 caracteres.")
            );
        }
    }
}