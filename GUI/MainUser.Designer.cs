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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonCreatePost = new System.Windows.Forms.Button();
            this.PanelSendMessage = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.PanelMyPosts = new System.Windows.Forms.Panel();
            this.listView4 = new System.Windows.Forms.ListView();
            this.PanelMyMessages = new System.Windows.Forms.Panel();
            this.listView3 = new System.Windows.Forms.ListView();
            this.PanelHome = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.PanelHomeFiltered = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.PanelSendReport = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.ButtonReport = new System.Windows.Forms.Button();
            this.MenuStrip.SuspendLayout();
            this.SideBar.SuspendLayout();
            this.PanelCreatePost.SuspendLayout();
            this.PanelSendMessage.SuspendLayout();
            this.PanelMyPosts.SuspendLayout();
            this.PanelMyMessages.SuspendLayout();
            this.PanelHome.SuspendLayout();
            this.PanelHomeFiltered.SuspendLayout();
            this.PanelSendReport.SuspendLayout();
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
            this.PanelCreatePost.Controls.Add(this.comboBox1);
            this.PanelCreatePost.Controls.Add(this.textBox5);
            this.PanelCreatePost.Controls.Add(this.textBox4);
            this.PanelCreatePost.Controls.Add(this.label6);
            this.PanelCreatePost.Controls.Add(this.label5);
            this.PanelCreatePost.Controls.Add(this.label4);
            this.PanelCreatePost.Controls.Add(this.textBox3);
            this.PanelCreatePost.Controls.Add(this.label3);
            this.PanelCreatePost.Controls.Add(this.ButtonCreatePost);
            this.PanelCreatePost.Location = new System.Drawing.Point(215, 34);
            this.PanelCreatePost.Name = "PanelCreatePost";
            this.PanelCreatePost.Size = new System.Drawing.Size(626, 431);
            this.PanelCreatePost.TabIndex = 9;
            this.PanelCreatePost.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(94, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 11;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(94, 116);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(167, 89);
            this.textBox5.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(94, 58);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 23);
            this.textBox4.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(20, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "label3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(20, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(20, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "label3";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(94, 29);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 23);
            this.textBox3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "label3";
            // 
            // ButtonCreatePost
            // 
            this.ButtonCreatePost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreatePost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonCreatePost.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonCreatePost.ForeColor = System.Drawing.Color.White;
            this.ButtonCreatePost.Location = new System.Drawing.Point(434, 391);
            this.ButtonCreatePost.Name = "ButtonCreatePost";
            this.ButtonCreatePost.Size = new System.Drawing.Size(175, 23);
            this.ButtonCreatePost.TabIndex = 10;
            this.ButtonCreatePost.Text = "Create";
            this.ButtonCreatePost.UseVisualStyleBackColor = false;
            this.ButtonCreatePost.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // PanelSendMessage
            // 
            this.PanelSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSendMessage.Controls.Add(this.label11);
            this.PanelSendMessage.Controls.Add(this.label10);
            this.PanelSendMessage.Controls.Add(this.label9);
            this.PanelSendMessage.Controls.Add(this.label8);
            this.PanelSendMessage.Controls.Add(this.button4);
            this.PanelSendMessage.Controls.Add(this.textBox10);
            this.PanelSendMessage.Controls.Add(this.textBox9);
            this.PanelSendMessage.Controls.Add(this.textBox8);
            this.PanelSendMessage.Controls.Add(this.textBox7);
            this.PanelSendMessage.Location = new System.Drawing.Point(215, 34);
            this.PanelSendMessage.Name = "PanelSendMessage";
            this.PanelSendMessage.Size = new System.Drawing.Size(626, 431);
            this.PanelSendMessage.TabIndex = 10;
            this.PanelSendMessage.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(20, 107);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 21);
            this.label11.TabIndex = 1;
            this.label11.Text = "label8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(20, 78);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 21);
            this.label10.TabIndex = 1;
            this.label10.Text = "label8";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(20, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "label8";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(20, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "label8";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(434, 391);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Log out";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(111, 107);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 23);
            this.textBox10.TabIndex = 0;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(111, 78);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 23);
            this.textBox9.TabIndex = 0;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(111, 49);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 23);
            this.textBox8.TabIndex = 0;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(111, 20);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(100, 23);
            this.textBox7.TabIndex = 0;
            // 
            // PanelMyPosts
            // 
            this.PanelMyPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelMyPosts.Controls.Add(this.listView4);
            this.PanelMyPosts.Location = new System.Drawing.Point(215, 34);
            this.PanelMyPosts.Name = "PanelMyPosts";
            this.PanelMyPosts.Size = new System.Drawing.Size(626, 431);
            this.PanelMyPosts.TabIndex = 11;
            this.PanelMyPosts.Visible = false;
            // 
            // listView4
            // 
            this.listView4.Location = new System.Drawing.Point(32, 33);
            this.listView4.Name = "listView4";
            this.listView4.Size = new System.Drawing.Size(548, 372);
            this.listView4.TabIndex = 0;
            this.listView4.UseCompatibleStateImageBehavior = false;
            // 
            // PanelMyMessages
            // 
            this.PanelMyMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelMyMessages.Controls.Add(this.listView3);
            this.PanelMyMessages.Location = new System.Drawing.Point(215, 34);
            this.PanelMyMessages.Name = "PanelMyMessages";
            this.PanelMyMessages.Size = new System.Drawing.Size(625, 431);
            this.PanelMyMessages.TabIndex = 12;
            this.PanelMyMessages.Visible = false;
            // 
            // listView3
            // 
            this.listView3.Location = new System.Drawing.Point(28, 24);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(552, 385);
            this.listView3.TabIndex = 0;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // PanelHome
            // 
            this.PanelHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelHome.Controls.Add(this.listView2);
            this.PanelHome.Location = new System.Drawing.Point(215, 34);
            this.PanelHome.Name = "PanelHome";
            this.PanelHome.Size = new System.Drawing.Size(626, 431);
            this.PanelHome.TabIndex = 13;
            this.PanelHome.Visible = false;
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(20, 20);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(579, 389);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // PanelHomeFiltered
            // 
            this.PanelHomeFiltered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelHomeFiltered.Controls.Add(this.listView1);
            this.PanelHomeFiltered.Controls.Add(this.label7);
            this.PanelHomeFiltered.Controls.Add(this.comboBox2);
            this.PanelHomeFiltered.Controls.Add(this.textBox6);
            this.PanelHomeFiltered.Controls.Add(this.button3);
            this.PanelHomeFiltered.Location = new System.Drawing.Point(215, 34);
            this.PanelHomeFiltered.Name = "PanelHomeFiltered";
            this.PanelHomeFiltered.Size = new System.Drawing.Size(626, 431);
            this.PanelHomeFiltered.TabIndex = 14;
            this.PanelHomeFiltered.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(78, 88);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(350, 283);
            this.listView1.TabIndex = 14;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "label7";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(78, 26);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 23);
            this.comboBox2.TabIndex = 12;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(328, 28);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 23);
            this.textBox6.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(434, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // PanelSendReport
            // 
            this.PanelSendReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSendReport.Controls.Add(this.label2);
            this.PanelSendReport.Controls.Add(this.label1);
            this.PanelSendReport.Controls.Add(this.textBox2);
            this.PanelSendReport.Controls.Add(this.textBox1);
            this.PanelSendReport.Controls.Add(this.button2);
            this.PanelSendReport.Controls.Add(this.ButtonReport);
            this.PanelSendReport.Location = new System.Drawing.Point(215, 34);
            this.PanelSendReport.Name = "PanelSendReport";
            this.PanelSendReport.Size = new System.Drawing.Size(626, 431);
            this.PanelSendReport.TabIndex = 15;
            this.PanelSendReport.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(20, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(111, 59);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 23);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(111, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(434, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // ButtonReport
            // 
            this.ButtonReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonReport.ForeColor = System.Drawing.Color.White;
            this.ButtonReport.Location = new System.Drawing.Point(434, 382);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Size = new System.Drawing.Size(175, 23);
            this.ButtonReport.TabIndex = 10;
            this.ButtonReport.Text = "Send report";
            this.ButtonReport.UseVisualStyleBackColor = false;
            this.ButtonReport.Click += new System.EventHandler(this.LogOut_Click);
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
            this.Controls.Add(this.PanelCreatePost);
            this.Controls.Add(this.PanelSendReport);
            this.Controls.Add(this.PanelHomeFiltered);
            this.Controls.Add(this.PanelHome);
            this.Controls.Add(this.PanelMyMessages);
            this.Controls.Add(this.PanelMyPosts);
            this.Controls.Add(this.PanelSendMessage);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(340, 350);
            this.Name = "UserMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MenuStrip.ResumeLayout(false);
            this.SideBar.ResumeLayout(false);
            this.PanelCreatePost.ResumeLayout(false);
            this.PanelCreatePost.PerformLayout();
            this.PanelSendMessage.ResumeLayout(false);
            this.PanelSendMessage.PerformLayout();
            this.PanelMyPosts.ResumeLayout(false);
            this.PanelMyMessages.ResumeLayout(false);
            this.PanelHome.ResumeLayout(false);
            this.PanelHomeFiltered.ResumeLayout(false);
            this.PanelHomeFiltered.PerformLayout();
            this.PanelSendReport.ResumeLayout(false);
            this.PanelSendReport.PerformLayout();
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
        private TextBox textBox3;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
        private Button ButtonReport;
        private ComboBox comboBox1;
        private TextBox textBox5;
        private TextBox textBox4;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button ButtonCreatePost;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Button button4;
        private TextBox textBox10;
        private TextBox textBox9;
        private TextBox textBox8;
        private TextBox textBox7;
        private ListView listView4;
        private ListView listView3;
        private ListView listView2;
        private ListView listView1;
        private Label label7;
        private ComboBox comboBox2;
        private TextBox textBox6;
        private Button button3;
    }
}