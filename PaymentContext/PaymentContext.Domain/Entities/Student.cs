using System.Collections.Generic;
using System.Linq;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Student : Entity
    {
        private IList<Subscription> _subscriptions;

        public Student(Name name, Document document, Email email)
        {
            Name = name;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public Name Name { get; private set; } // value object
        public Document Document { get; private set; } // value object
        public Email Email { get; private set; }

        //Enedreço de entrega
        public Address Address { get; private set; }

        // um aluno pode ter mais de uma assinatura - só uma ativa
        // public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription){
           
            // cancela todas as assinaturas
            foreach (var sub in Subscriptions)
            {
                sub.Deactivate();
            }

            // add a assinatura
            _subscriptions.Add(subscription);
        }

    }
}