using System;
using System.Security;

namespace Lab11
{
    public class LoginEventArgs: EventArgs
    {
        public LoginEventArgs(string login, SecureString password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }
        public SecureString Password { get; set; }
    }
}