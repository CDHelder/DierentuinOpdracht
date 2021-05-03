using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierentuinOpdracht.Common
{
    public class Animal
    {
        public string Name { get; set; }
        public int Energy { get; set; }

        public void Eat()
        {
            Energy += 25;
        }
    }
}
