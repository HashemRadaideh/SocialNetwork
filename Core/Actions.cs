namespace Core
{
    [Serializable]
    public class Post
    {
        public string Username { get; set; } = "";
        public string Content { get; set; } = "";
        public string Category { get; set; } = "";

        public Post(string username, string content, string category)
        {
            this.Username = username;
            this.Content = content;
            this.Category = category;
        }
    }

    [Serializable]
    public class Message
    {
        public string sender { get; set; } = "";
        public string reciever { get; set; } = "";
        public string text { get; set; } = "";
        public string subject { get; set; } = "";
        public string priority { get; set; } = "";
    }

    [Serializable]
    public class Report
    {
        public string reporter { get; set; } = "";
        public string reported { get; set; } = "";
    }
}
