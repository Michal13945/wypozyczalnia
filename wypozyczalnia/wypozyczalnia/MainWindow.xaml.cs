using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
using wypozyczalnia.Models;
using wypozyczalnia.Windows;

namespace wypozyczalnia;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public ObservableCollection<Car> Cars { get; set; }

    public MainWindow()
    {
        Cars = new ObservableCollection<Car>() {
           
        };

        InitializeComponent();

        this.DataContext = this;
    }

    private void CarsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    }
   
    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        ClientInfoWindow clientInfoWindow = new ClientInfoWindow();
        clientInfoWindow.Show();

        this.Hide();
    }
}
