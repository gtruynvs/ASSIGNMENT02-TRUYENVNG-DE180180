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
    /// Interaction logic for CreateReportWindow.xaml
    /// </summary>
    public partial class CreateReportWindow : Window
    {
        private readonly IBookingReservationRepository _repo;

        public CreateReportWindow()
        {
            InitializeComponent();
            _repo = new BookingReservationRepository();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateOnly startDate = dpStartDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpStartDate.SelectedDate.Value) : DateOnly.MinValue;
            DateOnly endDate = dpEndDate.SelectedDate.HasValue ? DateOnly.FromDateTime(dpEndDate.SelectedDate.Value) : DateOnly.MaxValue;

            if (startDate == DateOnly.MinValue || endDate == DateOnly.MaxValue)
            {
                MessageBox.Show("Please select both Start Date and End Date.");
                return;
            }

            // Fetch and debug data
            var bookings = _repo.GetBookingReservationsByDateRange(startDate, endDate)
                .Select(br => new
                {
                    br.BookingReservationID,
                    BookingDate = br.BookingDate.ToString("dd/MM/yyyy"),
                    TotalPrice = br.TotalPrice != null ? $"{br.TotalPrice:C}" : "",
                    BookingStatus = br.BookingStatus == 1 ? "Confirmed" : "Pending"
                }).ToList();

            if (bookings.Count == 0)
            {
                MessageBox.Show("No data found for the selected date range.");
            }

            dgReportData.ItemsSource = bookings;  // Set the data source
        }


        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow admin = new AdminWindow();
            admin.Show();
            this.Hide();
        }
    }
}