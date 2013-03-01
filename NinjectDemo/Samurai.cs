using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    /// <summary>
    /// http://www.ninject.org/
    /// </summary>
    public class Samurai
    {
        public ILogger Logger { get; set; }
        public IWeapon Weapon { get; private set; }

        public Samurai(IWeapon weapon, ILogger logger)
        {
            this.Weapon = weapon;
            this.Logger = logger;
        }

        public int Hit()
        {
            Logger.Log("Hits with damage " + Weapon.Damage);
            return Weapon.Damage;
        }
    }

    public interface ILogger
    {
         void Log(string message);

         string Something();
    }

    public class FakeLogger : ILogger
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
