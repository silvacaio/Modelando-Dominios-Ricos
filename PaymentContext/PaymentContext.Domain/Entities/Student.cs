using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private List<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();

            AddNotifications(Name, Document, Email);
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            var hasSubscriptionActive = false;
            foreach (var item in _subscriptions)
            {
                if (item.Active)
                    hasSubscriptionActive = true;

            }

            AddNotifications(new Contract()
                        .Requires()
                        .IsFalse(hasSubscriptionActive, "Student.Subscriptions", "Você já tem um inscrição ativa"));
            //Cancelar todas as outras e coloca a nova como principal
            // foreach (var item in _subscriptions)
            //    item.Inactivate();

            _subscriptions.Add(subscription);
        }
    }
}