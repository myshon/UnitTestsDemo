using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Moq;
using NUnit.Framework;

namespace MoqDemo
{
    public class MoqDemo
    {
        [Test]
        public void SetupTest()
        {
            var workRepositoryMock = new Mock<IWorkRepository>();
            var work = new Work() { Description = "xyz" };
            workRepositoryMock.Setup(x => x.Get(1)).Returns(work);
            var workRepository = workRepositoryMock.Object;

            var result = workRepository.Get(1);

            Assert.NotNull(result);
            Assert.AreEqual("xyz", result.Description);
        }

        [Test]
        public void VerifyTimesTest()
        {
            var workRepositoryMock = new Mock<IWorkRepository>();
        
            var work = new Work() { Description = "xyz" };

            var workRepository = workRepositoryMock.Object;

            workRepository.Save(work);
            workRepository.Save(work);
            workRepository.Save(work);

            workRepositoryMock.Verify(x => x.Save(work), Times.Exactly(3));
            workRepositoryMock.Verify(x => x.Save(It.IsAny<Work>()), Times.Exactly(3));
         
        }
    }
}
