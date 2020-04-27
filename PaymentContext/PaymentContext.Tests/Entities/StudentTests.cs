using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod()
        {
            //var student = new Student("Leonardo", "Rodrigues de Souza", "12345678920", "leonardo@leonardo.com");
            var name = new Name("teste", "teste");
            foreach (var notification in name.Notifications)
            {
                var message = notification.Message;
                var prop = notification.Property;
            }
        }
    }
}