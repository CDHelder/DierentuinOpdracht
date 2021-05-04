using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DierentuinOpdracht.Common;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DierentuinOpdracht.ViewModel
{
    public class AnimalViewModel : ViewModelBase
    {
        //private readonly Animal animal;

        //public AnimalViewModel(Animal animal)
        //{
        //    this.animal = animal;
        //}

        //public string Name
        //{
        //    get => animal.Name;
        //    set
        //    {
        //        if (animal.Name != value)
        //        {
        //            animal.Name = value;
        //            RaisePropertyChanged();
        //            RaisePropertyChanged(nameof(CanSave));
        //        }
        //    }
        //}

        //public bool CanSave => !string.IsNullOrEmpty(Name);

        private Animal animal;
        public AnimalViewModel(Animal animal)
        {
            this.animal = animal;
        }

        public string Name
        {
            get => animal.Name;
            set
            {
                if (string.IsNullOrEmpty(value) == false && string.Equals(value, animal.Name))
                {
                    animal.Name = value;
                    RaisePropertyChanged(nameof(Name));
                }
            }
        }

        public int Energy { get => animal.Energy; }

        internal Animal Animal { get => animal; }

        public void Eat()
        {
            animal.Eat();
            RaisePropertyChanged(nameof(Energy));
        }

        public void UseEnergy()
        {
            animal.UseEnergy();
            RaisePropertyChanged(nameof(Energy));
        }
    }
}
