using database = Core.Database;
using msg = Core.Message;
using pst = Core.Post;
using rep = Core.Report;

/// <summary>
/// Account type implementation as the project description states.
/// </summary>
namespace Core
{
    [Serializable]
    public class Account
    {
        private string username = "";
        private string password = "";
        private bool status = false;
        private string firstName = "";
        private string lastName = "";
        private string location = "";
        private int age = 0;
        private List<User>? friends = new();

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool Status { get => status; set => status = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Location { get => location; set => location = value; }
        public int Age { get => age; set => age = value; }
        public List<User>? Friends { get => friends; set => friends = value; }

        public Account()
        {
            username = "";
            password = "";
            status = false;
            firstName = "";
            lastName = "";
            location = "";
            age = 0;
            friends = new List<User>();
        }

        public Account(string username, string password, bool status, string firstName, string lastName, string location, int age)
        {
            this.username = username;
            this.password = password;
            this.status = status;
            this.firstName = firstName;
            this.lastName = lastName;
            this.location = location;
            this.age = age;
            friends = new List<User>();
        }

        public Account(string username, string password, bool status, string firstName, string lastName, string location, int age, List<User>? friends)
        {
            this.username = username;
            this.password = password;
            this.status = status;
            this.firstName = firstName;
            this.lastName = lastName;
            this.location = location;
            this.age = age;
            this.friends = friends;
        }

        public override string? ToString()
        {
            string? names = "";
            List<User>? _ = friends ?? throw new ArgumentNullException(nameof(friends));
            foreach (User? friend in friends)
            {
                names += friend.Username + " ";
            }
            return $"Username: {Username}\nPassword: {Password}\nStatus: {Status}\nFirstName: {FirstName}\nLastName: {LastName}\nLocation: {Location}\nAge: {Age}\nFriends: {names}";
        }
    }

    [Serializable]
    public class Administrator : Account
    {
        /// <summary>
        /// Design pattern: Singleton
        /// The administrator class is a singleton class, which means that there is only one instance of it.
        /// And that means there is only one administrator in the system.
        /// </summary>
        private static readonly Administrator instance = new();
        private Administrator() : base()
        {
            Username = "admin";
            Password = "0";
            Status = true;
            FirstName = "Admin";
            LastName = "Admin";
            Location = "Private";
            Age = 0;
            Friends = new List<User>();
        }
        public static Administrator Instance => instance;

        public static void RegisterNewUserAccount(string username, string password, string firstName, string lastName, string location, int age)
        {
            database.Instance.Add("users", new User(username, password, true, firstName, lastName, location, age));
        }
        public static void RegisterNewUserAccount(string username, string password, string firstName, string lastName, string location, int age, List<User> friends)
        {
            database.Instance.Add("users", new User(username, password, true, firstName, lastName, location, age, friends));
        }

        public static string ViewAllUserAccounts()
        {
            string? temp = "";

            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? row in table.Rows.Values)
            {
                temp += row + "\n";
            }

            return temp;
        }

        private static bool IsSuspendable(string username)
        {
            // if user has more than 2 reports return true
            Table? table = database.Instance.GetTable("reports") ?? throw new Exception($"Table '{"reports"}' not found.");

            int count = 0;
            foreach (object? row in table.Rows.Values)
            {
                rep? report = (rep)row;
                if (report.Reported == username)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                foreach (object? row in table.Rows.Values)
                {
                    rep? report = (rep)row;
                    if (report.Reported == username)
                    {
                        database.Instance.Remove("reports", report);
                    }
                }

                return true;
            }

            return false;
        }

        public static bool SuspendUserAccount(string username)
        {
            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? user in table.Rows.Values)
            {
                User? u = (User)user;
                if (username == u.Username && IsSuspendable(u.Username))
                {
                    u.Status = false;
                    return true;
                }
            }
            return true;
        }

        public static void ActivateUserAccount(string username)
        {
            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? row in table.Rows.Values)
            {
                User? user = (User)row;
                if (user.Username == username)
                {
                    user.Status = true;
                }
            }
        }
    }

    [Serializable]
    public class User : Account
    {
        public User(string username, string password, bool status, string firstName, string lastName, string location, int age) : base(username, password, status, firstName, lastName, location, age) { }

        public User(string username, string password, bool status, string firstName, string lastName, string location, int age, List<User>? friends) : base(username, password, status, firstName, lastName, location, age, friends) { }

        public void AddFriends(List<User> friends)
        {
            if (Friends is not null)
            {
                foreach (User? friend in friends)
                {
                    Friends.Add(friend);
                }
            }
            else
            {
                Friends = friends;
            }
        }

        public void PostNewContent(string content, bool priority, string category)
        {
            database.Instance.Add("posts", new pst(Username, content, priority, category)); // this.Username -> Poster's username, content -> content
        }

        public void SendMessage(string username, string content)
        {
            database.Instance.Add("messages", new msg(Username, username, content)); // this.Username -> sender, username -> receiver, content -> message
        }

        public string ViewAllMyPosts()
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            foreach (object? row in table.Rows.Values)
            {
                pst? post = (pst)row;
                if (post.Author == Username)
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public string ViewAllMyReceivedMessages()
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("messages") ?? throw new Exception($"Table '{"messages"}' not found.");

            foreach (object? row in table.Rows.Values)
            {
                msg? message = (msg)row;
                if (message.Receiver == Username)
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public string ViewAllMyLastUpdatedWall()
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            if (Friends is null)
            {
                return temp;
            }

            // get all posts from friends
            foreach (object? row in table.Rows.Values)
            {
                foreach (User? friend in Friends)
                {
                    pst? post = (pst)row;
                    if (post.Author == friend.Username)
                    {
                        temp += row + "\n";
                        break;
                    }
                }
            }

            return temp;
        }

        public string FilterMyWall(string filter)
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            if (Friends is null)
            {
                return temp;
            }

            foreach (object? row in table.Rows.Values)
            {
                foreach (User? friend in Friends)
                {
                    pst? post = (pst)row;
                    if (post.Author == friend.Username && filter == post.Category)
                    {
                        temp += row + "\n";
                        break;
                    }
                }
            }

            return temp;
        }

        public void SendReportToAdministrator(string username, string content)
        {
            // TODO: Send report to administrator
            database? db = database.Instance;

            db.Add("reports", new rep(Username, username, content)); // this.Username -> reporter, content -> reports
        }
    }
}
