using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    //Red, Green, refactor
    [TestClass]
    public class DocumentTest
    {
        [TestMethod]
        public void DeveRetornarErroQuandoCPNJForInvalido()
        {
            var doc = new Document("124", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Invalid);
        }

        [TestMethod]
        public void DeveRetornarSucessoQuandoCPNJForValido()
        {
            var doc = new Document("12345678912345", EDocumentType.CNPJ);
            Assert.IsTrue(doc.Valid);
        }

        [TestMethod]
        public void DeveRetornarErroQuandoCPFForInvalido()
        {
            var doc = new Document("124", EDocumentType.CPF);
            Assert.IsTrue(doc.Invalid);
        }

//testando varios valores
        [TestMethod]
        [DataTestMethod]
        [DataRow("12345678912")]
        [DataRow("32401335803")]
        [DataRow("23832343202")]
        public void DeveRetornarSucessoQuandoCPFForValido(string cpf)
        {
            var doc = new Document(cpf, EDocumentType.CPF);
            Assert.IsTrue(doc.Valid);
        }
    }
}

