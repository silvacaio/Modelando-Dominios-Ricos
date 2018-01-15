using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mockups;

namespace PaymentContext.Tests.Handlers
{
    [TestClass]
    public class SubscriptionHandlerTest
    {
        [TestMethod]
        public void RetornaErroQuandoDocumentoJaExiste()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirtsName = "Caio";
            command.LastName = "Silva";
            command.Document = "99999999999";
            command.Email = "caio@gmail.com";
            command.BarCode = "999999";
            command.BoletoNumber = "111";
            command.PaymentNumber = "123";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 10;
            command.TotalPaid = 10;
            command.Street = "Teste";
            command.Number = "111";
            command.Neighborhood = "999";
            command.City = "Flores";
            command.State = "RS";
            command.Country = "Brazil";
            command.ZipCode = "1234564897";
            command.PayerDocument = "11124546";
            command.PayerDocumentType = EDocumentType.CPF;
            command.Payer = "Caio";
            command.PayerEmail = "teste";

            handler.Handle(command);

            Assert.IsTrue(handler.Invalid);
        }

    }
}

