namespace GUI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            var db = Database.Database.Instance;
            // db.LoadDatabase();
            db.CreateNewTable("users");
            db.CreateNewTable("reports");
            db.CreateNewTable("posts");
            db.CreateNewTable("messages");

            var acc1 = new Account.User("HashemWasTaken", "0", true, "Hashem", "Al_Radaideh", "Irbid", 20);
            var acc2 = new Account.User("HashemIsTaken", "1", true, "Hashem", "Al_Radaideh", "Irbid", 20, new List<Account.User>() { acc1 });
            var acc3 = new Account.User("HashemTaken", "h", true, "Hashem", "Al_Radaideh", "Irbid", 20, new List<Account.User>() { acc1, acc2 });
            var acc4 = new Account.User("Hashem", "h", true, "Hashem", "Al_Radaideh", "Irbid", 20);
            var acc5 = new Account.User("Hashem", "h", true, "Hashem", "Al_Radaideh", "Irbid", 20, new List<Account.User>() { acc1, acc2, acc3 });

            db.Add("users", acc1);
            db.Add("users", acc2);
            db.Add("users", acc3);
            db.Add("users", acc4);
            db.Add("users", acc5);

            if (args.Length > 0)
            {
                if (args[0] == "--help")
                {
                    Console.WriteLine($"Help menu:");
                    Console.WriteLine($"  [--cmd]/[-c] : Start termininal session");
                    Console.WriteLine($"  [--gui]/[-g] : Start gui session");
                    return 0;
                }
                else if (args[0] == "--cmd")
                {
                    SocialNetwork.Program.Main(args);
                    return 0;
                }
                else
                {
                    Console.WriteLine("Invalid argument: " + args[0]);
                    Console.WriteLine("Usage: GUI.exe [--help]");
                    return 1;
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginWindow());
                return 0;
            }
        }
    }
}