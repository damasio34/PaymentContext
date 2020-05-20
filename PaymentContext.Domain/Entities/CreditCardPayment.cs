namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment: Payment 
    { 
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; } // Apenas os 4 últimos dígitos
        public string LastTransactionNumber { get; set; }
    }
}