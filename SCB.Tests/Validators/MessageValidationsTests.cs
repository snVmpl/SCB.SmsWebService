using Microsoft.VisualStudio.TestTools.UnitTesting;
using SCB.Core.Validations.Message;
using SCB.Data.Entities;

namespace SCB.Tests.Validators
{
    [TestClass]
    public class MessageValidationsTests
    {
        [TestMethod]
        public void MessageIsEmptyTest()
        {
            var validation = new MessageIsEmpty();
            var message = new Message
            {
                Text = string.Empty
            };

            Assert.IsFalse(validation.IsSatisfiedBy(message));
        }
    }
}
