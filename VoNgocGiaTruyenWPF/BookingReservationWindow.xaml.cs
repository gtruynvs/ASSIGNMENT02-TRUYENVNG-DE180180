using BusinessObjects;
using Microsoft.Identity.Client.NativeInterop;
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
    /// Interaction logic for BookingReservationWindow.xaml
    /// </summary>
    public partial class BookingReservationWindow : Window
    {
        private Customer currentCustomer;
        private readonly IBookingReservationRepository _repo;

        public BookingReservationWindow(Customer customer)
        {
            currentCustomer = customer;
            _repo = new BookingReservationRepository();
            InitializeComponent();
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            if (currentCustomer == null || currentCustomer.BookingReservations == null)
            {
                MessageBox.Show("Invalid user data. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var bookingReservations = _repo.GetAllBookingReservations()
                                  .Where(br => br.CustomerID == currentCustomer.CustomerID)
                                  .Select(br => new
                                  {
                                      br.BookingReservationID,
                                      br.BookingDate,
                                      br.TotalPrice,
                                      BookingStatus = br.BookingStatus == 1 ? "Confirmed" : "Pending"
                                  }).ToList();

            dgBookingHistory.ItemsSource = bookingReservations;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(currentCustomer);
            mainWindow.Show();
            this.Hide();
        }

        private void btnUserProfile_Click(object sender, RoutedEventArgs e)
        {
            CustomerProfile customerProfile = new CustomerProfile(currentCustomer);
            customerProfile.Show();
            this.Hide();
        }
    }
}