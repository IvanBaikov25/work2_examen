using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace work2_examen
{
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void authButton_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTextBox.Text.Trim();
            string password = passwordTextBox.Text.Trim();
            string hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                hash = builder.ToString();
            }
            var db = new testContext();
            var user = db.Users.FirstOrDefault(x => x.Login == login);

            if (user == null)
            {
                MessageBox.Show("Неверный логин");
                return;
            }

            if (hash != user.Password)
            {
                MessageBox.Show("Неверный пароль.\nОжидалось: " + user.Password + "\nПолучено: " + hash);
                return;
            }

            AppState.CurrentUser = user;

            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
