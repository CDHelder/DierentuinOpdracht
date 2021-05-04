using DierentuinOpdracht.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierentuinOpdracht.DataAcces
{
    public class DierentuinDataProvider : IDierentuinDataProvider
    {
        public void AddAnimal()
        {
            Debug.WriteLine($"tried to add new Animal");
        }

        public IEnumerable<Animal> LoadAnimals()
        {
            List<Animal> Animals = new List<Animal>
            {
                new Lion
                {
                    Name = "Leeuw 1",
                    Energy = 100
                },
                new Lion
                {
                    Name = "Leeuw 2",
                    Energy = 100
                },
                new Lion
                {
                    Name = "Leeuw 3",
                    Energy = 100
                },
                new Elephant
                {
                    Name = "Elephant 1",
                    Energy = 100
                },
                new Elephant
                {
                    Name = "Elephant 2",
                    Energy = 100
                },
                new Elephant
                {
                    Name = "Elephant 3",
                    Energy = 100
                },
                new Monkey
                {
                    Name = "Monkey 1",
                    Energy = 100
                },
                new Monkey
                {
                    Name = "Monkey 2",
                    Energy = 100
                },
                new Monkey
                {
                    Name = "Monkey 3",
                    Energy = 100
                }
            };

            return Animals;
        }

        public void SaveAnimal(Animal animal)
        {
            Debug.WriteLine($"Animal saved: {animal.Name}");
        }
    }
}
