using Epam.UserInfo.Logic;
using Epam.UserInfo.LogicContracts;
using Epam.UsersInfo.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.UsersInfo.ConsoleUI
{
    internal class Program
    {
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;
        private static readonly string stringFormat = "dd/MM/yyyy";

        static Program()
        {
            userLogic = new UserLogic();
            awardLogic = new AwardLogic();
        }

        private static string EnterUser()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            if (name == String.Empty || name == null)
                throw new ArgumentException("Name can't be null or empty", nameof(name));

            Console.Write("Enter date of birth (format - {0}): ", stringFormat);
            string dateOfBirth = Console.ReadLine();
            DateTime teempDate;
            if (!DateTime.TryParseExact(dateOfBirth, stringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out teempDate))
                throw new ArgumentException("Date incorrect");
            return $"{name}|{dateOfBirth}";
        }

        private static void AddUser()
        {
            userLogic.Save(EnterUser());
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void ShowUsers()
        {
            User[] users = userLogic.GetAll();
            Console.WriteLine("List of users:");
            foreach (var user in users)
            {
                Console.Write($"ID:{user.Id}; Name - {user.Name}; DateOfBirth - {user.DateOfBirth.Day}/{user.DateOfBirth.Month}/{user.DateOfBirth.Year}; Age - {user.Age}; Awards: ");
                if (user.AwardsID == null)
                    Console.WriteLine("JOPA");
                /*
                                foreach (var award in user.AwardsID)
                                {
                                    if (award.Title == String.Empty)
                                    {
                                        Console.Write("None");
                                    }
                                    Console.Write($"{award.Title}; ");
                                }
                                Console.WriteLine();*/
            }
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void DeleteUser()
        {
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            userLogic.Delete(id);
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void AddAward()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();
            if (title == String.Empty || title == null)
                throw new ArgumentException("Name can't be null or empty", nameof(title));
            awardLogic.Save(title);
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void ShowAwards()
        {
            Award[] awards = awardLogic.GetAll();
            Console.WriteLine("List of awards:");
            foreach (var award in awards)
            {
                Console.WriteLine($"ID:{award.Id}; Title - {award.Title}");
            }
            Console.Write("Press any button to continue...");
            Console.ReadLine();
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();

                try
                {
                    Console.WriteLine("1. Add user");
                    Console.WriteLine("2. Remove user");
                    Console.WriteLine("3. Show list of users");
                    Console.WriteLine("4. Add award");
                    Console.WriteLine("5. Show awards");
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("--------------------------");

                    ConsoleKeyInfo entry = Console.ReadKey(intercept: true);
                    switch (entry.Key)
                    {
                        case ConsoleKey.D1:
                            AddUser();
                            Console.WriteLine("User saved.");
                            break;

                        case ConsoleKey.D2:
                            DeleteUser();
                            break;

                        case ConsoleKey.D3:

                            ShowUsers();
                            break;

                        case ConsoleKey.D4:
                            AddAward();
                            Console.ReadLine();
                            break;

                        case ConsoleKey.D5:
                            ShowAwards();
                            break;

                        case ConsoleKey.D0:
                            return;

                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                    Console.Write("Press any button to continue...");
                    Console.ReadLine();
                }
            }
        }
    }
}