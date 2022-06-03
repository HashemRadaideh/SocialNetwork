using Account;
using System.Runtime.InteropServices;

namespace GUI
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void MainWindow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        Point lastPoint;

        private void MenuStrip_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MenuStrip_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Database.Database.Instance.Save();
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
            var db = Database.Database.Instance;
            var user = db.Login(this.Address.Text, this.Password.Text);
            if (user is not null && user != Administrator.Instance)
            {
                CurrentUser = (User)user;
                this.Hide();
                var main = new UserMain();
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
            this.Hide();
            var adminLogin = new AdminLogin();
            adminLogin.Show();
        }
    }
}