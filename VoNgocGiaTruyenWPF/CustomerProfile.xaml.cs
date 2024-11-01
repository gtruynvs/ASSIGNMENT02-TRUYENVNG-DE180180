using BusinessObjects;
using Repositories;
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

namespace VoNgocGiaTruyenWPF
{
    /// <summary>
    /// Interaction logic for CustomerProfile.xaml
    /// </summary>
    public partial class CustomerProfile : Window
    {
        private Customer currentCustomer;
        private readonly ICustomerRepository _repo;
        public CustomerProfile(Customer customer)
        {
            currentCustomer = customer;
            _repo = new CustomerRepository();
            InitializeComponent();
            LoadUserProfile();
        }
        private void LoadUserProfile()
        {
            txtCustomerID.Text = currentCustomer.CustomerID.ToString();
            txtCustomerFullName.Text = currentCustomer.CustomerFullName;
            txtTelephone.Text = currentCustomer.Telephone;
            txtEmailAddress.Text = currentCustomer.EmailAddress;
            dpCustomerBirthday.SelectedDate = currentCustomer.CustomerBirthday.Value.ToDateTime(TimeOnly.MinValue);
            cboCustomerStatus.SelectedIndex = currentCustomer.CustomerStatus == 1 ? 0 : 1;
            pwdPassword.Password = currentCustomer.Password;
        }
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer.CustomerFullName = txtCustomerFullName.Text;
            currentCustomer.Telephone = txtTelephone.Text;
            currentCustomer.EmailAddress = txtEmailAddress.Text;
            currentCustomer.CustomerBirthday = DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value);
            currentCustomer.CustomerStatus = cboCustomerStatus.SelectedIndex == 0 ? (int)1 : (int)0;
            currentCustomer.Password = pwdPassword.Password;
            _repo.UpdateCustomer(currentCustomer);
            LoadUserProfile();
            MessageBox.Show("Profile updated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentCustomer);
            mainWindow.Show();
            this.Hide();
        }

        private void btnBookingReservation_Click(object sender, RoutedEventArgs e)
        {
            BookingReservationWindow bookingReservationWindow = new BookingReservationWindow(currentCustomer);
            bookingReservationWindow.Show();
            this.Hide();
        }
    }
}
