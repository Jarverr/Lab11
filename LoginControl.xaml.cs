using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace Lab11
{
    /// <summary>
    /// Logika interakcji dla klasy LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public event EventHandler<LoginEventArgs> loginAtempt;
        public string Login { get; set; }
        public SecureString Password { get; set; }
        public LoginControl()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            errorsSP.Children.Clear();
            Login = LoginTextBox.Text;
            Password = PasswordBox.SecurePassword;
            loginAtempt?.Invoke(this, new LoginEventArgs(Login,Password));
        }
        public void OnLoginSuccess(object sender, EventArgs e)
        {

        }
        public void OnLoginFailure(object sender, LoginFailureEventArgs e)
        {
            
            foreach (var item in e.errors)
            {
                errorsSP.Children.Add(
                    new Label()
                    {
                        Content = $"[{item.Field}] {item.ErrorMessage}",
                        Foreground= new SolidColorBrush(Colors.Red)
                    }

                    );
            }
            Login = string.Empty;
            PasswordBox.Clear();
        }

    }
}
