namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment 
    { 
        public string Barcode { get; set; }   
        public string BoletoNumber { get; set; }
    }
}