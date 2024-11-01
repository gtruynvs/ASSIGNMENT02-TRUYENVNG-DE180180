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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly ICustomerRepository _repo;
        public AdminWindow()
        {
            InitializeComponent();
            _repo = new CustomerRepository();
        }

        private void CustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var customerWindow = new CustomerWindow();
            customerWindow.Show();
        }

        private void RoomManagement_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var roomWindow = new RoomInformationManagement();
            roomWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            var reportWindow = new CreateReportWindow();
            reportWindow.Show();
        }
    }
}
