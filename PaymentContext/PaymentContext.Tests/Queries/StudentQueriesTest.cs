using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Queries;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Tests.Queries
{

    [TestClass]
    public class StudentQueriesTest
    {
         private IList<Student> _students;

        public StudentQueriesTest()
        {
            _students = new List<Student>();
            for (var i = 0; i <= 10; i++){
               _students.Add(new Student(
                    new Name("Aluno", i.ToString()),
                    new Document("1111111111" + i.ToString(), EDocumentType.CPF),
                    new Email(i.ToString() + "@gmail.com")
                ));
            }    
        }

        [TestMethod]
        public void RetornaNullQuandoDocumentoNaoExiste()
        {
            var exp = StudentQueries.GetStudentInfo("123456789");
            var stud =_students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreEqual(null, stud);
        }

         [TestMethod]
        public void RetornaStudentQuandoDocumentoExiste()
        {
            var exp = StudentQueries.GetStudentInfo("11111111111");
            var stud =_students.AsQueryable().Where(exp).FirstOrDefault();
            Assert.AreNotEqual(null, stud);
        }

    }
}

