using System;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment
    {
        public string CardHolderName { get; set; }
        public string CardNumer { get; set; } //ultimos 4 digitos
        public string LastTransactionNumber { get; set; }  //numero da ultima transação
    }

    public class PayPalPayment : Payment
    {
        public string TransactionCode { get; set; }
    }
}
