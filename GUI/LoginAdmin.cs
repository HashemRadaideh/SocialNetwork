using System.Runtime.InteropServices;

namespace GUI
{
    public partial class AdminLogin : Form
    {
        Account.Administrator? admin;

        public AdminLogin()
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

        private void MenuStrip_MouseDown_1(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void MenuStrip_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MenuStrip_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void MenuStrip_MouseDown(object sender, MouseEventArgs e)
        {
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Database.Database.Instance.Save();
            Application.Exit();
        }

        private static bool MAXIMIZED = false;

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

        private void SignUp_Click(object sender, EventArgs e)
        {

        }

        private void WindowTitle_Click(object sender, EventArgs e)
        {

        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            var db = Database.Database.Instance;
            var temp = db.Login(this.Address.Text, this.Password.Text);
            if (temp is not null)
            {
                admin = (Account.Administrator)temp;
                var main = new AdminMain();
                main.Show();
            }
            else
            {
                MessageBox.Show("Incorrect admin credentials");
            }
        }
    }
}