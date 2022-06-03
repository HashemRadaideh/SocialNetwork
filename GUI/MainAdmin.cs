using Core;

namespace GUI
{
    public partial class AdminMain : Form
    {
        public AdminMain()
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
            Hide();
            UserLogin? login = new();
            login.Show();
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

        private void RegisterUser_Click(object sender, EventArgs e)
        {
            string? users_names = FieldFriends.Text;
            List<User>? friends = new();
            Database? db = Database.Instance;

            Table? table = db.GetTable("users") ?? throw new Exception("Table does not exist");
            foreach (string? username in users_names.Split(" "))
            {
                foreach (object? user in table.Rows.Values)
                {
                    User? u = (User)user;
                    if (u.Username == username)
                    {
                        friends.Add(u);
                    }
                }
            }

            Administrator.RegisterNewUserAccount(
                FieldUsername.Text, FieldPassword.Text,
                FieldFirstName.Text, FieldLastName.Text,
                FieldLocation.Text, Convert.ToInt32(FieldAge.Text),
                friends
                );
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

            string? users_accounts = Administrator.ViewAllUserAccounts();
            string[]? temp = users_accounts.Split("\n");
            for (int i = 0; i < (temp.Length / 8); i++)
            {
                ListViewItem item = new(temp[(i * 8) + 0].Split(":")[1]);
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

        private bool isFoundSuspend = false;

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            Table? table = Database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            User? user = null;
            foreach (object? row in table.Rows.Values)
            {
                User? u = (User)row;
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

            if (user is null)
            {
                MessageBox.Show("User not found");
                return;
            }

            string[]? temp = (user + "").Split("\n");
            ListViewItem item = new(temp[0].Split(":")[1]);
            item.SubItems.Add(temp[1].Split(":")[1]);
            item.SubItems.Add(temp[2].Split(":")[1]);
            item.SubItems.Add(temp[3].Split(":")[1]);
            item.SubItems.Add(temp[4].Split(":")[1]);
            item.SubItems.Add(temp[5].Split(":")[1]);
            item.SubItems.Add(temp[6].Split(":")[1]);
            item.SubItems.Add(temp[7].Split(":")[1]);
            ListSuspendInfo.Items.Add(item);

            Table? table_report = Database.Instance.GetTable("reports") ?? throw new Exception($"Table '{"reports"}' not found.");

            while (ListReports.Items.Count > 0)
            {
                ListReports.Items.RemoveAt(0);
            }

            foreach (object? rep in table_report.Rows.Values)
            {
                Report? report = (Report)rep;
                if (report.Reported == user.Username)
                {
                    string[]? temps = (report + "").Split("\n");
                    ListViewItem items = new(temps[0].Split(":")[1]);
                    items.SubItems.Add(temps[1].Split(":")[1]);
                    items.SubItems.Add(temps[2].Split(":")[1]);
                    ListReports.Items.Add(items);
                }
            }
        }

        private void ButtonSuspendUser_Click(object sender, EventArgs e)
        {
            if (FieldSearch.Text == "")
            {
                MessageBox.Show("Please enter a username");
                return;
            }

            if (isFoundSuspend)
            {
                bool status = Administrator.SuspendUserAccount(FieldSearch.Text);
                if (status)
                {
                    MessageBox.Show("User suspended");
                }
                else
                {
                    MessageBox.Show("User not suspended");
                }
            }
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

        private bool isFoundActivate = false;

        private void ButtonSearch2_Click(object sender, EventArgs e)
        {
            Table? table = Database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            User? user = null;
            foreach (object? row in table.Rows.Values)
            {
                User? u = (User)row;
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
                string[]? temp = (user + "").Split("\n");
                ListViewItem item = new(temp[0].Split(":")[1]);
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
            }
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
                var status = Administrator.ActivateUserAccount(FieldUsernameActivate.Text);
                if (status)
                {
                    MessageBox.Show("User activated");
                }
                else
                {
                    MessageBox.Show("User not activated");
                }
            }
        }
    }
}
