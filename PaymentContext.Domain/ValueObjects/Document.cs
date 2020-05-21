using Flunt.Validations;
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

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(this.Validete(), "Document.Number", "Documento inválido.")
            );
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }

        private bool Validete() {
            if (this.Type == EDocumentType.CPF && this.Number.Length == 11)
            {
                // ToDo: Validar CPF
                return true;
            }
            if (this.Type == EDocumentType.CNPJ && this.Number.Length == 14)
            {
                // ToDo: Validar CNPJ
                return true;
            }

            return false;            
        }
    }
}