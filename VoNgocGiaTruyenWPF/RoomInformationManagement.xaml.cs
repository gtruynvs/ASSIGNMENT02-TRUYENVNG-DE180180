using BusinessObjects;
using Repositories;
using System.Windows;
using System.Windows.Controls;

namespace VoNgocGiaTruyenWPF
{
    /// <summary>
    /// Interaction logic for RoomInformationManagement.xaml
    /// </summary>
    public partial class RoomInformationManagement : Window
    {
        private readonly IRoomInformationRepository _roomInformationRepository;

        public RoomInformationManagement()
        {
            InitializeComponent();
            _roomInformationRepository = new RoomInformationRepository();
        }

        public void LoadRoomList()
        {
            try
            {
                var roomList = _roomInformationRepository.GetAllRoomInformation();
                dgData.ItemsSource = roomList;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error on loading room list");
            }
            finally
            {
                ResetInput();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadRoomList();
        }

        private void ResetInput()
        {
            txtRoomID.Text = "";
            txtRoomNumber.Text = "";
            txtRoomDetailDescription.Text = "";
            txtRoomMaxCapacity.Text = "";
            txtRoomTypeID.Text = "";
            cboRoomStatus.SelectedIndex = 0;
            txtRoomPricePerDay.Text = "";
        }

        private void dgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgData.SelectedItem == null)
                return;

            if (dgData.SelectedItem is RoomInformation selectedRoom)
            {
                txtRoomID.Text = selectedRoom.RoomID.ToString();
                txtRoomNumber.Text = selectedRoom.RoomNumber ?? "";
                txtRoomDetailDescription.Text = selectedRoom.RoomDetailDescription ?? "";
                txtRoomMaxCapacity.Text = selectedRoom.RoomMaxCapacity.ToString();
                txtRoomTypeID.Text = selectedRoom.RoomTypeID.ToString();
                cboRoomStatus.SelectedIndex = selectedRoom.RoomStatus == 1 ? 0 : 1;
                txtRoomPricePerDay.Text = selectedRoom.RoomPricePerDate.ToString();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RoomInformation room = new RoomInformation
                {
                    RoomNumber = txtRoomNumber.Text,
                    RoomDetailDescription = txtRoomDetailDescription.Text,
                    RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text),
                    RoomPricePerDate = decimal.Parse(txtRoomPricePerDay.Text),
                    RoomTypeID = int.Parse(txtRoomTypeID.Text),
                    RoomStatus = 1
                };
                _roomInformationRepository.AddRoom(room);
                MessageBox.Show("Room Add Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                ResetInput();
                LoadRoomList();
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
                if (!string.IsNullOrEmpty(txtRoomID.Text))
                {
                    int RoomID = int.Parse(txtRoomID.Text);
                    var existingRoom = _roomInformationRepository.GetRoomById(RoomID);

                    if (existingRoom != null)
                    {
                        existingRoom.RoomNumber = txtRoomNumber.Text;
                        existingRoom.RoomDetailDescription = txtRoomDetailDescription.Text;
                        existingRoom.RoomMaxCapacity = int.Parse(txtRoomMaxCapacity.Text);
                        existingRoom.RoomPricePerDate = decimal.Parse(txtRoomMaxCapacity.Text);
                        existingRoom.RoomTypeID = int.Parse(txtRoomTypeID.Text);
                        existingRoom.RoomStatus = 1;
                        _roomInformationRepository.UpdateRoom(existingRoom);
                        MessageBox.Show("Update Room Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetInput();
                        LoadRoomList();
                    }
                    else
                    {
                        MessageBox.Show("Not found!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("You must select a Room!");
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
                if (txtRoomID.Text.Length > 0)
                {
                    RoomInformation room = new RoomInformation
                    {
                        RoomID = int.Parse(txtRoomID.Text)
                    };
                    var result = MessageBox.Show("Are you sure to delete this Room?", "Confirm deletion", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        _roomInformationRepository.DeleteRoom(room);
                        MessageBox.Show("Room Delete Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        ResetInput();
                    }
                }
                else
                {
                    MessageBox.Show("You must select a room!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                LoadRoomList();
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