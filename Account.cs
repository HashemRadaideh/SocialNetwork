/// <summary>
/// Account type implementation as the project description states.
/// </summary>
namespace Account
{
    using database = Database.Database;
    using pst = Actions.Post;
    using rep = Actions.Report;
    using msg = Actions.Message;

    class Account
    {
        private string username = "";
        private string password = "";
        private bool status = false;
        private string firstName = "";
        private string lastName = "";
        private string location = "";
        private int age = 0;
        private Personal.List<User>? friends = new Personal.List<User>();

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public bool Status { get => status; set => status = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Location { get => location; set => location = value; }
        public int Age { get => age; set => age = value; }
        public Personal.List<User>? Friends { get => friends; set => friends = value; }

        public Account()
        {
            this.username = "";
            this.password = "";
            this.status = false;
            this.firstName = "";
            this.lastName = "";
            this.location = "";
            this.age = 0;
            this.friends = new Personal.List<User>();
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
            this.friends = new Personal.List<User>();
        }

        public Account(string username, string password, bool status, string firstName, string lastName, string location, int age, Personal.List<User>? friends)
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
            var names = "";
            var _ = this.friends ?? throw new ArgumentNullException(nameof(this.friends));
            foreach (var friend in this.friends)
            {
                names += friend.Username + " ";
            }
            return $"Username: {Username}\nPassword: {Password}\nStatus: {Status}\nFirstName: {FirstName}\nLastName: {LastName}\nLocation: {Location}\nAge: {Age}\nFriends: {names}";
        }
    }

    class Administrator : Account
    {
        /// <summary>
        /// Design pattern: Singleton
        /// The administrator class is a singleton class, which means that there is only one instance of it.
        /// And that means there is only one administrator in the system.
        /// </summary>
        private static readonly Administrator instance = new Administrator();
        private Administrator() : base()
        {
            this.Username = "admin";
            this.Password = "0";
            this.Status = true;
            this.FirstName = "Admin";
            this.LastName = "Admin";
            this.Location = "Private";
            this.Age = 0;
            this.Friends = new Personal.List<User>();
        }
        public static Administrator Instance { get { return instance; } }

        public void RegisterNewUserAccount()
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
            int age = 0;
            if (int.TryParse(Console.ReadLine(), out int result))
                age = result;
            else
                throw new ArgumentException("Age must be a number");

            database.Instance.Add("users", new Account(username, password, true, firstName, lastName, location, age));
        }

        public void ViewAllUserAccounts()
        {
            // TODO: View all user accounts
            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                Console.WriteLine(row + "\n");
            }
        }

        private bool IsSuspendable(string username)
        {
            username = username ?? throw new ArgumentNullException(nameof(username));

            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var user = (User)row;
                if (user.Username == username)
                {
                    return true;
                }
            }

            return false;
        }

        public void SuspendUserAccount()
        {
            // TODO: Suspend user account
            Console.Write("Enter Username: ");
            string? username = Console.ReadLine();
            username = username ?? throw new ArgumentNullException(nameof(username));

            if (IsSuspendable(username))
            {
                var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
                foreach (var row in table.Rows.Values)
                {
                    var user = (User)row;
                    if (user.Username == username)
                    {
                        user.Status = false;
                        return;
                    }
                }
            }
        }

        public void ActivateUserAccount()
        {
            // TODO: Activate user account
            Console.Write("Enter Username: ");
            string? username = Console.ReadLine();

            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var user = (User)row;
                if (user.Username == username)
                {
                    user.Status = true;
                }
            }
        }
    }

    class User : Account
    {
        public User(string username, string password, bool status, string firstName, string lastName, string location, int age) : base(username, password, status, firstName, lastName, location, age) { }

        public User(string username, string password, bool status, string firstName, string lastName, string location, int age, Personal.List<User>? friends) : base(username, password, status, firstName, lastName, location, age, friends) { }

        public void PostNewContent()
        {
            // TODO: Post new content
            Console.Write("Enter Content: ");
            string? content = Console.ReadLine();
            content = content ?? throw new ArgumentNullException(nameof(content));

            database.Instance.Add("posts", new pst(this.Username, content)); // this.Username -> Poster's username, content -> content
        }

        public void SendMessage()
        {
            // TODO: Send message
            Console.Write("Enter Username: ");
            string? username = Console.ReadLine();
            username = username ?? throw new ArgumentNullException(nameof(username));

            Console.Write("Enter Content: ");
            string? content = Console.ReadLine();
            content = content ?? throw new ArgumentNullException(nameof(content));

            database.Instance.Add("messages", new msg(this.Username, username, content)); // this.Username -> sender, username -> receiver, content -> message
        }

        public void ViewAllMyPosts()
        {
            // TODO: View all my posts
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var post = (pst)row;
                if (post.Author == db.IndexOf("users", this.Username))
                {
                    Console.WriteLine(row);
                }
            }
        }

        public void ViewAllMyReceivedMessages()
        {
            // TODO: View all my received messages
            var db = database.Instance;
            var table = db.GetTable("messages") ?? throw new Exception($"Table '{"messages"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var message = (msg)row;
                if (message.Receiver == db.IndexOf("users", this.Username))
                {
                    Console.WriteLine(row);
                }
            }
        }

        public void ViewAllMyLastUpdatedWall()
        {
            // TODO: View all my last updated wall
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var post = (pst)row;
                if (post.Author == db.IndexOf("users", this.Username))
                {
                    Console.WriteLine(row);
                }
            }
        }

        public void FilterMyWall()
        {
            // TODO: Filter my wall
            Console.Write("Enter Filter: ");
            string? filter = Console.ReadLine();
            filter = filter ?? throw new ArgumentNullException(nameof(filter));

            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            foreach (var row in table.Rows.Values)
            {
                var post = (pst)row;
                if (post.Author == db.IndexOf("users", this.Username) && post.Content.Contains(filter))
                {
                    Console.WriteLine(row);
                }
            }
        }

        public void SendReportToAdministrator()
        {
            // TODO: Send report to administrator
            var db = database.Instance;
            var reporter = db.IndexOf("users", this.Username);

            Console.Write("Enter Username: ");
            string? username = Console.ReadLine();
            username = username ?? throw new ArgumentNullException(nameof(username));

            var reported = db.IndexOf("users", username);

            Console.Write("Enter Content: ");
            string? content = Console.ReadLine();
            content = content ?? throw new ArgumentNullException(nameof(content));

            db.Add("reports", new rep(reporter, reported, content)); // this.Username -> reporter, content -> reports
        }
    }
}
