using Core;

namespace GUI
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        //public const int WM_NCLBUTTONDOWN = 0xA1;
        //public const int HTCAPTION = 0x2;
        //[DllImport("User32.dll")]
        //public static extern bool ReleaseCapture();
        //[DllImport("User32.dll")]
        //public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            //    if (e.Button == MouseButtons.Left)
            //    {
            //        _ = ReleaseCapture();
            //        _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            //    }
        }

        private Point lastPoint;

        private void MenuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MenuStrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Database.Instance.Save();
            Application.Exit();
        }

        private static bool MAXIMIZED = false;

        public static User? CurrentUser { get; set; }

        private void Maximize_Click(object sender, EventArgs e)
        {
            if (MAXIMIZED)
            {
                WindowState = FormWindowState.Normal;
                MAXIMIZED = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                MAXIMIZED = true;
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            Database? db = Database.Instance;
            object? user = db.Login(Address.Text, Password.Text);
            if (user is not null && user != Administrator.Instance)
            {
                CurrentUser = (User)user;
                Hide();
                UserMain? main = new();
                main.Show();
            }
            else if (user == Administrator.Instance)
            {
                MessageBox.Show("Admin login detected, login from admin panel");
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            Hide();
            AdminLogin? adminLogin = new();
            adminLogin.Show();
        }
    }
}