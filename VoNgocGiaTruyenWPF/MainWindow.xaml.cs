using BusinessObjects;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace VoNgocGiaTruyenWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Customer _currentCustomer;
        private readonly ICustomerRepository _customerRepository;

        public MainWindow(Customer customer)
        {
            InitializeComponent();
            _currentCustomer = customer;
            _customerRepository = new CustomerRepository();
            lblWelcome.Text = $"Hello, {customer.CustomerFullName}";
        }

        private void BookingHistory_Click(object sender, RoutedEventArgs e)
        {
            BookingReservationWindow bookingReservationWindow = new BookingReservationWindow(_currentCustomer);
            bookingReservationWindow.Show();
            this.Hide();
        }

        private void EditProfile_Click(object sender, RoutedEventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile(_currentCustomer);
            customerProfile.Show();
            this.Hide();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}