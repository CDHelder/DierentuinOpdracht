using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierentuinOpdracht.Common
{
    public sealed class Lion : Animal
    {
        private const string nameLion = "Lion";
        private const int energyAddition = 50;
        private const int energyUse = 10;

        public Lion()
        {
            Name = nameLion;
        }

        public override void Eat()
        {
            Energy += energyAddition;
        }

        public override void UseEnergy()
        {
            Energy -= energyUse;
        }
    }
}
