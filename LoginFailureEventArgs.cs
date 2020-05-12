using System;
using System.Collections.Generic;

namespace Lab11
{
    public class LoginFailureEventArgs: EventArgs 
    {
        public List<LoginError> errors {get;set;}
    public class LoginError
    {
        public LoginFields Field { get; set; }
        public string ErrorMessage  { get; set; }
    }
    }
    public enum LoginFields
    { 
        Login,
        Password,
        All
    }
}