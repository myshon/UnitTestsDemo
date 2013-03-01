using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ninject;
using Moq;


namespace NinjectDemo
{
    [TestFixture]
    public class SamuraiTests
    {
        private IKernel Kernel;
        public SamuraiTests()
        {

        }

        [SetUp]
        public void SetUp()
        {
            // Uruchamia się przed każdym testem
            // Inicjalizacja Ninjecta, Sesji itp.
            Kernel = new StandardKernel();
        }

        [TearDown]
        public void TearDown()
        {
            // Uruchamia się po każdym teście
            // Dispose, zamykanie sesji itp.
            Kernel.Dispose();
            
        }


        [Test]
        public void Hit_WithKatana_HitsDamage7_WithoutNinject()
        {
            var weapon = new Katana();
            var loger = new FakeLogger();
            Samurai samurai = new Samurai(weapon, loger);

            var damage = samurai.Hit();

            Assert.AreEqual(7, damage);
        }

        [Test]
        public void Hit_WithKatana_Damage7()
        {
            Kernel.Bind<IWeapon>().To<Katana>().Named("Katama1");
            Kernel.Bind<ILogger>().To<FakeLogger>();
            var samurai = Kernel.Get<Samurai>();

            var damage = samurai.Hit();

            Assert.AreEqual(7, damage);
        }

        [Test]
        public void Hit_WithKatana_LogIt()
        {
            Kernel.Bind<IWeapon>().To<Katana>();
            Kernel.Bind<ILogger>().To<FakeLogger>();

            Mock<ILogger> mockLogger = new Mock<ILogger>();
            mockLogger.Setup(x => x.Something()).Returns("aaa");
            Assert.AreEqual("aaa", mockLogger.Object.Something());

            Kernel.Rebind<ILogger>().ToConstant(mockLogger.Object);
            var samurai = Kernel.Get<Samurai>();

            var damage = samurai.Hit();

            mockLogger.Verify(x => x.Log(It.IsAny<string>()));
            Assert.AreEqual(7, damage);
        }
    }
}
