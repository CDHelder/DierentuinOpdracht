using DierentuinOpdracht.Common;
using DierentuinOpdracht.DataAcces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DierentuinOpdracht.ViewModel
{
    public partial class AnimalListViewModel : ViewModelBase
    {

        public ObservableCollection<AnimalViewModel> Animals { get; }
        private AnimalViewModel _SelectedAnimal;
        private readonly IDierentuinDataProvider dataProvider;

        public AnimalListViewModel(IDierentuinDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
            Animals = new ObservableCollection<AnimalViewModel>();
        }

        public AnimalViewModel SelectedAnimal
        {
            get => _SelectedAnimal;
            set
            {
                if (_SelectedAnimal != value)
                {
                    _SelectedAnimal = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsAnimalSelected));
                }
            }
        }
        public ICommand Reload { get => new Command(Load); }
        public ICommand AddNew { get => new Command(AddNewMethod); }

        public ICommand FeedElephants { get => new Command(FeedAnimals<Elephant>); }
        public ICommand FeedLions { get => new Command(FeedAnimals<Lion>); }
        public ICommand FeedMonkeys { get => new Command(FeedAnimals<Monkey>); }
        public ICommand FeedAllAnimals { get => new Command(FeedAnimals<Animal>); }
        public ICommand UseEnergyAllAnimals { get => new Command(UseEnergyAnimals<Animal>); }

        private void FeedAnimals<T>() where T : Animal
        {
            AnimalsAction<T>(FeedAnimal);
        }
        private void UseEnergyAnimals<T>() where T : Animal
        {
            AnimalsAction<T>(UseEnergyAnimal);
        }

        private void AnimalsAction<T>(Action<Animal> action) where T : Animal
        {
            foreach (AnimalViewModel animal in Animals)
            {
                Animal maybeAnimal = animal.Animal as T;
                if (maybeAnimal != null)
                {
                    action(maybeAnimal);
                }
            }
        }
        private void FeedAnimal(Animal animal)
        {
            animal.Eat();
            RaisePropertyChanged(nameof(animal.Energy));
        }
        private void UseEnergyAnimal(Animal animal)
        {
            animal.UseEnergy();
            RaisePropertyChanged(nameof(animal.Energy));
        }

        public bool IsAnimalSelected => SelectedAnimal != null;


        public void Load()
        {
            Animals.Clear();
            foreach(Animal animal in dataProvider.LoadAnimals())
            {
                Animals.Add(new AnimalViewModel(animal));                
            }
            RaisePropertyChanged(nameof(Animals));

            //TODO: remove next line, testing only
            _SelectedAnimal = Animals.FirstOrDefault();
        }
        private void AddNewMethod()
        {
            dataProvider.AddAnimal();
            Load();
        }
    }
}
