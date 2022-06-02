namespace Actions
{
    [Serializable]
    public class Report
    {
        private int reported = 0;
        private int reporter = 0;
        private string reason = "";

        public Report(int reporter, int reported, string reason)
        {
            this.reporter = reporter;
            this.reported = reported;
            this.reason = reason;
        }

        public int Reported { get => reported; set => reported = value; }
        public int Reporter { get => reporter; set => reporter = value; }
        public string Reason { get => reason; set => reason = value; }
    }

    [Serializable]
    public class Post
    {
        private int author = 0;
        private string content = "";
        private string username;
        private bool priority = false;

        public Post(string username, string content, bool priority)
        {
            this.username = username;
            this.content = content;
            this.priority = priority;
        }

        public string Content { get => content; set => content = value; }
        public int Author { get => author; set => author = value; }

        public override string ToString()
        {
            return $"u/{username}:\n{content}";
        }
    }

    [Serializable]
    public class Message
    {
        private int sender = 0;
        private int receiver = 0;
        private string content = "";
        private string username1;
        private string username2;

        public Message(string username1, string username2, string content)
        {
            this.username1 = username1;
            this.username2 = username2;
            this.content = content;
        }

        public int Sender { get => sender; set => sender = value; }
        public int Receiver { get => receiver; set => receiver = value; }
        public string Content { get => content; set => content = value; }
        public override string ToString()
        {
            return $"from: {username1}\nTo: {username2}\nContent:{content}";
        }
    }
}
