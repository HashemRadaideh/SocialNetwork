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
                    Core.Program.Main(args);
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
                Application.Run(new MainWindow());
                return 0;
            }
        }
    }
}