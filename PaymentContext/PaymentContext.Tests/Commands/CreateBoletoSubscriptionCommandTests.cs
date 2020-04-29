using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;

namespace PaymentContext.Tests.Commands
{
    [TestClass]
    public class CreateBoletoSubscriptionCommandTests
    {
        [TestMethod]
        public void ShoulReturnErrorWhenNameIsInvalid()
        {
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "";

            command.Validate();// método que possui as validações dentro do command
            Assert.AreEqual(true, command.Invalid);
        }
    }
}