using System.Runtime.InteropServices;

namespace GUI
{
    public partial class UserMain : Form
    {
        Account.User? CurrentUser;

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
    }
}