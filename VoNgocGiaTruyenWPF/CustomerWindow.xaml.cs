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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        private readonly ICustomerRepository _repo;
        public CustomerWindow()
        {
            InitializeComponent();
            _repo = new CustomerRepository();
        }

        public void LoadCustomer()
        {
            try
            {
                var customerList = _repo.GetAllCustomers();
                dgData.ItemsSource = customerList;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                resetInput();
            }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadCustomer();
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            Customer? selectedCustomer = dgData.SelectedItem as Customer;
            if (selectedCustomer != null)
            {
                txtCustomerID.Text = selectedCustomer.CustomerID.ToString();
                txtCustomerFullName.Text = selectedCustomer.CustomerFullName;
                txtTelePhone.Text = selectedCustomer.Telephone;
                txtEmailAddress.Text = selectedCustomer.EmailAddress;
                dpCustomerBirthday.SelectedDate = selectedCustomer.CustomerBirthday?.ToDateTime(TimeOnly.MinValue);
                cboCustomerStatus.SelectedIndex = selectedCustomer.CustomerStatus == 1 ? 0 : 1;
                pwdPassword.Password = selectedCustomer.Password;
            }

        }
        private void resetInput()
        {
            txtCustomerID.Text = "";
            txtCustomerFullName.Text = "";
            txtTelePhone.Text = "";
            txtEmailAddress.Text = "";
            dpCustomerBirthday.SelectedDate = null;
            cboCustomerStatus.SelectedIndex = 0;
            pwdPassword.Password = "";
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Customer customer = new Customer
                {
                    CustomerFullName = txtCustomerFullName.Text,
                    Telephone = txtTelePhone.Text,
                    EmailAddress = txtEmailAddress.Text,
                    CustomerBirthday = dpCustomerBirthday.SelectedDate != null ? DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value) : null,
                    CustomerStatus = ((ComboBoxItem)cboCustomerStatus.SelectedItem).Tag.ToString() == "1" ? 1 : 2,
                    Password = pwdPassword.Password
                };
                _repo.AddCustomer(customer);
                MessageBox.Show("Customer Add Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                resetInput();
                LoadCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCustomerID.Text))
                {
                    int customerId = int.Parse(txtCustomerID.Text);
                    var existingCustomer = _repo.GetCustomerById(customerId);
                    if (existingCustomer != null)
                    {
                        existingCustomer.CustomerFullName = txtCustomerFullName.Text;
                        existingCustomer.Telephone = txtTelePhone.Text;
                        existingCustomer.EmailAddress = txtEmailAddress.Text;
                        existingCustomer.CustomerBirthday = dpCustomerBirthday.SelectedDate != null ? DateOnly.FromDateTime(dpCustomerBirthday.SelectedDate.Value) : null;
                        existingCustomer.CustomerStatus = ((ComboBoxItem)cboCustomerStatus.SelectedItem).Tag.ToString() == "1" ? 1 : 2;
                        existingCustomer.Password = pwdPassword.Password;

                        _repo.UpdateCustomer(existingCustomer);
                        MessageBox.Show("Update Customer Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetInput();
                        LoadCustomer();
                    }
                    else
                    {
                        MessageBox.Show("Not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must select a Customer!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtCustomerID.Text.Length > 0)
                {
                    Customer customer = new Customer
                    {
                        CustomerID = Int32.Parse(txtCustomerID.Text)
                    };
                    var result = MessageBox.Show("Are you sure to delete this customer?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        _repo.DeleteCustomer(customer);
                        MessageBox.Show("Customer Delete Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        resetInput();
                    }
                }
                else
                {
                    MessageBox.Show("You must select a Customer!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadCustomer();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();
        }
    }
}
