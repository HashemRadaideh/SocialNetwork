namespace GUI
{
    partial class UserMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for window resizeing and moving.
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Exit = new System.Windows.Forms.Button();
            this.Maximize = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.WindowTitle = new System.Windows.Forms.Label();
            this.MenuStrip = new System.Windows.Forms.Panel();
            this.SideBar = new System.Windows.Forms.Panel();
            this.ButtonMyMessages = new System.Windows.Forms.Button();
            this.ButtonSendMessage = new System.Windows.Forms.Button();
            this.ButtonSendReport = new System.Windows.Forms.Button();
            this.ButtonCreateNewPost = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.ButtonFilteredHome = new System.Windows.Forms.Button();
            this.ButtonViewAllMyPosts = new System.Windows.Forms.Button();
            this.ButtonHome = new System.Windows.Forms.Button();
            this.PanelCreatePost = new System.Windows.Forms.Panel();
            this.PanelSendMessage = new System.Windows.Forms.Panel();
            this.PanelMyPosts = new System.Windows.Forms.Panel();
            this.PanelMyMessages = new System.Windows.Forms.Panel();
            this.PanelHome = new System.Windows.Forms.Panel();
            this.PanelHomeFiltered = new System.Windows.Forms.Panel();
            this.PanelSendReport = new System.Windows.Forms.Panel();
            this.MenuStrip.SuspendLayout();
            this.SideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.Image = global::GUI.Properties.Resources.window_close;
            this.Exit.Location = new System.Drawing.Point(830, -1);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(23, 23);
            this.Exit.TabIndex = 1;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Maximize
            // 
            this.Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Maximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Maximize.Location = new System.Drawing.Point(801, -1);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(23, 23);
            this.Maximize.TabIndex = 2;
            this.Maximize.UseVisualStyleBackColor = false;
            this.Maximize.Click += new System.EventHandler(this.Maximize_Click);
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Minimize.Image = global::GUI.Properties.Resources.window_minimize;
            this.Minimize.Location = new System.Drawing.Point(772, -1);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(23, 23);
            this.Minimize.TabIndex = 3;
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // WindowTitle
            // 
            this.WindowTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.WindowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.WindowTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WindowTitle.ForeColor = System.Drawing.Color.White;
            this.WindowTitle.Location = new System.Drawing.Point(361, 2);
            this.WindowTitle.Margin = new System.Windows.Forms.Padding(3);
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.Size = new System.Drawing.Size(115, 21);
            this.WindowTitle.TabIndex = 4;
            this.WindowTitle.Text = "Social Network";
            this.WindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.MenuStrip.Controls.Add(this.Exit);
            this.MenuStrip.Controls.Add(this.Minimize);
            this.MenuStrip.Controls.Add(this.Maximize);
            this.MenuStrip.Location = new System.Drawing.Point(0, 1);
            this.MenuStrip.MinimumSize = new System.Drawing.Size(100, 27);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(853, 27);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            this.MenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseMove);
            // 
            // SideBar
            // 
            this.SideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.SideBar.Controls.Add(this.ButtonMyMessages);
            this.SideBar.Controls.Add(this.ButtonSendMessage);
            this.SideBar.Controls.Add(this.ButtonSendReport);
            this.SideBar.Controls.Add(this.ButtonCreateNewPost);
            this.SideBar.Controls.Add(this.LogOut);
            this.SideBar.Controls.Add(this.ButtonFilteredHome);
            this.SideBar.Controls.Add(this.ButtonViewAllMyPosts);
            this.SideBar.Controls.Add(this.ButtonHome);
            this.SideBar.Location = new System.Drawing.Point(1, 27);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(198, 452);
            this.SideBar.TabIndex = 8;
            // 
            // ButtonMyMessages
            // 
            this.ButtonMyMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonMyMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonMyMessages.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonMyMessages.ForeColor = System.Drawing.Color.White;
            this.ButtonMyMessages.Location = new System.Drawing.Point(12, 94);
            this.ButtonMyMessages.Name = "ButtonMyMessages";
            this.ButtonMyMessages.Size = new System.Drawing.Size(175, 23);
            this.ButtonMyMessages.TabIndex = 10;
            this.ButtonMyMessages.Text = "My messages";
            this.ButtonMyMessages.UseVisualStyleBackColor = false;
            this.ButtonMyMessages.Click += new System.EventHandler(this.ButtonMyMessages_Click);
            // 
            // ButtonSendMessage
            // 
            this.ButtonSendMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSendMessage.ForeColor = System.Drawing.Color.White;
            this.ButtonSendMessage.Location = new System.Drawing.Point(12, 36);
            this.ButtonSendMessage.Name = "ButtonSendMessage";
            this.ButtonSendMessage.Size = new System.Drawing.Size(175, 23);
            this.ButtonSendMessage.TabIndex = 10;
            this.ButtonSendMessage.Text = "Send a message";
            this.ButtonSendMessage.UseVisualStyleBackColor = false;
            this.ButtonSendMessage.Click += new System.EventHandler(this.ButtonSendMessage_Click);
            // 
            // ButtonSendReport
            // 
            this.ButtonSendReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSendReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonSendReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSendReport.ForeColor = System.Drawing.Color.White;
            this.ButtonSendReport.Location = new System.Drawing.Point(12, 389);
            this.ButtonSendReport.Name = "ButtonSendReport";
            this.ButtonSendReport.Size = new System.Drawing.Size(175, 23);
            this.ButtonSendReport.TabIndex = 10;
            this.ButtonSendReport.Text = "Report";
            this.ButtonSendReport.UseVisualStyleBackColor = false;
            this.ButtonSendReport.Click += new System.EventHandler(this.ButtonSendReport_Click);
            // 
            // ButtonCreateNewPost
            // 
            this.ButtonCreateNewPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreateNewPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonCreateNewPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonCreateNewPost.ForeColor = System.Drawing.Color.White;
            this.ButtonCreateNewPost.Location = new System.Drawing.Point(12, 7);
            this.ButtonCreateNewPost.Name = "ButtonCreateNewPost";
            this.ButtonCreateNewPost.Size = new System.Drawing.Size(175, 23);
            this.ButtonCreateNewPost.TabIndex = 10;
            this.ButtonCreateNewPost.Text = "Create new post";
            this.ButtonCreateNewPost.UseVisualStyleBackColor = false;
            this.ButtonCreateNewPost.Click += new System.EventHandler(this.ButtonCreateNewPost_Click);
            // 
            // LogOut
            // 
            this.LogOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.LogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogOut.ForeColor = System.Drawing.Color.White;
            this.LogOut.Location = new System.Drawing.Point(12, 418);
            this.LogOut.Name = "LogOut";
            this.LogOut.Size = new System.Drawing.Size(175, 23);
            this.LogOut.TabIndex = 10;
            this.LogOut.Text = "Log out";
            this.LogOut.UseVisualStyleBackColor = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // ButtonFilteredHome
            // 
            this.ButtonFilteredHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFilteredHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonFilteredHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonFilteredHome.ForeColor = System.Drawing.Color.White;
            this.ButtonFilteredHome.Location = new System.Drawing.Point(12, 152);
            this.ButtonFilteredHome.Name = "ButtonFilteredHome";
            this.ButtonFilteredHome.Size = new System.Drawing.Size(175, 23);
            this.ButtonFilteredHome.TabIndex = 10;
            this.ButtonFilteredHome.Text = "Home filtered";
            this.ButtonFilteredHome.UseVisualStyleBackColor = false;
            this.ButtonFilteredHome.Click += new System.EventHandler(this.ButtonFilteredHome_Click);
            // 
            // ButtonViewAllMyPosts
            // 
            this.ButtonViewAllMyPosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonViewAllMyPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonViewAllMyPosts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonViewAllMyPosts.ForeColor = System.Drawing.Color.White;
            this.ButtonViewAllMyPosts.Location = new System.Drawing.Point(12, 65);
            this.ButtonViewAllMyPosts.Name = "ButtonViewAllMyPosts";
            this.ButtonViewAllMyPosts.Size = new System.Drawing.Size(175, 23);
            this.ButtonViewAllMyPosts.TabIndex = 10;
            this.ButtonViewAllMyPosts.Text = "My posts";
            this.ButtonViewAllMyPosts.UseVisualStyleBackColor = false;
            this.ButtonViewAllMyPosts.Click += new System.EventHandler(this.ButtonViewAllMyPosts_Click);
            // 
            // ButtonHome
            // 
            this.ButtonHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonHome.ForeColor = System.Drawing.Color.White;
            this.ButtonHome.Location = new System.Drawing.Point(11, 123);
            this.ButtonHome.Name = "ButtonHome";
            this.ButtonHome.Size = new System.Drawing.Size(175, 23);
            this.ButtonHome.TabIndex = 10;
            this.ButtonHome.Text = "Home";
            this.ButtonHome.UseVisualStyleBackColor = false;
            this.ButtonHome.Click += new System.EventHandler(this.ButtonHome_Click);
            // 
            // PanelCreatePost
            // 
            this.PanelCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelCreatePost.Location = new System.Drawing.Point(215, 34);
            this.PanelCreatePost.Name = "PanelCreatePost";
            this.PanelCreatePost.Size = new System.Drawing.Size(626, 431);
            this.PanelCreatePost.TabIndex = 9;
            this.PanelCreatePost.Visible = false;
            // 
            // PanelSendMessage
            // 
            this.PanelSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSendMessage.Location = new System.Drawing.Point(215, 34);
            this.PanelSendMessage.Name = "PanelSendMessage";
            this.PanelSendMessage.Size = new System.Drawing.Size(626, 431);
            this.PanelSendMessage.TabIndex = 10;
            this.PanelSendMessage.Visible = false;
            // 
            // PanelMyPosts
            // 
            this.PanelMyPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelMyPosts.Location = new System.Drawing.Point(215, 34);
            this.PanelMyPosts.Name = "PanelMyPosts";
            this.PanelMyPosts.Size = new System.Drawing.Size(626, 431);
            this.PanelMyPosts.TabIndex = 11;
            this.PanelMyPosts.Visible = false;
            // 
            // PanelMyMessages
            // 
            this.PanelMyMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelMyMessages.Location = new System.Drawing.Point(215, 34);
            this.PanelMyMessages.Name = "PanelMyMessages";
            this.PanelMyMessages.Size = new System.Drawing.Size(625, 431);
            this.PanelMyMessages.TabIndex = 12;
            this.PanelMyMessages.Visible = false;
            // 
            // PanelHome
            // 
            this.PanelHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelHome.Location = new System.Drawing.Point(215, 34);
            this.PanelHome.Name = "PanelHome";
            this.PanelHome.Size = new System.Drawing.Size(626, 431);
            this.PanelHome.TabIndex = 13;
            this.PanelHome.Visible = false;
            // 
            // PanelHomeFiltered
            // 
            this.PanelHomeFiltered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelHomeFiltered.Location = new System.Drawing.Point(215, 34);
            this.PanelHomeFiltered.Name = "PanelHomeFiltered";
            this.PanelHomeFiltered.Size = new System.Drawing.Size(626, 431);
            this.PanelHomeFiltered.TabIndex = 14;
            this.PanelHomeFiltered.Visible = false;
            // 
            // PanelSendReport
            // 
            this.PanelSendReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSendReport.Location = new System.Drawing.Point(215, 34);
            this.PanelSendReport.Name = "PanelSendReport";
            this.PanelSendReport.Size = new System.Drawing.Size(626, 431);
            this.PanelSendReport.TabIndex = 15;
            this.PanelSendReport.Visible = false;
            // 
            // UserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(853, 480);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.PanelSendReport);
            this.Controls.Add(this.PanelHomeFiltered);
            this.Controls.Add(this.PanelHome);
            this.Controls.Add(this.PanelMyMessages);
            this.Controls.Add(this.PanelMyPosts);
            this.Controls.Add(this.PanelSendMessage);
            this.Controls.Add(this.PanelCreatePost);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(340, 350);
            this.Name = "UserMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MenuStrip.ResumeLayout(false);
            this.SideBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button Exit;
        private Button Maximize;
        private Button Minimize;
        private Label WindowTitle;
        private Panel MenuStrip;
        private Panel SideBar;
        private Button LogOut;
        private Button ButtonMyMessages;
        private Button ButtonSendMessage;
        private Button ButtonSendReport;
        private Button ButtonFilteredHome;
        private Button ButtonHome;
        private Button ButtonViewAllMyPosts;
        private Button ButtonCreateNewPost;
        private Panel PanelCreatePost;
        private Panel PanelSendMessage;
        private Panel PanelMyPosts;
        private Panel PanelMyMessages;
        private Panel PanelHome;
        private Panel PanelHomeFiltered;
        private Panel PanelSendReport;
    }
}