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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab11
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> users = new List<User>()
        {
            new User("JanQ","haslo1"),
            new User("JanW","haslo2"),
            new User("JanE","haslo3")
        };
        public event EventHandler<LoginFailureEventArgs> LoginFailed;
        public event EventHandler<EventArgs> LoginSuccess;
        public MainWindow()
        {
            InitializeComponent();
            LoginFailed += CustomLoginControl.OnLoginFailure;
            LoginSuccess += CustomLoginControl.OnLoginSuccess;
            
        }
        private void CustomsLoginControl_LoginAttempt(object sender, LoginEventArgs e)
        {
            var user=users.Where(x => x.CheckingLogin(e.Login, e.Password)).SingleOrDefault();
            if (user == null)
            {
                LoginFailed?.Invoke(this, new LoginFailureEventArgs()
                {
                    errors = new List<LoginFailureEventArgs.LoginError>()
                    {
                        new LoginFailureEventArgs.LoginError()
                        {
                            Field=LoginFields.All,
                            ErrorMessage="wrong username or password"
                        }
                    }
                });
            }
            else
            {
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
            
        }
    }
}
