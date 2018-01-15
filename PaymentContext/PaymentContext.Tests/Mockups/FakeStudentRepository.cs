using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repositories;

namespace PaymentContext.Tests.Mockups
{
    public class FakeStudentRepository : IStudentRepository
    {
        public void CreateSubscription(Student studen)
        {
           
        }

        public bool DocumentExist(string document)
        {
            return document == "99999999999";
        }

        public bool EmailExist(string email)
        {
             return email == "caio@gmail.com";
        }
    }
}