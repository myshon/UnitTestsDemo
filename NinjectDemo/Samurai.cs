using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace NinjectDemo
{
    /// <summary>
    /// http://www.ninject.org/
    /// </summary>
    public class Samurai
    {
        private readonly IHelmet _helmet;
        public ILogger Logger { get; set; }

        public IWeapon Weapon { get; private set; }


        public Samurai(IWeapon weapon, ILogger logger)
        {
            this.Weapon = weapon;
            this.Logger = logger;
        }

        public Samurai(IWeapon weapon, ILogger logger, IHelmet helmet)
        {
            _helmet = helmet;
            this.Weapon = weapon;
            this.Logger = logger;
        }

        public int Hit()
        {
            Logger.Log("bbbbbbbbbbbb");
            return Weapon.Damage;
        }
    }

    

    public interface IHelmet
    {

    }

    public class Helmet : IHelmet
    {
    }

    public interface ILogger
    {
         void Log(string message);

         string Something();
    }

    public class FakeLogger : ILogger
    {

        public bool LogInvoked = false;

        public void Log(string message)
        {
            LogInvoked = true;
        }

        public string Something()
        {
            return "aaa";
        }
    }

    public class DbLogger : ILogger
    {

        public void Log(string message)
        {

        }

        public string Something()
        {
            return "aaa";
        }
    }
}
