using System;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string CardHolderName { get; set; }
        public string CardNumer { get; set; } //ultimos 4 digitos
        public string LastTransactionNumber { get; set; }  //numero da ultima transação

        // public DateTime ExpireDate { get;  set; }
        public string PaymentNumber { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; } // total a ser pago
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string PayerDocument { get; set; }
        public EDocumentType PayerDocumentType { get; set; }
        public string Payer { get; set; }
        public string PayerEmail { get; set; }
    }
}