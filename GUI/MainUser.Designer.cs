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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.CreateNewPost = new System.Windows.Forms.Button();
            this.LogOut = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ViewAllMyPosts = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.SideBar.Controls.Add(this.button7);
            this.SideBar.Controls.Add(this.button6);
            this.SideBar.Controls.Add(this.button5);
            this.SideBar.Controls.Add(this.CreateNewPost);
            this.SideBar.Controls.Add(this.LogOut);
            this.SideBar.Controls.Add(this.button4);
            this.SideBar.Controls.Add(this.ViewAllMyPosts);
            this.SideBar.Controls.Add(this.button3);
            this.SideBar.Location = new System.Drawing.Point(1, 27);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(198, 452);
            this.SideBar.TabIndex = 8;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button7.ForeColor = System.Drawing.Color.White;
            this.button7.Location = new System.Drawing.Point(12, 94);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(175, 23);
            this.button7.TabIndex = 10;
            this.button7.Text = "My messages";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.ForeColor = System.Drawing.Color.White;
            this.button6.Location = new System.Drawing.Point(12, 36);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(175, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Send a message";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(12, 389);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(175, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "Report";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // CreateNewPost
            // 
            this.CreateNewPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateNewPost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.CreateNewPost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CreateNewPost.ForeColor = System.Drawing.Color.White;
            this.CreateNewPost.Location = new System.Drawing.Point(12, 7);
            this.CreateNewPost.Name = "CreateNewPost";
            this.CreateNewPost.Size = new System.Drawing.Size(175, 23);
            this.CreateNewPost.TabIndex = 10;
            this.CreateNewPost.Text = "Create new post";
            this.CreateNewPost.UseVisualStyleBackColor = false;
            this.CreateNewPost.Click += new System.EventHandler(this.LogOut_Click);
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
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(12, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Home filtered";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // ViewAllMyPosts
            // 
            this.ViewAllMyPosts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewAllMyPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ViewAllMyPosts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewAllMyPosts.ForeColor = System.Drawing.Color.White;
            this.ViewAllMyPosts.Location = new System.Drawing.Point(12, 65);
            this.ViewAllMyPosts.Name = "ViewAllMyPosts";
            this.ViewAllMyPosts.Size = new System.Drawing.Size(175, 23);
            this.ViewAllMyPosts.TabIndex = 10;
            this.ViewAllMyPosts.Text = "My posts";
            this.ViewAllMyPosts.UseVisualStyleBackColor = false;
            this.ViewAllMyPosts.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(11, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Home";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.LogOut_Click);
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
        private Button button7;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button ViewAllMyPosts;
        private Button CreateNewPost;
    }
}