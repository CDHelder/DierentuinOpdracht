using System;
using System.Windows.Input;

namespace DierentuinOpdracht.ViewModel
{
    public partial class AnimalListViewModel
    {
        public class Command : ICommand
        {
            private Action function;
            internal Command(Action function)
            {
                this.function = function;
            }

            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                function();
            }
        }
    }
}
