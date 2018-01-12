using System;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        public Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, string address, string document, string payer, string email)
        {
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            Address = address;
            Document = document;
            Payer = payer;
            Email = email;
        }

        public string Number { get; private set; }
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; } // total a ser pago
        public string Address { get; private set; } //Endereco de cobranca 
        public string Document { get; private set; }
        public string Payer { get; private set; }
        public string Email { get; private set; }

    }

    public class BoletoPayment : Payment
    {
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }

    }

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
