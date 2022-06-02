/// <summary>
/// Account type implementation as the project description states.
/// </summary>
namespace Account
{
    using database = Database.Database;
    using msg = Actions.Message;
    using pst = Actions.Post;
    using rep = Actions.Report;

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
        private List<User>? friends = new List<User>();

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
            this.username = "";
            this.password = "";
            this.status = false;
            this.firstName = "";
            this.lastName = "";
            this.location = "";
            this.age = 0;
            this.friends = new List<User>();
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
            this.friends = new List<User>();
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
            var names = "";
            var _ = this.friends ?? throw new ArgumentNullException(nameof(this.friends));
            foreach (var friend in this.friends)
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
            this.Friends = new List<User>();
        }
        public static Administrator Instance { get { return instance; } }

        public void RegisterNewUserAccount(string username, string password, string firstName, string lastName, string location, int age)
        {
            database.Instance.Add("users", new User(username, password, true, firstName, lastName, location, age));
        }
        public void RegisterNewUserAccount(string username, string password, string firstName, string lastName, string location, int age, List<User> friends)
        {
            database.Instance.Add("users", new User(username, password, true, firstName, lastName, location, age, friends));
        }

        public string ViewAllUserAccounts()
        {
            var temp = "";

            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                temp += row + "\n";
            }

            return temp;
        }

        private bool IsSuspendable(string username)
        {
            username = username ?? throw new ArgumentNullException(nameof(username));
            User? user = null;

            // find the user
            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var u = (User)row;
                if (u.Username == username)
                {
                    user = u;
                }
            }

            if (user is null)
            {
                return false;
            }

            // return true if the user has 2 or more reports
            var count = 0;
            var table2 = database.Instance.GetTable("reports") ?? throw new Exception($"Table '{"reports"}' not found.");
            foreach (var row in table2.Rows.Values)
            {
                var r = (Actions.Report)row;
                if (r.Reporter == table.IndexOf(user.Username))
                {
                    count++;
                }
            }

            if (count >= 2)
            {
                return true;
            }

            return false;
        }

        public bool SuspendUserAccount(string username)
        {
            if (!(IsSuspendable(username)))
            {
                return false;
            }

            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var user = (User)row;
                if (user.Username == username)
                {
                    user.Status = false;
                    return true;
                }
            }

            return false;
        }

        public void ActivateUserAccount(string username)
        {
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

    [Serializable]
    public class User : Account
    {
        public User(string username, string password, bool status, string firstName, string lastName, string location, int age) : base(username, password, status, firstName, lastName, location, age) { }

        public User(string username, string password, bool status, string firstName, string lastName, string location, int age, List<User>? friends) : base(username, password, status, firstName, lastName, location, age, friends) { }

        public void PostNewContent(string content, bool priority)
        {
            database.Instance.Add("posts", new pst(this.Username, content, priority)); // this.Username -> Poster's username, content -> content
        }

        public void SendMessage(string username, string content)
        {
            database.Instance.Add("messages", new msg(this.Username, username, content)); // this.Username -> sender, username -> receiver, content -> message
        }

        public string ViewAllMyPosts()
        {
            var temp = "";
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            foreach (var row in table.Rows.Values)
            {
                var post = (pst)row;
                if (post.Author == db.IndexOf("users", this.Username))
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public string ViewAllMyReceivedMessages()
        {
            var temp = "";
            var db = database.Instance;
            var table = db.GetTable("messages") ?? throw new Exception($"Table '{"messages"}' not found.");

            foreach (var row in table.Rows.Values)
            {
                var message = (msg)row;
                if (message.Receiver == db.IndexOf("users", this.Username))
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public string ViewAllMyLastUpdatedWall()
        {
            // TODO: View all my last updated wall
            var temp = "";
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            foreach (var row in table.Rows.Values)
            {
                var post = (pst)row;
                if (post.Author == db.IndexOf("users", this.Username))
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public string FilterMyWall(string filter)
        {
            var temp = "";
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            foreach (var row in table.Rows.Values)
            {
                var post = (pst)row;
                if (post.Author == db.IndexOf("users", this.Username) && post.Content.Contains(filter))
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public void SendReportToAdministrator(string username, string content)
        {
            // TODO: Send report to administrator
            var db = database.Instance;
            var reporter = db.IndexOf("users", this.Username);
            var reported = db.IndexOf("users", username);

            db.Add("reports", new rep(reporter, reported, content)); // this.Username -> reporter, content -> reports
        }
    }
}
