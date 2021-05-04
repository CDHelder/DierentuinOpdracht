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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dt = new DispatcherTimer();
            if (Convert.ToDouble(MillisecondsInput.Text) > 0)
            {
                dt.Interval = TimeSpan.FromMilliseconds(Convert.ToDouble(MillisecondsInput.Text));
                dt.Tick += Dt_Tick;
                dt.Start();
            }
        }
        private int increment = 0;
        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;
            //Zet increment naar Textlabel die secondes laat zien
        }

        private void MillisecondsInput_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
