using System.Runtime.InteropServices;

namespace GUI
{
    public partial class AdminMain : Form
    {
        public AdminMain()
        {
            InitializeComponent();
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

        private void LogOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new UserLogin();
            login.Show();
        }

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            var users_names = FieldFriends.Text;
            var friends = new List<Account.User>();
            var db = Database.Database.Instance;

            var table = db.GetTable("users") ?? throw new Exception("Table does not exist");
            foreach (var username in users_names.Split(" "))
            {
                foreach (var user in table.Rows.Values)
                {
                    var u = (Account.User)user;
                    if (u.Username == username)
                    {
                        friends.Add(u);
                    }
                }
            }

            Account.Administrator.Instance.RegisterNewUserAccount(
                FieldUsername.Text, FieldPassword.Text,
                FieldFirstName.Text, FieldLastName.Text,
                FieldLocation.Text, Convert.ToInt32(FieldAge.Text),
                friends
                );
        }

        private void RegisterNewUser_Click(object sender, EventArgs e)
        {
            if (!PanelRegister.Visible)
            {
                PanelRegister.Show();
            }
            else
            {
                PanelRegister.Hide();
            }

            PanelViewAllUsers.Hide();
            PanelSuspend.Hide();
            PanelActivate.Hide();
        }

        private void ViewAllUsers_Click(object sender, EventArgs e)
        {
            if (!PanelViewAllUsers.Visible)
            {
                PanelViewAllUsers.Show();
            }
            else
            {
                PanelViewAllUsers.Hide();
            }

            PanelRegister.Hide();
            PanelSuspend.Hide();
            PanelActivate.Hide();

            var users_accounts = Account.Administrator.Instance.ViewAllUserAccounts();
            var temp = users_accounts.Split("\n");
            foreach (var strs in temp)
            {
                ListViewItem i = new ListViewItem(strs.Split(" "));
                ListUsers.Items.Add(i);
            }
        }

        private void SuspendUser_Click(object sender, EventArgs e)
        {
            if (!PanelSuspend.Visible)
            {
                PanelSuspend.Show();
            }
            else
            {
                PanelSuspend.Hide();
            }

            PanelRegister.Hide();
            PanelViewAllUsers.Hide();
            PanelActivate.Hide();

        }

        private void ActivateUser_Click(object sender, EventArgs e)
        {
            if (!PanelActivate.Visible)
            {
                PanelActivate.Show();
            }
            else
            {
                PanelActivate.Hide();
            }

            PanelRegister.Hide();
            PanelViewAllUsers.Hide();
            PanelSuspend.Hide();
        }
    }
}
