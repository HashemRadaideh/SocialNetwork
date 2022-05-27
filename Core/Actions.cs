namespace Core
{
    [Serializable]
    internal class Post
    {
        private string Username;
        private string Content;
        private string Category;

        public Post(string username, string content, string category)
        {
            Username = username;
            Content = content;
            Category = category;
        }
    }

    [Serializable]
    internal class Message
    {
        private string sender;
        private string reciever;
        private string text;
        string subject;
        char priority;
    }

    [Serializable]
    internal class Report
    {
        private string reporter;
        private string reported;
    }
}
