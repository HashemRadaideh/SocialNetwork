namespace Actions
{
    [Serializable]
    public class Report
    {
        private string reported = "";
        private string reporter = "";
        private string reason = "";

        public Report(string reporter, string reported, string reason)
        {
            this.reporter = reporter;
            this.reported = reported;
            this.reason = reason;
        }

        public string Reported { get => reported; set => reported = value; }
        public string Reporter { get => reporter; set => reporter = value; }
        public string Reason { get => reason; set => reason = value; }

        public override string ToString()
        {
            return $"Reporter: {reporter}\nReported: {reported}\nReason: {reason}";
        }
    }

    [Serializable]
    public class Post
    {
        private string content = "";
        private string author = "";
        private string category = "";
        private bool priority = false;

        public Post(string username, string content, bool priority, string category)
        {
            this.author = username;
            this.content = content;
            this.priority = priority;
            this.category = category;
        }

        public string Content { get => content; set => content = value; }
        public string Author { get => author; set => author = value; }
        public string Category { get => category; set => category = value; }

        public override string ToString()
        {
            return $"Username: {author}\nCategory: {category}\nPriority: {priority}\nContent:{content}";
        }
    }

    [Serializable]
    public class Message
    {
        private string sender = "";
        private string reciever = "";
        private string content = "";

        public Message(string sender, string reciever, string content)
        {
            this.sender = sender;
            this.reciever = reciever;
            this.content = content;
        }

        public string Sender { get => sender; set => sender = value; }
        public string Receiver { get => reciever; set => reciever = value; }
        public string Content { get => content; set => content = value; }
        public override string ToString()
        {
            return $"from: {sender}\nTo: {reciever}\nContent:{content}";
        }
    }
}
