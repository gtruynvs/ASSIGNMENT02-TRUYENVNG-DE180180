using BusinessObjects;
using Microsoft.Extensions.Configuration;
using Repositories;
using System.IO;
using System.Windows;

namespace VoNgocGiaTruyenWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly string adminEmail;
        private readonly string adminPassword;

        public LoginWindow()
        {
            InitializeComponent();
            _customerRepository = new CustomerRepository();
            var configuration = LoadConfiguration();
            adminEmail = configuration["DefaultAdminAccount:Email"];
            adminPassword = configuration["DefaultAdminAccount:Password"];
        }

        private IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            return builder.Build();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUser.Text;
            string password = txtPass.Password;
            if (email.Equals(adminEmail, StringComparison.OrdinalIgnoreCase) && password == adminPassword)
            {
                AdminWindow admin = new AdminWindow();
                admin.Show();
                this.Hide();
                return;
            }
            Customer? account = _customerRepository.GetCustomerByEmail(email);
            if (account != null && account.Password == password)
            {
                MainWindow mainWindow = new MainWindow(account);
                mainWindow.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password!", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}