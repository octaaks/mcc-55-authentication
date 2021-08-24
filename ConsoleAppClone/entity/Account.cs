using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppClone.entity
{
    class Account
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }


        public Account()
        {

        }

   
        public Account(string username, string password, string firstname, string lastname)
        {
            Username = username;
            Password = password;
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
