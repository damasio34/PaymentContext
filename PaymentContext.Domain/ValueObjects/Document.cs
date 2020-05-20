using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, EDocumentType type)
        {
            this.Number = number;
            this.Type = type;

            if(string.IsNullOrEmpty(this.Number))
                AddNotification("Document.Address", "Documento inválido");
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
    }
}