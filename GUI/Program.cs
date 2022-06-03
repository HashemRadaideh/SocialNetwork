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

            if (args.Length > 0)
            {
                if (args[0] == "--help")
                {
                    Console.WriteLine($"Help menu:");
                    Console.WriteLine($"  [--cmd]/[-c] : Start termininal session");
                    Console.WriteLine($"  [--gui]/[-g] : Start gui session");
                    db.Save();
                    return 0;
                }
                else if (args[0] == "--cmd")
                {
                    SocialNetwork.Program.Main();
                    db.Save();
                    return 0;
                }
                else
                {
                    Console.WriteLine("Invalid argument: " + args[0]);
                    Console.WriteLine("Usage: GUI.exe [--help]");
                    db.Save();
                    return 1;
                }
            }
            else
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UserLogin());
                db.Save();
                return 0;
            }
        }
    }
}