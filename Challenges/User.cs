using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Challenges
{

    internal class User
    {
        public User(string username, string email)
        {
            if (username == "")
            {
                throw new ArgumentException("Please enter a username!");
            }

            bool isValid = Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (!isValid)
            {
                throw new ArgumentException("Please enter a valid email!");
            }

            Username = username;
            Email = email;
            Balance = 0;
            AccountsCreated++;
            UserId = AccountsCreated;
        }

        public string Username {  get; }
        public string Email { get; }
        public int Balance { get; set; }
        public static int AccountsCreated { get; private set; } = 0;
        public int UserId { get; }


        public void UpdateBalance(int amount)
        {
            Balance += amount;
        }


        public static void ResetAccountsCount()
        {
            AccountsCreated = 0;
        }
    }
}
