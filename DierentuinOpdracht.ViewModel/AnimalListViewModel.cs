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

        private AnimalViewModel SelectedAnimal;

        public AnimalViewModel MyProperty
        {
            get => SelectedAnimal;
            set {
                if(SelectedAnimal != value)
                {
                    SelectedAnimal = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(IsAnimalSelected));
                }
            }
        }

        public bool IsAnimalSelected => SelectedAnimal != null;
    }
}
