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

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <param name="firstName">The first name of the new user.</param>
        /// <param name="lastName">The last name of the new user.</param>
        /// <param name="location">The location of the new user.</param>
        /// <param name="age">The age of the new user.</param>
        /// <returns>Returns true if the user was added successfully, false otherwise.</returns>
        public static bool RegisterNewUserAccount(string username, string password, string firstName, string lastName, string location, int age)
        {
            if (username == null || password == null || firstName == null || lastName == null || location == null)
            {
                return false;
            }

            // checkk if the username is already taken
            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? account in table.Rows.Values)
            {
                var user = (User)account;
                if (user.Username == username)
                {
                    return false;
                }
            }

            // save the new user account to the database
            database.Instance.Add("users", new User(username, password, true, firstName, lastName, location, age));
            return true;
        }

        /// <summary>
        /// Adds a new user to the system.
        /// </summary>
        /// <param name="username">The username of the new user.</param>
        /// <param name="password">The password of the new user.</param>
        /// <param name="firstName">The first name of the new user.</param>
        /// <param name="lastName">The last name of the new user.</param>
        /// <param name="location">The location of the new user.</param>
        /// <param name="age">The age of the new user.</param>
        /// <param name="friends">The friends of the new user.</param>
        /// <returns>Returns true if the user was added successfully, false otherwise.</returns>
        public static bool RegisterNewUserAccount(string username, string password, string firstName, string lastName, string location, int age, List<User> friends)
        {
            if (username == null || password == null || firstName == null || lastName == null || location == null)
            {
                return false;
            }

            // save the user to the database
            database.Instance.Add("users", new User(username, password, true, firstName, lastName, location, age, friends));
            return true;
        }

        /// <summary>
        /// Retreives all the users in the system.
        /// </summary>
        /// <returns>Returns a string of all the users in the system.</returns>
        public static string ViewAllUserAccounts()
        {
            string? temp = "";

            // retreive all users from user table and store them in a string
            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? row in table.Rows.Values)
            {
                temp += row + "\n";
            }

            return temp;
        }

        /// <summary>
        /// Checks if the user meets suspandation criteria.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>Returns true if the user meets the criteria, false otherwise.</returns>
        /// <remarks>
        /// Suspandation criteria:
        /// - User has been reported by 2 or more users.
        /// </remarks>
        private static bool IsSuspendable(string username)
        {
            // if user has more than 2 reports return true
            Table? table = database.Instance.GetTable("reports") ?? throw new Exception($"Table '{"reports"}' not found.");

            int count = 0;
            foreach (object? row in table.Rows.Values)
            {
                // find the number of reports of the user
                rep? report = (rep)row;
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

        /// <summary>
        /// Suspends a user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>Returns true if the user was suspended successfully, false otherwise.</returns>
        /// <remarks>
        /// Suspandation criteria:
        /// - User has been reported by 2 or more users.
        /// </remarks>
        public static bool SuspendUserAccount(string username)
        {
            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? user in table.Rows.Values)
            {
                User? u = (User)user;
                if (username == u.Username && IsSuspendable(u.Username))
                {
                    u.Status = false;

                    // if user has more than 2 reports delete reports
                    Table? rep_table = database.Instance.GetTable("reports") ?? throw new Exception($"Table '{"reports"}' not found.");
                    foreach (object? row in rep_table.Rows.Values)
                    {
                        // find reports for the user and delete them
                        rep? report = (rep)row;
                        if (report.Reported == u.Username)
                        {
                            database.Instance.Remove("reports", report);
                        }
                    }
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// Unsuspends a user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>Returns true if the user was unsuspended successfully, false otherwise.</returns>
        public static bool ActivateUserAccount(string username)
        {
            // find the user and activate it
            // doesn't matter if the user is suspended or not
            Table? table = database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (object? row in table.Rows.Values)
            {
                User? user = (User)row;
                if (user.Username == username)
                {
                    user.Status = true;
                    return true;
                }
            }

            return false;
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

        /// <summary>
        /// Adds a new friend to the user's friend list.
        /// </summary>
        /// <param name="friend">The friend to add.</param>
        /// <returns>Returns true if the friend was added successfully, false otherwise.</returns>
        /// <remarks>
        /// If the friend is already in the user's friend list, nothing happens.
        /// </remarks>
        public bool PostNewContent(string content, bool priority, string category)
        {
            if (content == null || category == null)
            {
                return false;
            }

            // savae post to database
            database.Instance.Add("posts", new pst(Username, content, priority, category)); // this.Username -> Poster's username, content -> content
            return true;
        }

        /// <summary>
        /// Retreives all the posts in the system.
        /// </summary>
        /// <returns>Returns a string of all the posts in the system.</returns>
        /// <remarks>
        /// The posts are sorted by priority.
        /// </remarks>
        public bool SendMessage(string username, string content)
        {
            if (username == null || content == null)
            {
                return false;
            }

            // save report to database
            database.Instance.Add("messages", new msg(Username, username, content)); // this.Username -> sender, username -> receiver, content -> message
            return true;
        }

        /// <summary>
        /// Retreives all the posts in the system.
        /// </summary>
        /// <returns>Returns a string of all the posts in the system.</returns>
        /// <remarks>
        /// The posts are sorted by priority.
        /// </remarks>
        public string ViewAllMyPosts()
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            // retreive all posts with high (true) priority from post table and store them in a string
            foreach (object? row in table.Rows.Values)
            {
                pst? post = (pst)row;
                if (post.Author == Username && post.Priority == true)
                {
                    temp += post + "\n";
                }
            }

            // again but with low (false) priority
            foreach (object? row in table.Rows.Values)
            {
                pst? post = (pst)row;
                if (post.Author == Username && post.Priority == false)
                {
                    temp += post + "\n";
                }
            }

            return temp;
        }

        /// <summary>
        /// Retreives all the posts in the system.
        /// </summary>
        /// <returns>Returns a string of all the posts in the system.</returns>
        /// <remarks>
        /// The posts are sorted by priority.
        /// </remarks>
        public string ViewAllMyReceivedMessages()
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("messages") ?? throw new Exception($"Table '{"messages"}' not found.");

            // retreive all messages that were directed to this user from message table and store them in a string
            foreach (object? row in table.Rows.Values)
            {
                msg? message = (msg)row;
                if (message.Receiver == Username)
                {
                    temp += message + "\n";
                }
            }

            return temp;
        }

        /// <summary>
        /// Retreives all the posts in the system.
        /// </summary>
        /// <returns>Returns a string of all the posts in the system.</returns>
        /// <remarks>
        /// The posts are sorted by priority.
        /// </remarks>
        public string ViewAllMyLastUpdatedWall()
        {
            string? temp = "";
            database? db = database.Instance;
            Table? table = db.GetTable("posts") ?? throw new Exception($"Table '{"posts"}' not found.");

            // chech if the user has any friends
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
                        temp += post + "\n";
                        break;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Retreives all the posts in the system.
        /// </summary>
        /// <returns>Returns a string of all the posts in the system.</returns>
        /// <remarks>
        /// The posts are sorted by priority.
        /// </remarks>
        public string FilterMyWall(string filter)
        {
            // same as ViewAllMyLastUpdatedWall but with a filter
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
                    if (post.Author == friend.Username && filter == post.Category) // <-- this is the filter 
                    {
                        temp += post + "\n";
                        break;
                    }
                }
            }

            return temp;
        }

        /// <summary>
        /// Retreives all the posts in the system.
        /// </summary>
        /// <returns>Returns a string of all the posts in the system.</returns>
        /// <remarks>
        /// The posts are sorted by priority.
        /// </remarks>
        public bool SendReportToAdministrator(string username, string content)
        {
            if (username == null || content == null)
            {
                return false;
            }

            // save report to database
            database.Instance.Add("reports", new rep(Username, username, content)); // this.Username -> reporter, content -> reports
            return true;
        }
    }
}
