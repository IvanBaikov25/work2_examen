using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace work2_examen
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> allUsers = new ObservableCollection<User>();
        private ObservableCollection<User> filteredUsers = new ObservableCollection<User>();

        private string connectionString = "server=localhost;user=Ivan;database=CompanyDB;port=3306;password=abcd123456abcd;CharSet=utf8;";

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromDatabase();

            UsersDataGrid.ItemsSource = filteredUsers;
        }

        private void LoadDataFromDatabase()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT fio, login FROM users";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                allUsers.Add(new User
                                {
                                    Fio = reader.GetString("fio"),
                                    Login = reader.GetString("login")
                                });
                            }
                        }
                    }
                }

                UpdateFilteredCollection("");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchBox.Text.ToLower();
            UpdateFilteredCollection(searchText);
        }

        private void UpdateFilteredCollection(string searchText)
        {
            filteredUsers.Clear();

            var filtered = allUsers.Where(u => u.Fio.ToLower().Contains(searchText)).ToList();

            foreach (var user in filtered)
            {
                filteredUsers.Add(user);
            }
        }
    }

    public class User
    {
        public string Fio { get; set; }
        public string Login { get; set; }
    }
}
