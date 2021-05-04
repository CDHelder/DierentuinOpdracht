using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierentuinOpdracht.Common
{
    public sealed class Monkey : Animal
    {
        private const string nameMonkey = "Monkey";
        private const int energyInitial = 60;
        private const int energyAddition = 2;
        private const int energyUse = 2;

        public Monkey()
        {
            Name = nameMonkey;
            Energy = energyInitial;
        }

        public new void Eat()
        {
            Energy += energyAddition;
        }

        public override void UseEnergy()
        {
            Energy -= energyUse;
        }
    }
}
