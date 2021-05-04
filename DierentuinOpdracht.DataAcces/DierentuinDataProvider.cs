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
        public IEnumerable<Animal> LoadAnimals()
        {
            List<Animal> Animals = new List<Animal>();
            List<Lion> Lions = new List<Lion>
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
                }
            };
            List<Elephant> Elephants = new List<Elephant>
            {
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
                }
            };
            List<Monkey> Monkeys = new List<Monkey>
            {
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

            foreach (var Lion in Lions)
            {
                Animals.Add(Lion);
            }
            foreach (var Elephant in Elephants)
            {
                Animals.Add(Elephant);
            }
            foreach (var Monkey in Monkeys)
            {
                Animals.Add(Monkey);
            }

            return Animals;
        }

        public void SaveAnimal(Animal animal)
        {
            Debug.WriteLine($"Animal saved: {animal.Name}");
        }
    }
}
