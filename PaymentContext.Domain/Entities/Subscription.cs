using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate = null)
        {
            this.CreateDate = DateTime.Now;
            this.LastUpdateDate = DateTime.Now;
            this.ExpireDate = expireDate;
            this.Active = true;
            this._payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments => this._payments.ToArray();

        public void AddPayment(Payment payment)
        {
            this._payments.Add(payment);
        }

        public void Inactivate()
        {
            this.Active = true;
            this.LastUpdateDate = DateTime.Now;
        }
    }
}