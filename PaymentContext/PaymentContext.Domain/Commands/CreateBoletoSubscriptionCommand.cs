using System;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CreateBoletoSubscriptionCommand : Notifiable, ICommand
    {
        public string FirtsName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string BarCode { get; set; }
        public string BoletoNumber { get; set; }

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

        public void Validate()
        {
             AddNotifications(new Contract()
                              .Requires()
                              .HasMinLen(FirtsName, 3, "Name.FirtsName", "O nome deve ter ao menos 3 caracteres")
                              .IsNotNullOrEmpty(LastName,"Name.LastName","O sobrenome não pode ser vazio")
             //                 .HasMinLen(LastName, 3, "Name.LastName", "O sobrenome deve ter ao menos 3 caracteres")
                              .HasMaxLen(FirtsName, 40, "Name.FirtsName", "O nome deve ter até 40 caracteres"));

           // AddNotification("Name.LastName", "teste");
        }
    }
}