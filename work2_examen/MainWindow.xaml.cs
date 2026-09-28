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
<<<<<<< HEAD
=======
        private ObservableCollection<User> allUsers = new ObservableCollection<User>();
        private ObservableCollection<User> filteredUsers = new ObservableCollection<User>();

        private string connectionString = "server=localhost;user=Ivan;database=CompanyDB;port=3306;password=abcd123456abcd;CharSet=utf8;";

>>>>>>> 0045d8762025823388fb806947003bd21259c9cf
        public MainWindow()
        {
            InitializeComponent();
            searchButton_Click(null, null);
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new testContext()) 
                {
                    var lastName = searchBox.Text; 

                    var users = string.IsNullOrWhiteSpace(lastName)
                        ? db.Users.ToList()
                        : db.Users
                            .Where(x => x.LastName.Contains(lastName)) 
                            .ToList();

                    userTable.ItemsSource = users; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при работе с базой данных:\n{ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
