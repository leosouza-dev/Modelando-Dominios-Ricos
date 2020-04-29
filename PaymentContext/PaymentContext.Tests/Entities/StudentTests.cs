using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enuns;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Document _document;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Bruce", "Wayne");
            _document = new Document("11122236541", EDocumentType.CPF);
            _email = new Email("batman@batman.com.br");
            _student = new Student(_name, _document, _email);
            _address = new Address("Rua dos coiso", "12", "vila do chaves", "são paulo", "sp", "02145232", "Mexico");
            _subscription = new Subscription(null);

        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscripton()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corp", _document, _address, _email, "12345678");
            // add pagamento
            _subscription.AddPayment(payment);
            // add duas assinaturas
            _student.AddSubscription(_subscription); // assinatura valida
            _student.AddSubscription(_subscription); // gera erro

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenSubscriptonHasNoPayments()
        {
            // add duas assinaturas
            _student.AddSubscription(_subscription); 

            Assert.IsTrue(_student.Invalid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscripton()
        {
            var payment = new PayPalPayment(DateTime.Now, DateTime.Now.AddDays(5), 10, 10, "Wayne Corp", _document, _address, _email, "12345678");
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription); // assinatura valida

            Assert.IsTrue(_student.Valid);
        }
    }
}