using System.Runtime.InteropServices;

namespace GUI
{
    public partial class UserMain : Form
    {
        Account.User? CurrentUser = UserLogin.CurrentUser;

        public UserMain()
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

        private void ButtonCreateNewPost_Click(object sender, EventArgs e)
        {
            if (!PanelCreatePost.Visible)
            {
                PanelCreatePost.Visible = true;
                PanelCreatePost.BringToFront();
            }
            else
            {
                PanelCreatePost.Visible = false;
            }

            PanelSendMessage.Visible = false;
            PanelMyPosts.Visible = false;
            PanelMyMessages.Visible = false;
            PanelHome.Visible = false;
            PanelHomeFiltered.Visible = false;
            PanelSendReport.Visible = false;
        }

        private void ButtonSendMessage_Click(object sender, EventArgs e)
        {
            if (!PanelSendMessage.Visible)
            {
                PanelSendMessage.Visible = true;
                PanelSendMessage.BringToFront();
            }
            else
            {
                PanelSendMessage.Visible = false;
            }

            PanelCreatePost.Visible = false;
            PanelMyPosts.Visible = false;
            PanelMyMessages.Visible = false;
            PanelHome.Visible = false;
            PanelHomeFiltered.Visible = false;
            PanelSendReport.Visible = false;
        }

        private void ButtonViewAllMyPosts_Click(object sender, EventArgs e)
        {
            if (!PanelMyPosts.Visible)
            {
                PanelMyPosts.Visible = true;
                PanelMyPosts.BringToFront();
            }
            else
            {
                PanelMyPosts.Visible = false;
            }

            PanelCreatePost.Visible = false;
            PanelSendMessage.Visible = false;
            PanelMyMessages.Visible = false;
            PanelHome.Visible = false;
            PanelHomeFiltered.Visible = false;
            PanelSendReport.Visible = false;

            while (ListMyPosts.Items.Count > 1)
            {
                ListMyPosts.Items.RemoveAt(1);
            }

            var _ = CurrentUser ?? throw new Exception("User not found");
            var posts = CurrentUser.ViewAllMyPosts();
            var temp = posts.Split("\n");

            ListViewItem i = new ListViewItem(temp[0]);
            ListMyPosts.Items.Add(i);
            i.SubItems.Add(temp[1]);
        }

        private void ButtonMyMessages_Click(object sender, EventArgs e)
        {
            if (!PanelMyMessages.Visible)
            {
                PanelMyMessages.Visible = true;
                PanelMyMessages.BringToFront();
            }
            else
            {
                PanelMyMessages.Visible = false;
            }

            PanelCreatePost.Visible = false;
            PanelSendMessage.Visible = false;
            PanelMyPosts.Visible = false;
            PanelHome.Visible = false;
            PanelHomeFiltered.Visible = false;
            PanelSendReport.Visible = false;

            while (ListMyMessages.Items.Count > 1)
            {
                ListMyMessages.Items.RemoveAt(1);
            }

            var _ = CurrentUser ?? throw new Exception("User not found");
            var posts = CurrentUser.ViewAllMyReceivedMessages();
            var temp = posts.Split("\n");

            ListViewItem i = new ListViewItem(temp[0]);
            ListMyMessages.Items.Add(i);
            //i.SubItems.Add(temp[1]);
        }

        private void ButtonHome_Click(object sender, EventArgs e)
        {
            if (!PanelHome.Visible)
            {
                PanelHome.Visible = true;
                PanelHome.BringToFront();
            }
            else
            {
                PanelHome.Visible = false;
            }

            PanelCreatePost.Visible = false;
            PanelSendMessage.Visible = false;
            PanelMyPosts.Visible = false;
            PanelMyMessages.Visible = false;
            PanelHomeFiltered.Visible = false;
            PanelSendReport.Visible = false;

            while (ListHomeFeed.Items.Count > 1)
            {
                ListHomeFeed.Items.RemoveAt(1);
            }

            var _ = CurrentUser ?? throw new Exception("User not found");
            var posts = CurrentUser.ViewAllMyLastUpdatedWall();
            var temp = posts.Split("\n");

            for (int i = 0; i < (temp.Length / 4); i++)
            {
                ListViewItem item = new ListViewItem(temp[(i * 4) + 0].Split(":")[1]);
                item.SubItems.Add(temp[(i * 4) + 1].Split(":")[1]);
                item.SubItems.Add(temp[(i * 4) + 2].Split(":")[1]);
                item.SubItems.Add(temp[(i * 4) + 3].Split(":")[1]);
                ListHomeFeed.Items.Add(item);
            }
        }

        private void ButtonFilteredHome_Click(object sender, EventArgs e)
        {
            if (!PanelHomeFiltered.Visible)
            {
                PanelHomeFiltered.Visible = true;
                PanelHomeFiltered.BringToFront();
            }
            else
            {
                PanelHomeFiltered.Visible = false;
            }

            PanelCreatePost.Visible = false;
            PanelSendMessage.Visible = false;
            PanelMyPosts.Visible = false;
            PanelMyMessages.Visible = false;
            PanelHome.Visible = false;
            PanelSendReport.Visible = false;
        }

        private void ButtonSendReport_Click(object sender, EventArgs e)
        {
            if (!PanelSendReport.Visible)
            {
                PanelSendReport.Visible = true;
                PanelSendReport.BringToFront();
            }
            else
            {
                PanelSendReport.Visible = false;
            }

            PanelCreatePost.Visible = false;
            PanelSendMessage.Visible = false;
            PanelMyPosts.Visible = false;
            PanelMyMessages.Visible = false;
            PanelHome.Visible = false;
            PanelHomeFiltered.Visible = false;
        }

        private void ButtonCreatePost_Click(object sender, EventArgs e)
        {
            var _ = CurrentUser ?? throw new Exception("Current user is null");
            bool priority = ComboPriority.Text == "High" ? true : false;
            Database.Database.Instance.Add(
                "posts",
                new Actions.Post(this.CurrentUser.Username, FieldContent.Text, priority, ComboCategory.Text)
                ); // this.Username -> Poster's username, content -> content
        }

        private bool isRecieverFound = false;

        private void ButtonSearchReciever_Click(object sender, EventArgs e)
        {
            var table = Database.Database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var u = (Account.User)row;
                if (u.Username == FieldMessageUsername.Text)
                {
                    isRecieverFound = true;
                }
            }
            isRecieverFound = false;
        }

        private void ButtonCreateMessage_Click(object sender, EventArgs e)
        {
            var _ = CurrentUser ?? throw new Exception("Current user is null");
            if (isRecieverFound)
            {
                Database.Database.Instance.Add(
                    "messages",
                    new Actions.Message(this.CurrentUser.Username, FieldMessageUsername.Text, FieldBody.Text)
                    ); // this.Username -> sender, username -> receiver, body -> message
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private static bool isReported = false;
        private void SearchReported_Click(object sender, EventArgs e)
        {
            var table = Database.Database.Instance.GetTable("users") ?? throw new Exception($"Table '{"users"}' not found.");
            foreach (var row in table.Rows.Values)
            {
                var u = (Account.User)row;
                if (u.Username == FieldMessageUsername.Text)
                {
                    isReported = true;
                }
            }
            isReported = false;
        }

        private void ButtonReport_Click(object sender, EventArgs e)
        {
            var _ = CurrentUser ?? throw new Exception("Current user is null");
            if (isReported)
            {
                var db = Database.Database.Instance;
                var reporter = db.IndexOf("users", this.CurrentUser.Username);
                var reported = db.IndexOf("users", FieldReported.Text);

                db.Add("reports", new Actions.Report(
                    reporter,
                    reported,
                    FieldReason.Text
                    )); // this.Username -> reporter, content -> reports
            }
            else
            {
                MessageBox.Show("User not found");
            }
        }

        private void ButtonFilterHome_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ComboCategorySearch.Text))
            {
                MessageBox.Show("Please enter a category");
            }
            else
            {
                while (ListHomeFiltered.Items.Count > 1)
                {
                    ListHomeFiltered.Items.RemoveAt(1);
                }

                var _ = CurrentUser ?? throw new Exception("User not found");
                var posts = CurrentUser.FilterMyWall(ComboCategorySearch.Text);
                var temp = posts.Split("\n");

                for (int i = 0; i < (temp.Length / 4); i++)
                {
                    ListViewItem item = new ListViewItem(temp[(i * 4) + 0].Split(":")[1]);
                    item.SubItems.Add(temp[(i * 4) + 1].Split(":")[1]);
                    item.SubItems.Add(temp[(i * 4) + 2].Split(":")[1]);
                    item.SubItems.Add(temp[(i * 4) + 3].Split(":")[1]);
                    ListHomeFiltered.Items.Add(item);
                }
            }
        }
    }
}