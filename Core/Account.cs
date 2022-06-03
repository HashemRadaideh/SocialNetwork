using database = Database.Database;
using msg = Actions.Message;
using pst = Actions.Post;
using rep = Actions.Report;

/// <summary>
/// Account type implementation as the project description states.
/// </summary>
namespace Account
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
            // if user has more than 2 reports return true
            var table = database.Instance.GetTable("reports") ?? throw new Exception($"Table '{"reports"}' not found.");

            int count = 0;
            foreach (var row in table.Rows.Values)
            {
                var report = (rep)row;
                if (report.Reported == username)
                {
                    count++;
                }
            }

            if (count > 1)
            {
                return true;
            }

            return false;
        }

        public bool SuspendUserAccount(string username)
        {
            var table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var user in table.Rows.Values)
            {
                var u = (User)user;
                if (username == u.Username && IsSuspendable(u.Username))
                {
                    u.Status = false;
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

        public void PostNewContent(string content, bool priority, string category)
        {
            database.Instance.Add("posts", new pst(this.Username, content, priority, category)); // this.Username -> Poster's username, content -> content
        }

        public void AddFriends(List<User> friends)
        {
            if (this.Friends is not null)
            {
                foreach (var friend in friends)
                {
                    this.Friends.Add(friend);
                }
            }
            else
            {
                this.Friends = friends;
            }
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
                if (post.Author == this.Username)
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
                if (message.Receiver == this.Username)
                {
                    temp += row + "\n";
                }
            }

            return temp;
        }

        public string ViewAllMyLastUpdatedWall()
        {
            var temp = "";
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            if (this.Friends is null) return temp;

            // get all posts from friends
            foreach (var row in table.Rows.Values)
            {
                foreach (var friend in this.Friends)
                {
                    var post = (pst)row;
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
            var temp = "";
            var db = database.Instance;
            var table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            if (Friends is null) return temp;

            foreach (var row in table.Rows.Values)
            {
                foreach (var friend in this.Friends)
                {
                    var post = (pst)row;
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
            var db = database.Instance;

            db.Add("reports", new rep(this.Username, username, content)); // this.Username -> reporter, content -> reports
        }
    }
}
