using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod()
        {
            var student = new Student("Leonardo", "Rodrigues de Souza", "12345678920", "leonardo@leonardo.com");
        }
    }
}