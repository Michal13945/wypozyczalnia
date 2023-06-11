using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using wypozyczalnia.Data;
using wypozyczalnia.Models;

namespace wypozyczalnia.Windows
{
    /// <summary>
    /// Interaction logic for ClientInfoWindow.xaml
    /// </summary>
    public partial class ClientInfoWindow : Window, INotifyPropertyChanged
    {
        public User User { get; set; } = new User();
        public RentedCar RentedCar { get; set; }
        public Car? SelectedCar { get; set; }

        public bool IsRentButtonEnabled { get; set; } = false;
        public decimal Price { get; set; } = 0;

        public ClientInfoWindow(int selectedCarId)
        {
            SelectedCar = DbData.GetCar(selectedCarId);
            RentedCar = new RentedCar() { CarId = SelectedCar.Id };

            InitializeComponent();

            this.DataContext = this;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void firstnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Firstname = textBox?.Text;

            ValidateButton();
        }

        private void lastnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Lastname = textBox?.Text;

            ValidateButton();
        }

        private void phoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.PhoneNumber = textBox?.Text;

            ValidateButton();
        }

        private void peselBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Pesel = textBox?.Text;

            ValidateButton();
        }

        private void streetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Street = textBox?.Text;

            ValidateButton();
        }

        private void cityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.City = textBox?.Text;

            ValidateButton();
        }

        private void countryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Country = textBox?.Text;

            ValidateButton();
        }

        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            var startDate = datePicker?.SelectedDate;

            if (startDate.HasValue)
                RentedCar.StartDate = startDate.Value;

            if (RentedCar.StartDate.HasValue && RentedCar.EndDate.HasValue)
            {
                var days = (RentedCar.EndDate - RentedCar.StartDate).Value.TotalDays + 1;
                Price = Convert.ToDecimal(days) * SelectedCar.ValuePerDay;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }

            ValidateButton();
        }

        private void endDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            var endDate = datePicker?.SelectedDate;

            if (endDate.HasValue)
                RentedCar.EndDate = endDate.Value;

            if (RentedCar.StartDate.HasValue && RentedCar.EndDate.HasValue)
            {
                var days = (RentedCar.EndDate - RentedCar.StartDate).Value.TotalDays + 1;
                Price = Convert.ToDecimal(days) * SelectedCar.ValuePerDay;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
            }

            ValidateButton();
        }


        private bool IsFormValid()
        {
            return !string.IsNullOrEmpty(User.Firstname) &&
                !string.IsNullOrEmpty(User.Lastname) &&
                !string.IsNullOrEmpty(User.PhoneNumber) &&
                !string.IsNullOrEmpty(User.Street) &&
                !string.IsNullOrEmpty(User.City) &&
                !string.IsNullOrEmpty(User.Country);
        }

        private void ValidateButton()
        {
            var formValid = IsFormValid();

            if (formValid != IsRentButtonEnabled)
            {
                IsRentButtonEnabled = formValid;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsRentButtonEnabled"));
            }
        }

        private void rentButton_Click(object sender, RoutedEventArgs e)
        {
            var user = DbData.GetUser(User.Pesel);

            if (user is null)
            {
                DbData.AddUser(User);
                user = User;
            }
            else
            {
                DbData.UpdateUser(user);
            }

            RentedCar.UserId = user.Id;

            DbData.AddRentedCar(RentedCar);

            ConfirmationWindow confirmationWindow = new ConfirmationWindow();

            confirmationWindow.Show();

            this.Hide();
        }
    
    }
}
