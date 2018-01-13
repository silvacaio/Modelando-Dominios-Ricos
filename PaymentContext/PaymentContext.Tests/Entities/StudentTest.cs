using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTest
    {
        private readonly Student _student;
        private readonly Subscription _subscription;
        private readonly Payment _payment;

        public StudentTest()
        {
            var name = new Name("Caio", "Silva");
            var document = new Document("14815296766", EDocumentType.CPF);
            var email = new Email("caio@caio.com");
            _student = new Student(name, document, email);
            _subscription = new Subscription(null);
            _payment = new PayPalPayment("12345678", DateTime.Now, DateTime.Now.AddDays(5), 10, 10, document, "Caio", email);
        }
        [TestMethod]
        public void DeveRetornarErroQuandoTiverInscricaoAtiva()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoInscricaoNaoTemPagamento()
        {
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoNaoTiverInscricaoAtiva()
        {
            _subscription.AddPayment(_payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.Valid);
        }
    }
}

