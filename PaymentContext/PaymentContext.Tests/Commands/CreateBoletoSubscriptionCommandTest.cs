using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTest
    {
        [TestMethod]
        public void RetornaErroQuandoNomeInvalido()
        {
           var command = new CreateBoletoSubscriptionCommand();
           command.FirtsName = "";
           command.Validate();
           Assert.IsTrue(command.Invalid);
        }
    }
}

