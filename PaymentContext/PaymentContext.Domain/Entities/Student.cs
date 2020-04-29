using System.Collections.Generic;
using System.Linq;
using Flunt.Validations;
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

      //agrupando todos erros que vieram VOs no Student
      AddNotifications(name, document, email);
    }

    public Name Name { get; private set; } // value object
    public Document Document { get; private set; } // value object
    public Email Email { get; private set; }

    //Enedreço de entrega
    public Address Address { get; private set; }

    // um aluno pode ter mais de uma assinatura - só uma ativa
    // public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }
    public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

    public void AddSubscription(Subscription subscription)
    {
      var hasSubscriptionActive = false;

      foreach (var sub in Subscriptions)
      {
          if(sub.Active)
          {
            hasSubscriptionActive=true;
            //break;
          }
      }

      //validação por contrato
      AddNotifications(new Contract()
        .Requires()
        // não pode add assinatura com outras ativas
        .IsFalse(hasSubscriptionActive, "Student.Subscription", "Você já tem uma assinatura ativa")
        // não pode add assinatura sem pagamento
        .IsLowerThan(0, subscription.Payments.Count, "Student.Subscription.Payments", "Esta assinatura não possui pagamentos")
      );

      // alternativa sem contrato - dessa forma teremos que ter um teste
      // if(hasSubscriptionActive)
      // {
      //   AddNotification("Student.Subscription", "Você já tem uma assinatura ativa");
      // }

      _subscriptions.Add(subscription);
    }

  }
}