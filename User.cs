using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Lab11
{
    public class User
    {
        public User(string login, string secureString)
        {
            Login = login;
            this.Password = secureString;
        }

        public string Login { get;private set; }
        private string Password { get; set; }

        public bool CheckingLogin(string login, SecureString password)
        {
            var test = password.ToString();
            var pwd = default(string);
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(password);
                pwd = Marshal.PtrToStringUni(unmanagedString);

            }
            finally {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
            return (Login == login && Password == password.ToString());
        }

    }
}