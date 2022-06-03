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
            this.ComboCategory = new System.Windows.Forms.ComboBox();
            this.ComboPriority = new System.Windows.Forms.ComboBox();
            this.FieldContent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ButtonCreatePost = new System.Windows.Forms.Button();
            this.PanelSendMessage = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ButtonSearchReciever = new System.Windows.Forms.Button();
            this.ButtonCreateMessage = new System.Windows.Forms.Button();
            this.FieldBody = new System.Windows.Forms.TextBox();
            this.FieldMessageUsername = new System.Windows.Forms.TextBox();
            this.PanelMyPosts = new System.Windows.Forms.Panel();
            this.ListMyPosts = new System.Windows.Forms.ListView();
            this.ColumnUsername = new System.Windows.Forms.ColumnHeader();
            this.ColumnContent = new System.Windows.Forms.ColumnHeader();
            this.PanelMyMessages = new System.Windows.Forms.Panel();
            this.ListMyMessages = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.PanelHome = new System.Windows.Forms.Panel();
            this.ListHomeFeed = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.PanelHomeFiltered = new System.Windows.Forms.Panel();
            this.ListHomeFiltered = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.ComboCategorySearch = new System.Windows.Forms.ComboBox();
            this.ButtonFilterHome = new System.Windows.Forms.Button();
            this.PanelSendReport = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FieldReason = new System.Windows.Forms.TextBox();
            this.FieldReported = new System.Windows.Forms.TextBox();
            this.SearchReported = new System.Windows.Forms.Button();
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
            this.PanelCreatePost.Controls.Add(this.ComboCategory);
            this.PanelCreatePost.Controls.Add(this.ComboPriority);
            this.PanelCreatePost.Controls.Add(this.FieldContent);
            this.PanelCreatePost.Controls.Add(this.label4);
            this.PanelCreatePost.Controls.Add(this.label6);
            this.PanelCreatePost.Controls.Add(this.label5);
            this.PanelCreatePost.Controls.Add(this.label3);
            this.PanelCreatePost.Controls.Add(this.ButtonCreatePost);
            this.PanelCreatePost.Location = new System.Drawing.Point(215, 34);
            this.PanelCreatePost.Name = "PanelCreatePost";
            this.PanelCreatePost.Size = new System.Drawing.Size(626, 431);
            this.PanelCreatePost.TabIndex = 9;
            this.PanelCreatePost.Visible = false;
            // 
            // ComboCategory
            // 
            this.ComboCategory.FormattingEnabled = true;
            this.ComboCategory.Items.AddRange(new object[] {
            "News",
            "Sports",
            "TV"});
            this.ComboCategory.Location = new System.Drawing.Point(116, 22);
            this.ComboCategory.Name = "ComboCategory";
            this.ComboCategory.Size = new System.Drawing.Size(167, 23);
            this.ComboCategory.TabIndex = 11;
            // 
            // ComboPriority
            // 
            this.ComboPriority.FormattingEnabled = true;
            this.ComboPriority.Items.AddRange(new object[] {
            "High",
            "Low"});
            this.ComboPriority.Location = new System.Drawing.Point(116, 51);
            this.ComboPriority.Name = "ComboPriority";
            this.ComboPriority.Size = new System.Drawing.Size(167, 23);
            this.ComboPriority.TabIndex = 11;
            // 
            // FieldContent
            // 
            this.FieldContent.Location = new System.Drawing.Point(116, 79);
            this.FieldContent.Multiline = true;
            this.FieldContent.Name = "FieldContent";
            this.FieldContent.Size = new System.Drawing.Size(167, 89);
            this.FieldContent.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(37, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Category";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(37, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Content";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(37, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Priority";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(20, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 21);
            this.label3.TabIndex = 0;
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
            this.ButtonCreatePost.Click += new System.EventHandler(this.ButtonCreatePost_Click);
            // 
            // PanelSendMessage
            // 
            this.PanelSendMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSendMessage.Controls.Add(this.label9);
            this.PanelSendMessage.Controls.Add(this.label8);
            this.PanelSendMessage.Controls.Add(this.ButtonSearchReciever);
            this.PanelSendMessage.Controls.Add(this.ButtonCreateMessage);
            this.PanelSendMessage.Controls.Add(this.FieldBody);
            this.PanelSendMessage.Controls.Add(this.FieldMessageUsername);
            this.PanelSendMessage.Location = new System.Drawing.Point(215, 34);
            this.PanelSendMessage.Name = "PanelSendMessage";
            this.PanelSendMessage.Size = new System.Drawing.Size(626, 431);
            this.PanelSendMessage.TabIndex = 10;
            this.PanelSendMessage.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(20, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "Body";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(20, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 21);
            this.label8.TabIndex = 1;
            this.label8.Text = "Username";
            // 
            // ButtonSearchReciever
            // 
            this.ButtonSearchReciever.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearchReciever.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonSearchReciever.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSearchReciever.ForeColor = System.Drawing.Color.White;
            this.ButtonSearchReciever.Location = new System.Drawing.Point(434, 20);
            this.ButtonSearchReciever.Name = "ButtonSearchReciever";
            this.ButtonSearchReciever.Size = new System.Drawing.Size(175, 23);
            this.ButtonSearchReciever.TabIndex = 10;
            this.ButtonSearchReciever.Text = "Search";
            this.ButtonSearchReciever.UseVisualStyleBackColor = false;
            this.ButtonSearchReciever.Click += new System.EventHandler(this.ButtonSearchReciever_Click);
            // 
            // ButtonCreateMessage
            // 
            this.ButtonCreateMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonCreateMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonCreateMessage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonCreateMessage.ForeColor = System.Drawing.Color.White;
            this.ButtonCreateMessage.Location = new System.Drawing.Point(434, 391);
            this.ButtonCreateMessage.Name = "ButtonCreateMessage";
            this.ButtonCreateMessage.Size = new System.Drawing.Size(175, 23);
            this.ButtonCreateMessage.TabIndex = 10;
            this.ButtonCreateMessage.Text = "Log out";
            this.ButtonCreateMessage.UseVisualStyleBackColor = false;
            this.ButtonCreateMessage.Click += new System.EventHandler(this.ButtonCreateMessage_Click);
            // 
            // FieldBody
            // 
            this.FieldBody.Location = new System.Drawing.Point(111, 49);
            this.FieldBody.Multiline = true;
            this.FieldBody.Name = "FieldBody";
            this.FieldBody.Size = new System.Drawing.Size(183, 88);
            this.FieldBody.TabIndex = 0;
            // 
            // FieldMessageUsername
            // 
            this.FieldMessageUsername.Location = new System.Drawing.Point(111, 20);
            this.FieldMessageUsername.Name = "FieldMessageUsername";
            this.FieldMessageUsername.Size = new System.Drawing.Size(183, 23);
            this.FieldMessageUsername.TabIndex = 0;
            // 
            // PanelMyPosts
            // 
            this.PanelMyPosts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelMyPosts.Controls.Add(this.ListMyPosts);
            this.PanelMyPosts.Location = new System.Drawing.Point(215, 34);
            this.PanelMyPosts.Name = "PanelMyPosts";
            this.PanelMyPosts.Size = new System.Drawing.Size(626, 431);
            this.PanelMyPosts.TabIndex = 11;
            this.PanelMyPosts.Visible = false;
            // 
            // ListMyPosts
            // 
            this.ListMyPosts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnUsername,
            this.ColumnContent});
            this.ListMyPosts.FullRowSelect = true;
            this.ListMyPosts.GridLines = true;
            this.ListMyPosts.Location = new System.Drawing.Point(20, 20);
            this.ListMyPosts.Name = "ListMyPosts";
            this.ListMyPosts.Size = new System.Drawing.Size(579, 394);
            this.ListMyPosts.TabIndex = 0;
            this.ListMyPosts.UseCompatibleStateImageBehavior = false;
            this.ListMyPosts.View = System.Windows.Forms.View.Details;
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.Text = "Username";
            this.ColumnUsername.Width = 100;
            // 
            // ColumnContent
            // 
            this.ColumnContent.Text = "Content";
            this.ColumnContent.Width = 200;
            // 
            // PanelMyMessages
            // 
            this.PanelMyMessages.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelMyMessages.Controls.Add(this.ListMyMessages);
            this.PanelMyMessages.Location = new System.Drawing.Point(215, 34);
            this.PanelMyMessages.Name = "PanelMyMessages";
            this.PanelMyMessages.Size = new System.Drawing.Size(625, 431);
            this.PanelMyMessages.TabIndex = 12;
            this.PanelMyMessages.Visible = false;
            // 
            // ListMyMessages
            // 
            this.ListMyMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.ListMyMessages.FullRowSelect = true;
            this.ListMyMessages.GridLines = true;
            this.ListMyMessages.Location = new System.Drawing.Point(20, 20);
            this.ListMyMessages.Name = "ListMyMessages";
            this.ListMyMessages.Size = new System.Drawing.Size(579, 394);
            this.ListMyMessages.TabIndex = 0;
            this.ListMyMessages.UseCompatibleStateImageBehavior = false;
            this.ListMyMessages.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Sender";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Content";
            this.columnHeader4.Width = 100;
            // 
            // PanelHome
            // 
            this.PanelHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelHome.Controls.Add(this.ListHomeFeed);
            this.PanelHome.Location = new System.Drawing.Point(215, 34);
            this.PanelHome.Name = "PanelHome";
            this.PanelHome.Size = new System.Drawing.Size(626, 431);
            this.PanelHome.TabIndex = 13;
            this.PanelHome.Visible = false;
            // 
            // ListHomeFeed
            // 
            this.ListHomeFeed.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader9,
            this.columnHeader10});
            this.ListHomeFeed.FullRowSelect = true;
            this.ListHomeFeed.GridLines = true;
            this.ListHomeFeed.Location = new System.Drawing.Point(20, 20);
            this.ListHomeFeed.Name = "ListHomeFeed";
            this.ListHomeFeed.Size = new System.Drawing.Size(579, 394);
            this.ListHomeFeed.TabIndex = 0;
            this.ListHomeFeed.UseCompatibleStateImageBehavior = false;
            this.ListHomeFeed.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Category";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Priority";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Content";
            this.columnHeader10.Width = 100;
            // 
            // PanelHomeFiltered
            // 
            this.PanelHomeFiltered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelHomeFiltered.Controls.Add(this.ListHomeFiltered);
            this.PanelHomeFiltered.Controls.Add(this.label7);
            this.PanelHomeFiltered.Controls.Add(this.ComboCategorySearch);
            this.PanelHomeFiltered.Controls.Add(this.ButtonFilterHome);
            this.PanelHomeFiltered.Location = new System.Drawing.Point(215, 34);
            this.PanelHomeFiltered.Name = "PanelHomeFiltered";
            this.PanelHomeFiltered.Size = new System.Drawing.Size(626, 431);
            this.PanelHomeFiltered.TabIndex = 14;
            this.PanelHomeFiltered.Visible = false;
            // 
            // ListHomeFiltered
            // 
            this.ListHomeFiltered.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader8,
            this.columnHeader6,
            this.columnHeader7});
            this.ListHomeFiltered.FullRowSelect = true;
            this.ListHomeFiltered.GridLines = true;
            this.ListHomeFiltered.Location = new System.Drawing.Point(108, 88);
            this.ListHomeFiltered.Name = "ListHomeFiltered";
            this.ListHomeFiltered.Size = new System.Drawing.Size(501, 283);
            this.ListHomeFiltered.TabIndex = 14;
            this.ListHomeFiltered.UseCompatibleStateImageBehavior = false;
            this.ListHomeFiltered.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Username";
            // 
            // columnHeader8
            // 
            this.columnHeader8.DisplayIndex = 3;
            this.columnHeader8.Text = "Category";
            // 
            // columnHeader6
            // 
            this.columnHeader6.DisplayIndex = 1;
            this.columnHeader6.Text = "Priority";
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 2;
            this.columnHeader7.Text = "Content";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(20, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "Category";
            // 
            // ComboCategorySearch
            // 
            this.ComboCategorySearch.FormattingEnabled = true;
            this.ComboCategorySearch.Items.AddRange(new object[] {
            "News",
            "Sports",
            "TV"});
            this.ComboCategorySearch.Location = new System.Drawing.Point(108, 31);
            this.ComboCategorySearch.Name = "ComboCategorySearch";
            this.ComboCategorySearch.Size = new System.Drawing.Size(141, 23);
            this.ComboCategorySearch.TabIndex = 12;
            // 
            // ButtonFilterHome
            // 
            this.ButtonFilterHome.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonFilterHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonFilterHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonFilterHome.ForeColor = System.Drawing.Color.White;
            this.ButtonFilterHome.Location = new System.Drawing.Point(434, 31);
            this.ButtonFilterHome.Name = "ButtonFilterHome";
            this.ButtonFilterHome.Size = new System.Drawing.Size(175, 23);
            this.ButtonFilterHome.TabIndex = 10;
            this.ButtonFilterHome.Text = "Search";
            this.ButtonFilterHome.UseVisualStyleBackColor = false;
            this.ButtonFilterHome.Click += new System.EventHandler(this.ButtonFilterHome_Click);
            // 
            // PanelSendReport
            // 
            this.PanelSendReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSendReport.Controls.Add(this.label2);
            this.PanelSendReport.Controls.Add(this.label1);
            this.PanelSendReport.Controls.Add(this.FieldReason);
            this.PanelSendReport.Controls.Add(this.FieldReported);
            this.PanelSendReport.Controls.Add(this.SearchReported);
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
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 11;
            this.label2.Text = "Reason";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Username";
            // 
            // FieldReason
            // 
            this.FieldReason.Location = new System.Drawing.Point(111, 59);
            this.FieldReason.Multiline = true;
            this.FieldReason.Name = "FieldReason";
            this.FieldReason.Size = new System.Drawing.Size(196, 137);
            this.FieldReason.TabIndex = 2;
            // 
            // FieldReported
            // 
            this.FieldReported.Location = new System.Drawing.Point(111, 29);
            this.FieldReported.Name = "FieldReported";
            this.FieldReported.Size = new System.Drawing.Size(196, 23);
            this.FieldReported.TabIndex = 1;
            // 
            // SearchReported
            // 
            this.SearchReported.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchReported.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.SearchReported.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchReported.ForeColor = System.Drawing.Color.White;
            this.SearchReported.Location = new System.Drawing.Point(434, 27);
            this.SearchReported.Name = "SearchReported";
            this.SearchReported.Size = new System.Drawing.Size(175, 23);
            this.SearchReported.TabIndex = 10;
            this.SearchReported.Text = "Search";
            this.SearchReported.UseVisualStyleBackColor = false;
            this.SearchReported.Click += new System.EventHandler(this.SearchReported_Click);
            // 
            // ButtonReport
            // 
            this.ButtonReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonReport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonReport.ForeColor = System.Drawing.Color.White;
            this.ButtonReport.Location = new System.Drawing.Point(434, 391);
            this.ButtonReport.Name = "ButtonReport";
            this.ButtonReport.Size = new System.Drawing.Size(175, 23);
            this.ButtonReport.TabIndex = 10;
            this.ButtonReport.Text = "Send report";
            this.ButtonReport.UseVisualStyleBackColor = false;
            this.ButtonReport.Click += new System.EventHandler(this.ButtonReport_Click);
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
            this.Controls.Add(this.PanelHomeFiltered);
            this.Controls.Add(this.PanelHome);
            this.Controls.Add(this.PanelMyMessages);
            this.Controls.Add(this.PanelMyPosts);
            this.Controls.Add(this.PanelSendMessage);
            this.Controls.Add(this.PanelCreatePost);
            this.Controls.Add(this.PanelSendReport);
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
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox FieldReason;
        private TextBox FieldReported;
        private Button SearchReported;
        private Button ButtonReport;
        private ComboBox ComboPriority;
        private TextBox FieldContent;
        private Label label6;
        private Label label5;
        private Button ButtonCreatePost;
        private Label label9;
        private Label label8;
        private Button ButtonCreateMessage;
        private TextBox FieldBody;
        private TextBox FieldMessageUsername;
        private ListView ListMyPosts;
        private ListView ListMyMessages;
        private ListView ListHomeFeed;
        private ListView ListHomeFiltered;
        private Label label7;
        private ComboBox ComboCategorySearch;
        private Button ButtonFilterHome;
        private ColumnHeader ColumnUsername;
        private ColumnHeader ColumnContent;
        private Button ButtonSearchReciever;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ComboBox ComboCategory;
        private Label label4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
    }
}