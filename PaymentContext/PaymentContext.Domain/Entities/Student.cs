using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;

        public Student(string firstName, string lastName, string document, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription>();
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }

        //Enedreço de entrega
        public string Address { get; private set; }

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