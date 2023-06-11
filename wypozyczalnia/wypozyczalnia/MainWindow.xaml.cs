using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using wypozyczalnia.Data;
using wypozyczalnia.Models;
using wypozyczalnia.Windows;

namespace wypozyczalnia;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    public ObservableCollection<Car> Cars { get; set; }
    public Car? SelectedCar { get; set; }

    public bool IsNextButtonEnabled { get; set; } = false;
    public decimal PricePerDay { get; set; } = 0;
    public string PriceVisibility { get; set; } = "Hidden";


    public event PropertyChangedEventHandler? PropertyChanged;

    public MainWindow()
    {
        var cars = DbData.GetCars();

        cars = cars.Where(x => x.RentedCars.Any(r => r.StartDate <= DateTime.Now && r.EndDate >= DateTime.Now) == false);

        Cars = new ObservableCollection<Car>(cars);

        InitializeComponent();

        this.DataContext = this;
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        ClientInfoWindow clientInfoWindow = new ClientInfoWindow(SelectedCar.Id);

        clientInfoWindow.Show();

        this.Hide();
    }

    private void CarsSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var comboBox = sender as ComboBox;

        var car = comboBox?.SelectedValue as Car;

        SelectedCar = car;
        PricePerDay = car.ValuePerDay;
        PriceVisibility = "Visible";

        IsNextButtonEnabled = true;

        OnPropertyChanged("PricePerDay");
        OnPropertyChanged("PriceVisibility");
        OnPropertyChanged("IsNextButtonEnabled");
    }
}