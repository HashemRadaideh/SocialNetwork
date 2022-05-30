/// <summary>
/// Account type implementation as the project description states.
/// </summary>
namespace Core
{
    [Serializable]
    public class Administrator
    {
        public string Username { get; set; } = "admin";
        public int Password { get; set; } = 0;

        public void RegisterNewUserAccount()
        {
            // TODO: Register new user account
            throw new NotImplementedException();
        }

        public void ViewAllUserAccounts()
        {
            // TODO: View all user accounts
            throw new NotImplementedException();
        }

        private bool IsSuspendable(string username)
        {
            // NOTE: dependency of SuspendUserAccount() method
            throw new NotImplementedException();
        }

        public void SuspendUserAccount()
        {
            // TODO: Suspend user account
            throw new NotImplementedException();
        }

        public void ActivateUserAccount()
        {
            // TODO: Activate user account
            throw new NotImplementedException();
        }
    }

    [Serializable]
    public class User
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Status { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Location { get; set; } = "";
        public int Age { get; set; } = 0;
        public List<User> Friends { get; set; }

        public User(string username, string password, string status, string firstName, string lastName, string location, int age, List<User> friends)
        {
            this.Username = username;
            this.Password = password;
            this.Status = status;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Location = location;
            this.Age = age;
            this.Friends = friends;
        }

        public void PostNewContent()
        {
            // TODO: Post new content
            throw new NotImplementedException();
        }

        public void SendMessage()
        {
            // TODO: Send message
            throw new NotImplementedException();
        }

        public void ViewAllMyPosts()
        {
            // TODO: View all my posts
            throw new NotImplementedException();
        }

        public void ViewAllMyReceivedMessages()
        {
            // TODO: View all my received messages
            throw new NotImplementedException();
        }

        public void ViewAllMyLastUpdatedWall()
        {
            // TODO: View all my last updated wall
            throw new NotImplementedException();
        }

        public void FilterMyWall()
        {
            // TODO: Filter my wall
            throw new NotImplementedException();
        }

        public void SendReportToAdministrator()
        {
            // TODO: Send report to administrator
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            var names = "No friends were found";
            if (this.Friends.Count() > 0)
            {
                names = "";
            }

            foreach (var friend in this.Friends)
            {
                names += friend.Username + " ";
            }

            return $"Username: {this.Username}\nPassword: {this.Password}\nStatus: {this.Status}\nFirstName: {this.FirstName}\nLastName: {this.LastName}\nLocation: {this.Location}\nAge: {this.Age}\nFriends: {names}";
        }
    }
}
