using DierentuinOpdracht.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierentuinOpdracht.DataAcces
{
    public interface IDierentuinDataProvider
    {
        IEnumerable<Animal> LoadAnimals();
        void SaveAnimal(Animal animal);
        void AddAnimal();
    }
}
