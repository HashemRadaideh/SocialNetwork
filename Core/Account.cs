/// <summary>
/// Account type implementation as the project description states.
/// </summary>
namespace Core
{
    [Serializable]
    internal class Administrator
    {
        public string Username = "admin";
        public int Password = 0;

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
    internal class User
    {
        public string Username;
        public int Password;
        public string Status;
        public string FirstName;
        public string LastName;
        public string Location;
        public int Age;
        public List<string> Friends;

        public User(string username, int password, string status, string firstName, string lastName, string location, int age, List<string> friends)
        {
            Username = username;
            Password = password;
            Status = status;
            FirstName = firstName;
            LastName = lastName;
            Location = location;
            Age = age;
            Friends = friends;
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
    }
}
