using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NinjectDemo
{
    public interface IWeapon
    {
        int Damage { get; }
    }

    public class Sword : IWeapon
    {
        public int Damage
        {
            get { return 5; }
        }
    }

    public class Katana : IWeapon
    {
        public int Damage
        {
            get { return 7; }
        }
    }
}
