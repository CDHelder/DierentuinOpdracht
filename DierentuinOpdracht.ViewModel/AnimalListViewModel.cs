using DierentuinOpdracht.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DierentuinOpdracht.ViewModel
{
    public class AnimalListViewModel : ViewModelBase
    {
        public ObservableCollection<AnimalViewModel> Animals { get; } = new();

        private AnimalViewModel _selectedAnimal;

        public AnimalViewModel SelectedAnimal
        {
            get => _selectedAnimal;
            set {
                if(_selectedAnimal != value)
                {
                    _selectedAnimal = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsAnimalSelected));
                }
            }
        }

        public bool IsAnimalSelected => SelectedAnimal != null;

        public void FeedElephants()
        {
            FeedAnimals<Elephant>();
        }
        public void FeedLions()
        {
            FeedAnimals<Lion>();
        }
        public void FeedMonkeys()
        {
            FeedAnimals<Monkey>();
        }
        public void FeedAllAnimals()
        {
            FeedAnimals<Animal>();
        }

        private void FeedAnimals<T>() where T : Animal
        {
            foreach (AnimalViewModel animal in Animals)
            {
                Animal maybeAnimal = animal.Animal as T;
                if (maybeAnimal != null)
                {
                    maybeAnimal.Eat();
                    //RaiseProppertyChanged(nameof(maybeAnimal.Energy));
                }

                animal.Eat();
            }
        }
    }
}
