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

        public override string ToString()
        {
            return $"{Username} - {Content} - {Category}";
        }
    }

    [Serializable]
    public class Message
    {
        public string Sender { get; set; } = "";
        public string Reciever { get; set; } = "";
        public string Text { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Priority { get; set; } = "";

        public override string ToString()
        {
            return $"{this.Sender} - {this.Reciever} - {this.Text} - {this.Subject} - {this.Priority}";
        }
    }

    [Serializable]
    public class Report
    {
        public string Reporter { get; set; } = "";
        public string Reported { get; set; } = "";

        public override string ToString()
        {
            return $"{this.Reporter} - {this.Reported}";
        }
    }
}
