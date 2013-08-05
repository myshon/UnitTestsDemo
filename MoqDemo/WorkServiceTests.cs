using System.CodeDom;
using Moq;
using NUnit.Framework;

namespace MoqDemo
{
    public class WorkServiceTests
    {
        public WorkServiceTests()
        {
            
        }

        [Test]
        public void SaveWork_ShouldSendEmail()
        {
            var emailSenderMock = new Mock<IEmailSender>();

            IWorkService sut = new WorkService(
                new WorkRepository(),
                emailSenderMock.Object);

            sut.SaveWork(new Work() { Description = "xyz" });

            emailSenderMock.Verify(x => x.Send(It.IsAny<string>(), "xyz"));

        }
    }
}