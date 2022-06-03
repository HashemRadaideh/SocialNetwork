using administrator = Core.Administrator;
using database = Core.Database;
using useraccount = Core.User;

namespace Core
{
    public class Program
    {
        public static void Main()
        {
            database? db = database.Instance;
            while (true)
            {
                Console.WriteLine("[1] Login as administrator");
                Console.WriteLine("[2] Login as user");
                Console.WriteLine("[3] Exit");

                Console.Write("Enter your choice: ");
                string? choice = Console.ReadLine();

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
            database? db = database.Instance;

            while (true)
            {
                Console.WriteLine("\nWelcome back admin, What would you like to do?");
                Console.WriteLine("1. Register new user account");
                Console.WriteLine("2. View all user accounts");
                Console.WriteLine("3. Suspend user account");
                Console.WriteLine("4. Activate user account");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            // TODO: Register new user account
                            Console.Write("Enter Username: ");
                            string? username = Console.ReadLine();
                            username = username ?? throw new ArgumentNullException(nameof(username));

                            Console.Write("Enter Password: ");
                            string? password = Console.ReadLine();
                            password = password ?? throw new ArgumentNullException(nameof(username));

                            Console.Write("Enter First Name: ");
                            string? firstName = Console.ReadLine();
                            firstName = firstName ?? throw new ArgumentNullException(nameof(firstName));

                            Console.Write("Enter Last Name: ");
                            string? lastName = Console.ReadLine();
                            lastName = lastName ?? throw new ArgumentNullException(nameof(lastName));

                            Console.Write("Enter Location: ");
                            string? location = Console.ReadLine();
                            location = location ?? throw new ArgumentNullException(nameof(location));

                            Console.Write("Enter Age: ");
                            int age = int.TryParse(Console.ReadLine(), out int result) ? result : throw new ArgumentException("Age must be a number");
                            administrator.RegisterNewUserAccount(username, password, firstName, lastName, location, age);
                        }
                        break;

                    case "2":
                        {
                            string? str = administrator.ViewAllUserAccounts();
                            Console.WriteLine(str);
                        }
                        break;

                    case "3":
                        {
                            Console.Write("Enter Username: ");
                            string? username = Console.ReadLine();
                            username = username ?? throw new ArgumentNullException(nameof(username));

                            _ = administrator.SuspendUserAccount(username);
                        }
                        break;

                    case "4":
                        {
                            Console.Write("Enter Username: ");
                            string? username = Console.ReadLine();
                            username = username ?? throw new ArgumentNullException(nameof(username));

                            administrator.ActivateUserAccount(username);
                        }
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
            database? db = database.Instance;
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
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        {
                            Console.Write("Enter Content: ");
                            string? content = Console.ReadLine();
                            if (content is null) return;

                            Console.Write("Enter Content: ");
                            bool priority = Convert.ToBoolean(Console.ReadLine());

                            Console.Write("Enter Content: ");
                            string? category = Console.ReadLine();
                            if (category is null) return;

                            user.PostNewContent(content, priority, category);
                        }
                        break;

                    case "2":
                        {
                            Console.Write("Enter Username: ");
                            string? username = Console.ReadLine();
                            if (username is null) return;

                            Console.Write("Enter Content: ");
                            string? content = Console.ReadLine();
                            if (content is null) return;

                            user.SendMessage(username, content);
                        }
                        break;

                    case "3":
                        {
                            string? temp = user.ViewAllMyPosts();
                            Console.WriteLine(temp);
                        }
                        break;

                    case "4":
                        {
                            string? temp = user.ViewAllMyReceivedMessages();
                            Console.WriteLine(temp);
                        }
                        break;

                    case "5":
                        {
                            string? temp = user.ViewAllMyLastUpdatedWall();
                            Console.WriteLine(temp);
                        }
                        break;

                    case "6":
                        {
                            Console.Write("Enter Filter: ");
                            string? filter = Console.ReadLine();
                            if (filter is null) return;

                            _ = user.FilterMyWall(filter);
                        }
                        break;

                    case "7":
                        {
                            Console.Write("Enter Username: ");
                            string? username = Console.ReadLine();
                            if (username is null) return;

                            Console.Write("Enter Content: ");
                            string? content = Console.ReadLine();
                            if (content is null) return;

                            user.SendReportToAdministrator(username, content);
                        }
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
            string? username = Console.ReadLine();
            Console.Write("Enter password: ");
            string? password = string.Empty;

            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
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