using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    public class StudentTest
    {
        [TestMethod]
        public void AddSubscription()
        {
            var name = new Name("dddf", "dd");
            foreach (var not in name.Notifications){
                //not.Message;
            }
            

           // var subscription = new Subscription(null);
          //  var student = new Student("Caio", "Silva", "115414456", "estMethodAttribute");
          //  student.AddSubscription(subscription);
        }
    }
}

