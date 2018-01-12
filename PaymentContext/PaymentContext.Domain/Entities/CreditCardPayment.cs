using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(string cardHolderName, string cardNumer, string lastTransactionNumber, DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string address, string document, string payer, string email) : base(paidDate, expireDate, total, totalPaid, address, document, payer, email)
        {
            CardHolderName = cardHolderName;
            CardNumer = cardNumer;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumer { get; private set; } //ultimos 4 digitos
        public string LastTransactionNumber { get; private set; }  //numero da ultima transação
    }
}
