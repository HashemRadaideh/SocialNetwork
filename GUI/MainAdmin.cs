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


            while (ListUsers.Items.Count > 0)
            {
                //leave the header
                ListUsers.Items.RemoveAt(0);
            }

            var users_accounts = Account.Administrator.Instance.ViewAllUserAccounts();
            var temp = users_accounts.Split("\n");
            for (int i = 0; i < (temp.Length / 8); i++)
            {
                ListViewItem item = new ListViewItem(temp[(i * 8) + 0].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 1].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 2].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 3].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 4].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 5].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 6].Split(":")[1]);
                item.SubItems.Add(temp[(i * 8) + 7].Split(":")[1]);
                ListUsers.Items.Add(item);
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

        private void ButtonActivate_Click(object sender, EventArgs e)
        {
            if (FieldUsernameActivate.Text == "")
            {
                MessageBox.Show("Please enter a username.");
                return;
            }
            if (isFoundActivate)
            {
                MessageBox.Show("User activated.");
                Account.Administrator.Instance.ActivateUserAccount(FieldUsernameActivate.Text);
            }
        }

        private bool isFoundActivate = false;

        private void ButtonSearch2_Click(object sender, EventArgs e)
        {
            var table = Database.Database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            Account.User? user = null;
            foreach (var row in table.Rows.Values)
            {
                var u = (Account.User)row;
                if (u.Username == FieldUsernameActivate.Text)
                {
                    user = u;
                    isFoundActivate = true;
                }
            }

            while (ListActivate.Items.Count > 0)
            {
                ListActivate.Items.RemoveAt(0);
            }

            if (user is not null)
            {
                var temp = (user + "").Split("\n");
                ListViewItem item = new ListViewItem(temp[0].Split(":")[1]);
                item.SubItems.Add(temp[1].Split(":")[1]);
                item.SubItems.Add(temp[2].Split(":")[1]);
                item.SubItems.Add(temp[3].Split(":")[1]);
                item.SubItems.Add(temp[4].Split(":")[1]);
                item.SubItems.Add(temp[5].Split(":")[1]);
                item.SubItems.Add(temp[6].Split(":")[1]);
                item.SubItems.Add(temp[7].Split(":")[1]);
                ListActivate.Items.Add(item);
            }
            else
            {
                MessageBox.Show("User not found");
                //FieldUsernameActivate.Text = "User not found";
            }
        }

        private bool isFoundSuspend = false;

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            var table = Database.Database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            Account.User? user = null;
            foreach (var row in table.Rows.Values)
            {
                var u = (Account.User)row;
                if (u.Username == FieldSearch.Text)
                {
                    user = u;
                    isFoundSuspend = true;
                }
            }

            while (ListSuspendInfo.Items.Count > 0)
            {
                ListSuspendInfo.Items.RemoveAt(0);
            }

            if (user is not null)
            {
                var temp = (user + "").Split("\n");
                ListViewItem item = new ListViewItem(temp[0].Split(":")[1]);
                item.SubItems.Add(temp[1].Split(":")[1]);
                item.SubItems.Add(temp[2].Split(":")[1]);
                item.SubItems.Add(temp[3].Split(":")[1]);
                item.SubItems.Add(temp[4].Split(":")[1]);
                item.SubItems.Add(temp[5].Split(":")[1]);
                item.SubItems.Add(temp[6].Split(":")[1]);
                item.SubItems.Add(temp[7].Split(":")[1]);
                ListSuspendInfo.Items.Add(item);
            }
            else
            {
                MessageBox.Show("User not found");
                //FieldUsernameActivate.Text = "User not found";
            }
        }

        private void ButtonSuspendUser_Click(object sender, EventArgs e)
        {
            if (FieldSearch.Text == "")
            {
                MessageBox.Show("Please enter a username");
                return;
            }

            var isSuspendable = false;
            if (isFoundSuspend)
            {
                isSuspendable = Account.Administrator.Instance.SuspendUserAccount(FieldSearch.Text);
            }

            if (isSuspendable)
            {
                MessageBox.Show("User suspended");
            }
            else
            {
                MessageBox.Show("User not suspended");
            }
        }
    }
}
