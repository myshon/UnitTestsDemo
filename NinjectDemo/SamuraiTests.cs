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
            Samurai samurai = new Samurai(weapon, loger, helmet: new Helmet());

            var damage = samurai.Hit();

            Assert.AreEqual(7, damage);
        }

        [Test]
        public void Hit_WithKatana_Damage7()
        {
            Kernel = new StandardKernel();
            Kernel.Bind<IWeapon>().To<Katana>();
            Kernel.Bind<ILogger>().To<FakeLogger>();
            Kernel.Bind<IHelmet>().ToConstant(new Helmet());
            var samurai = Kernel.Get<Samurai>();

            var damage = samurai.Hit();

            Assert.AreEqual(7, damage);
        }

        [Test]
        public void Hit_WithKatana_LogIt()
        {
            var fakeLogger = new FakeLogger();
            Kernel.Bind<IWeapon>().To<Katana>();
            Kernel.Bind<IHelmet>().ToConstant(new Helmet());
            Kernel.Bind<ILogger>().ToConstant(fakeLogger);

            var samurai = Kernel.Get<Samurai>();

            var damage = samurai.Hit();

            Assert.IsTrue(fakeLogger.LogInvoked);
        }


        [Test]
        public void Hit_WithKatana_LogIt_Moq()
        {
            Kernel.Bind<IWeapon>().To<Katana>();
            Mock<ILogger> mockLogger = new Mock<ILogger>();
            var logger = mockLogger.Object;
            Kernel.Rebind<ILogger>().ToConstant(logger);
            var samurai = Kernel.Get<Samurai>();

            var damage = samurai.Hit();

            mockLogger.Verify(x => x.Log("aaaa"));
            Assert.AreEqual(7, damage);
        }
    }
}
