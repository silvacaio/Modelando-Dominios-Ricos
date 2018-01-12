using System;
using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
    {
        private IList<Payment> _payments { get; set; }
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get { return _payments.ToArray(); } }

        public void AddPayment(Payment newPayment)
        {
            //TODO verificar se a data é maior que hoje
//var teste = new Contract().Requires().IsGreaterOrEqualsThan(DateTime.Now, newPayment.PaidDate, "Subscription.Payment", "Erro");
//teste.
            _payments.Add(newPayment);
        }

        public void Activate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }

        public void Inactivate()
        {
            Active = true;
            LastUpdateDate = DateTime.Now;
        }
    }
}
