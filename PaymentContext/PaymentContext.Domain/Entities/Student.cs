using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private List<Subscription> _subscriptions;

        public Student(string firtsName, string lastName, string document, string email)
        {
            FirtsName = firtsName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

        }
        public string FirtsName {get; set;}
        public string LastName {get; set;}
        public string Document {get; set;}
        public string Email {get; set;}       
        public string Address { get; set; }
         public IReadOnlyCollection<Subscription> Subscriptions {get {return _subscriptions.ToArray(); }}

         public void AddSubscription(Subscription sub)
         {
           //  foreach()        
         }
    }
}