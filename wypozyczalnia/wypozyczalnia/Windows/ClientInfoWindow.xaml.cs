using System;
using System.Collections.Generic;
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
using wypozyczalnia.Models;

namespace wypozyczalnia.Windows
{
    /// <summary>
    /// Interaction logic for ClientInfoWindow.xaml
    /// </summary>
    public partial class ClientInfoWindow : Window
    {
        public User User { get; set; } = new User();

        public ClientInfoWindow()
        {
            InitializeComponent();
        }
        private void rentButton_Click(object sender, RoutedEventArgs e)
        {
            ConfirmationWindow confirmationWindow = new ConfirmationWindow();

            confirmationWindow.Show();

            this.Hide();
        }

        private void firstnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Firstname = textBox?.Text;
        }

        private void lastnameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Lastname = textBox?.Text;
        }

        private void phoneNumberBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.PhoneNumber = textBox?.Text;
        }

        private void peselBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Pesel = textBox?.Text;
        }

        private void streetBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Street = textBox?.Text;
        }

        private void cityBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.City = textBox?.Text;
        }

        private void countryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            User.Country = textBox?.Text;
        }

        private void startDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            var startDate = datePicker?.SelectedDate;
        }

        private void endDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            var endDate = datePicker?.SelectedDate;
        }
    }
}
