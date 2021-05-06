using DierentuinOpdracht.DataAcces;
using DierentuinOpdracht.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DierentuinOpdrachtOefenProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AnimalListViewModel _viewModel;

        private DispatcherTimer _dispatcherTimer;
        public bool TimerOn { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new AnimalListViewModel(new DierentuinDataProvider());
            DataContext = _viewModel;
            Loaded += MainWindow_Loaded;

            _dispatcherTimer = new DispatcherTimer();
            if (Convert.ToDouble(MillisecondsInput.Text) > 0)
            {
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(Convert.ToDouble(MillisecondsInput.Text));
                _dispatcherTimer.Tick += Dt_Tick;
                TimerOn = false;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _viewModel.Load();
        }


        private int increment = 0;
        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;
            CounterLabel.Text = increment.ToString();
        }

        private void MillisecondsInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void StartStopButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimerOn == false)
            {
                _dispatcherTimer.Start();
                StartStopButton.Content = "Stop";
                TimerOn = true;
                _dispatcherTimer.Interval = TimeSpan.FromMilliseconds(Convert.ToDouble(MillisecondsInput.Text));
            }
            else if (TimerOn == true)
            {
                _dispatcherTimer.Stop();
                StartStopButton.Content = "Start";
                TimerOn = false;
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            if (TimerOn == true)
            {
                _dispatcherTimer.Stop();
                StartStopButton.Content = "Start";
                TimerOn = false;
            }

            increment = 0;
            CounterLabel.Text = "0";
        }
    }
}
