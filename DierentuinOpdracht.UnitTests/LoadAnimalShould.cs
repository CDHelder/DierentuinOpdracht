using DierentuinOpdracht.Common;
using DierentuinOpdracht.DataAcces;
using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace DierentuinOpdracht.UnitTests
{
    public class LoadAnimalShould
    {
        private readonly ITestOutputHelper output;

        public LoadAnimalShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var dataprovider = new DierentuinDataProvider();

            var animals = dataprovider.LoadAnimals();
            animals.OfType<Elephant>();

            animals.ToList().ForEach(a => 
            {
                if (a is Elephant) 
                    output.WriteLine(a.Name);
            });
        }
    }
}
