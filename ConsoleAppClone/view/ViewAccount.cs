using System;
using System.Collections.Generic;
using System.Text;
using ConsoleAppClone.service;
using ConsoleAppClone.entity;
using ConsoleAppClone.view;

namespace ConsoleAppClone.view
{
    class ViewAccount
    {
        public static void Register()
        {
            bool isCheck = true;
            Console.Clear();

            while (isCheck) 
            {
                Console.WriteLine("==CREATE USER==");
                Console.Write("Firstname : ");
                string inputFirstname = Console.ReadLine();

                if(inputFirstname == "q")
                {
                    isCheck = false;
                }
                else
                {
                    Console.Write("Lastname  : ");
                    string inputLastname = Console.ReadLine();
                    Console.Write("Password  : ");
                    string inputPassword = Console.ReadLine();

                    if (inputFirstname != "" && inputLastname != "" && inputPassword != "")
                    {
                        isCheck = !ServiceAccount.Create(inputPassword, inputFirstname, inputLastname);
                    }
                }

                Console.Clear();

            }
            
        }

        public static void ViewUser()
        {
            var accounts = ImplementAccount.GetAll();
            bool isCheck = true;
            Console.Clear();

            while (isCheck)
            {
                Console.WriteLine("==SHOW USER==");
                for (int i = 0; i < accounts.Count; i++)
                {
                    Console.WriteLine("=======================================");
                    Console.WriteLine($"NAME      : {accounts[i].Firstname} {accounts[i].Lastname}");
                    Console.WriteLine($"USERNAME  : {accounts[i].Username}");
                    Console.WriteLine($"PASSWORD  : {accounts[i].Password}");
                    Console.WriteLine("=======================================");
                }

                Console.ReadKey(true);
                string input = Console.ReadLine();
                isCheck = false;
                Console.Clear();
            }
            
        }

        public static void Login()
        {
            bool isCheck = true;
            Console.Clear();

            while (isCheck)
            {
                Console.WriteLine("==LOGIN==");
                Console.WriteLine("USERNAME : ");
                string inputUsername = Console.ReadLine();
                Console.WriteLine("PASSWORD : ");
                string inputPassword = Console.ReadLine();

                if (ServiceAccount.CheckUsername(inputUsername))
                {
                    if (ServiceAccount.CheckPassword(inputUsername, inputPassword))
                    {
                        Console.WriteLine("MESSAGE : LOGIN SUCCESSFULL!!!");
                        ViewDashboard.ChangePassword(inputUsername);
                    }
                    else
                    {
                        Console.WriteLine("WRONG PASSWORD!!!");
                    }
                }
                else
                {
                    Console.WriteLine("MESSAGE : USERNAME NOT FOUND!!!");
                }

                Console.ReadKey();
                Console.Clear();
                isCheck = false;
            }
        }

        public static void Searching()
        {
            bool isCheck = true;
            var account = ImplementAccount.GetAll();

            Console.Clear();

            while (isCheck)
            {
                Console.Clear();
                Console.WriteLine("==SEARCH USER==");
                Console.Write("Search : ");
                string searchKey = Console.ReadLine();

                int dataFound = 0;

                for (int i = 0; i < account.Count; i++)
                {
                    if (account[i].Firstname.Contains(searchKey) || account[i].Lastname.Contains(searchKey))
                    {
                        dataFound++;
                    }
                }

                Console.WriteLine("FOUND :" + dataFound);

                for (int i = 0; i < account.Count; i++)
                {
                    if (account[i].Firstname.Contains(searchKey) || account[i].Lastname.Contains(searchKey))
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine($"NAME     : {account[i].Firstname} {account[i].Lastname}");
                        Console.WriteLine($"USERNAME : {account[i].Username}");
                        Console.WriteLine($"PASSWORD : {account[i].Password}");
                        Console.WriteLine("=====================================");
                    }
                }

                Console.WriteLine("WANNA SEARCH AGAIN? (y/n)");
                string inputConf = Console.ReadLine();
                isCheck = (inputConf == "y") ? true : false;
            }
        }
    }
}
