﻿namespace SocialNetwork
{
    using administrator = Account.Administrator;
    using database = Database.Database;
    using useraccount = Account.User;

    public class Program
    {
        public static void Main(string[] args)
        {
            var db = database.Instance;
            while (true)
            {
                Console.WriteLine("[1] Login as administrator");
                Console.WriteLine("[2] Login as user");
                Console.WriteLine("[3] Exit");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            var (username, password) = GetLogin();
                            var admin = db.Login(username, password);

                            if (admin is not null && admin == administrator.Instance)
                            {
                                AdminLoop();
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid username or password!\n");
                            }
                        }
                        break;

                    case "2":
                        {
                            var (username, password) = GetLogin();
                            var user = db.Login(username, password);

                            if (user is not null)
                            {
                                UserLoop((useraccount)user);
                            }
                            else
                            {
                                Console.WriteLine("\nInvalid username or password!\n");
                            }
                        }
                        break;

                    case "3":
                        Console.WriteLine("\nExiting...");
                        db.Save();
                        return;

                    default:
                        Console.WriteLine("\nInvalid choice");
                        break;
                }
            }
        }


        public static void AdminLoop()
        {
            var db = database.Instance;
            var admin = administrator.Instance;

            while (true)
            {
                Console.WriteLine("\nWelcome back admin, What would you like to do?");
                Console.WriteLine("1. Register new user account");
                Console.WriteLine("2. View all user accounts");
                Console.WriteLine("3. Suspend user account");
                Console.WriteLine("4. Activate user account");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        admin.RegisterNewUserAccount();
                        break;

                    case "2":
                        admin.ViewAllUserAccounts();
                        break;

                    case "3":
                        admin.SuspendUserAccount();
                        break;

                    case "4":
                        admin.ActivateUserAccount();
                        break;

                    case "5":
                        db.Save();
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        public static void UserLoop(useraccount user)
        {
            var db = database.Instance;
            while (true)
            {
                Console.WriteLine($"\nWelcome back {user.Username}, What would you like to do?");
                Console.WriteLine("1. Post new content");
                Console.WriteLine("2. Send message");
                Console.WriteLine("3. View all my posts");
                Console.WriteLine("4. View all my received messages");
                Console.WriteLine("5. View all my last updated wall");
                Console.WriteLine("6. Filter my wall");
                Console.WriteLine("7. Send report to administrator");
                Console.WriteLine("8. Exit");

                Console.Write("\nEnter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        user.PostNewContent();
                        break;

                    case "2":
                        user.SendMessage();
                        break;

                    case "3":
                        user.ViewAllMyPosts();
                        break;

                    case "4":
                        user.ViewAllMyReceivedMessages();
                        break;

                    case "5":
                        user.ViewAllMyLastUpdatedWall();
                        break;

                    case "6":
                        user.FilterMyWall();
                        break;

                    case "7":
                        user.SendReportToAdministrator();
                        break;

                    case "8":
                        db.Save();
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        public static (string? username, string? password) GetLogin()
        {
            Console.Write("Enter username: ");
            var username = Console.ReadLine();
            Console.Write("Enter password: ");
            var password = string.Empty;

            ConsoleKey key;
            do
            {
                var keyInfo = Console.ReadKey(intercept: true);
                key = keyInfo.Key;

                if (key == ConsoleKey.Backspace && password.Length > 0)
                {
                    Console.Write("\b \b");
                    password = password[0..^1];
                }
                else if (!char.IsControl(keyInfo.KeyChar))
                {
                    Console.Write("*");
                    password += keyInfo.KeyChar;
                }
            }
            while (key != ConsoleKey.Enter);

            Console.WriteLine();
            return (username, password);
        }
    }
}