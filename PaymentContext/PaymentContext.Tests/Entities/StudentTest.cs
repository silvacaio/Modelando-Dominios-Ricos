using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests
{
    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void AddSubscription()
        {
            var subscription = new Subscription();
            var student = new Student("Caio", "Silva", "115414456", "estMethodAttribute");
            student.AddSubscription(subscription);
        }
    }
}
