namespace GUI
{
    partial class AdminMain
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
            this.LogOut = new System.Windows.Forms.Button();
            this.ActivateUser = new System.Windows.Forms.Button();
            this.SuspendUser = new System.Windows.Forms.Button();
            this.ViewAllUsers = new System.Windows.Forms.Button();
            this.RegisterNewUser = new System.Windows.Forms.Button();
            this.PanelRegister = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Friends = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.FirstName = new System.Windows.Forms.Label();
            this.RegisterUser = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.FieldFriends = new System.Windows.Forms.TextBox();
            this.FieldAge = new System.Windows.Forms.TextBox();
            this.FieldLocation = new System.Windows.Forms.TextBox();
            this.FieldLastName = new System.Windows.Forms.TextBox();
            this.FieldFirstName = new System.Windows.Forms.TextBox();
            this.FieldPassword = new System.Windows.Forms.TextBox();
            this.FieldUsername = new System.Windows.Forms.TextBox();
            this.PanelViewAllUsers = new System.Windows.Forms.Panel();
            this.ListUsers = new System.Windows.Forms.ListView();
            this.ColumnUsername = new System.Windows.Forms.ColumnHeader();
            this.ColumnPassword = new System.Windows.Forms.ColumnHeader();
            this.ColumnStatus = new System.Windows.Forms.ColumnHeader();
            this.ColumnFirstName = new System.Windows.Forms.ColumnHeader();
            this.ColumnLastName = new System.Windows.Forms.ColumnHeader();
            this.ColumnLocation = new System.Windows.Forms.ColumnHeader();
            this.ColumnAge = new System.Windows.Forms.ColumnHeader();
            this.ColumnFriends = new System.Windows.Forms.ColumnHeader();
            this.PanelSuspend = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ListReports = new System.Windows.Forms.ListView();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.ListSuspendInfo = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.ButtonSearch = new System.Windows.Forms.Button();
            this.ButtonSuspendUser = new System.Windows.Forms.Button();
            this.FieldSearch = new System.Windows.Forms.TextBox();
            this.PanelActivate = new System.Windows.Forms.Panel();
            this.ButtonSearch2 = new System.Windows.Forms.Button();
            this.ButtonActivate = new System.Windows.Forms.Button();
            this.ListActivate = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.FieldUsernameActivate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MenuStrip.SuspendLayout();
            this.SideBar.SuspendLayout();
            this.PanelRegister.SuspendLayout();
            this.PanelViewAllUsers.SuspendLayout();
            this.PanelSuspend.SuspendLayout();
            this.PanelActivate.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.Image = global::GUI.Properties.Resources.window_close;
            this.Exit.Location = new System.Drawing.Point(824, -3);
            this.Exit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(30, 30);
            this.Exit.TabIndex = 1;
            this.Exit.TabStop = false;
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Maximize
            // 
            this.Maximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Maximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Maximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Maximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Maximize.Location = new System.Drawing.Point(794, -3);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(30, 30);
            this.Maximize.TabIndex = 2;
            this.Maximize.TabStop = false;
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
            this.Minimize.Location = new System.Drawing.Point(764, -3);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(30, 30);
            this.Minimize.TabIndex = 3;
            this.Minimize.TabStop = false;
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
            this.MenuStrip.Location = new System.Drawing.Point(1, 1);
            this.MenuStrip.MinimumSize = new System.Drawing.Size(100, 27);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(851, 27);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            this.MenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseMove);
            // 
            // SideBar
            // 
            this.SideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.SideBar.Controls.Add(this.LogOut);
            this.SideBar.Controls.Add(this.ActivateUser);
            this.SideBar.Controls.Add(this.SuspendUser);
            this.SideBar.Controls.Add(this.ViewAllUsers);
            this.SideBar.Controls.Add(this.RegisterNewUser);
            this.SideBar.Location = new System.Drawing.Point(0, 27);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(198, 452);
            this.SideBar.TabIndex = 7;
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
            this.LogOut.TabIndex = 4;
            this.LogOut.Text = "Log out";
            this.LogOut.UseVisualStyleBackColor = false;
            this.LogOut.Click += new System.EventHandler(this.LogOut_Click);
            // 
            // ActivateUser
            // 
            this.ActivateUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ActivateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ActivateUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ActivateUser.ForeColor = System.Drawing.Color.White;
            this.ActivateUser.Location = new System.Drawing.Point(12, 94);
            this.ActivateUser.Name = "ActivateUser";
            this.ActivateUser.Size = new System.Drawing.Size(175, 23);
            this.ActivateUser.TabIndex = 3;
            this.ActivateUser.Text = "Activate user";
            this.ActivateUser.UseVisualStyleBackColor = false;
            this.ActivateUser.Click += new System.EventHandler(this.ActivateUser_Click);
            // 
            // SuspendUser
            // 
            this.SuspendUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SuspendUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.SuspendUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SuspendUser.ForeColor = System.Drawing.Color.White;
            this.SuspendUser.Location = new System.Drawing.Point(12, 65);
            this.SuspendUser.Name = "SuspendUser";
            this.SuspendUser.Size = new System.Drawing.Size(175, 23);
            this.SuspendUser.TabIndex = 2;
            this.SuspendUser.Text = "Suspend user";
            this.SuspendUser.UseVisualStyleBackColor = false;
            this.SuspendUser.Click += new System.EventHandler(this.SuspendUser_Click);
            // 
            // ViewAllUsers
            // 
            this.ViewAllUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewAllUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ViewAllUsers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewAllUsers.ForeColor = System.Drawing.Color.White;
            this.ViewAllUsers.Location = new System.Drawing.Point(12, 36);
            this.ViewAllUsers.Name = "ViewAllUsers";
            this.ViewAllUsers.Size = new System.Drawing.Size(175, 23);
            this.ViewAllUsers.TabIndex = 1;
            this.ViewAllUsers.Text = "View All Users";
            this.ViewAllUsers.UseVisualStyleBackColor = false;
            this.ViewAllUsers.Click += new System.EventHandler(this.ViewAllUsers_Click);
            // 
            // RegisterNewUser
            // 
            this.RegisterNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.RegisterNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterNewUser.ForeColor = System.Drawing.Color.White;
            this.RegisterNewUser.Location = new System.Drawing.Point(12, 7);
            this.RegisterNewUser.Name = "RegisterNewUser";
            this.RegisterNewUser.Size = new System.Drawing.Size(175, 23);
            this.RegisterNewUser.TabIndex = 0;
            this.RegisterNewUser.Text = "Register new user";
            this.RegisterNewUser.UseVisualStyleBackColor = false;
            this.RegisterNewUser.Click += new System.EventHandler(this.RegisterNewUser_Click);
            // 
            // PanelRegister
            // 
            this.PanelRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelRegister.Controls.Add(this.label2);
            this.PanelRegister.Controls.Add(this.Friends);
            this.PanelRegister.Controls.Add(this.LocationLabel);
            this.PanelRegister.Controls.Add(this.LastName);
            this.PanelRegister.Controls.Add(this.FirstName);
            this.PanelRegister.Controls.Add(this.RegisterUser);
            this.PanelRegister.Controls.Add(this.Password);
            this.PanelRegister.Controls.Add(this.Username);
            this.PanelRegister.Controls.Add(this.FieldFriends);
            this.PanelRegister.Controls.Add(this.FieldAge);
            this.PanelRegister.Controls.Add(this.FieldLocation);
            this.PanelRegister.Controls.Add(this.FieldLastName);
            this.PanelRegister.Controls.Add(this.FieldFirstName);
            this.PanelRegister.Controls.Add(this.FieldPassword);
            this.PanelRegister.Controls.Add(this.FieldUsername);
            this.PanelRegister.Location = new System.Drawing.Point(215, 34);
            this.PanelRegister.Name = "PanelRegister";
            this.PanelRegister.Size = new System.Drawing.Size(626, 434);
            this.PanelRegister.TabIndex = 8;
            this.PanelRegister.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 172);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Age";
            // 
            // Friends
            // 
            this.Friends.AutoSize = true;
            this.Friends.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Friends.Location = new System.Drawing.Point(22, 199);
            this.Friends.Name = "Friends";
            this.Friends.Size = new System.Drawing.Size(61, 21);
            this.Friends.TabIndex = 3;
            this.Friends.Text = "Friends";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LocationLabel.Location = new System.Drawing.Point(22, 141);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(69, 21);
            this.LocationLabel.TabIndex = 3;
            this.LocationLabel.Text = "Location";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LastName.Location = new System.Drawing.Point(22, 114);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(81, 21);
            this.LastName.TabIndex = 3;
            this.LastName.Text = "Last name";
            // 
            // FirstName
            // 
            this.FirstName.AutoSize = true;
            this.FirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FirstName.Location = new System.Drawing.Point(22, 85);
            this.FirstName.Name = "FirstName";
            this.FirstName.Size = new System.Drawing.Size(83, 21);
            this.FirstName.TabIndex = 3;
            this.FirstName.Text = "First name";
            // 
            // RegisterUser
            // 
            this.RegisterUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RegisterUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.RegisterUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegisterUser.ForeColor = System.Drawing.Color.White;
            this.RegisterUser.Location = new System.Drawing.Point(434, 391);
            this.RegisterUser.Name = "RegisterUser";
            this.RegisterUser.Size = new System.Drawing.Size(146, 23);
            this.RegisterUser.TabIndex = 7;
            this.RegisterUser.Text = "Register";
            this.RegisterUser.UseVisualStyleBackColor = false;
            this.RegisterUser.Click += new System.EventHandler(this.RegisterUser_Click);
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Password.Location = new System.Drawing.Point(22, 56);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(76, 21);
            this.Password.TabIndex = 3;
            this.Password.Text = "Password";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Username.Location = new System.Drawing.Point(22, 25);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(81, 21);
            this.Username.TabIndex = 3;
            this.Username.Text = "Username";
            // 
            // FieldFriends
            // 
            this.FieldFriends.Location = new System.Drawing.Point(115, 199);
            this.FieldFriends.Multiline = true;
            this.FieldFriends.Name = "FieldFriends";
            this.FieldFriends.Size = new System.Drawing.Size(284, 89);
            this.FieldFriends.TabIndex = 6;
            // 
            // FieldAge
            // 
            this.FieldAge.Location = new System.Drawing.Point(115, 170);
            this.FieldAge.Name = "FieldAge";
            this.FieldAge.Size = new System.Drawing.Size(284, 23);
            this.FieldAge.TabIndex = 5;
            // 
            // FieldLocation
            // 
            this.FieldLocation.Location = new System.Drawing.Point(115, 141);
            this.FieldLocation.Name = "FieldLocation";
            this.FieldLocation.Size = new System.Drawing.Size(284, 23);
            this.FieldLocation.TabIndex = 4;
            // 
            // FieldLastName
            // 
            this.FieldLastName.Location = new System.Drawing.Point(115, 112);
            this.FieldLastName.Name = "FieldLastName";
            this.FieldLastName.Size = new System.Drawing.Size(284, 23);
            this.FieldLastName.TabIndex = 3;
            // 
            // FieldFirstName
            // 
            this.FieldFirstName.Location = new System.Drawing.Point(115, 83);
            this.FieldFirstName.Name = "FieldFirstName";
            this.FieldFirstName.Size = new System.Drawing.Size(284, 23);
            this.FieldFirstName.TabIndex = 2;
            // 
            // FieldPassword
            // 
            this.FieldPassword.Location = new System.Drawing.Point(115, 54);
            this.FieldPassword.Name = "FieldPassword";
            this.FieldPassword.Size = new System.Drawing.Size(284, 23);
            this.FieldPassword.TabIndex = 1;
            // 
            // FieldUsername
            // 
            this.FieldUsername.Location = new System.Drawing.Point(115, 25);
            this.FieldUsername.Name = "FieldUsername";
            this.FieldUsername.Size = new System.Drawing.Size(284, 23);
            this.FieldUsername.TabIndex = 0;
            // 
            // PanelViewAllUsers
            // 
            this.PanelViewAllUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelViewAllUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelViewAllUsers.Controls.Add(this.ListUsers);
            this.PanelViewAllUsers.Location = new System.Drawing.Point(215, 34);
            this.PanelViewAllUsers.Name = "PanelViewAllUsers";
            this.PanelViewAllUsers.Size = new System.Drawing.Size(626, 431);
            this.PanelViewAllUsers.TabIndex = 10;
            this.PanelViewAllUsers.Visible = false;
            // 
            // ListUsers
            // 
            this.ListUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnUsername,
            this.ColumnPassword,
            this.ColumnStatus,
            this.ColumnFirstName,
            this.ColumnLastName,
            this.ColumnLocation,
            this.ColumnAge,
            this.ColumnFriends});
            this.ListUsers.FullRowSelect = true;
            this.ListUsers.GridLines = true;
            this.ListUsers.Location = new System.Drawing.Point(22, 12);
            this.ListUsers.Name = "ListUsers";
            this.ListUsers.Size = new System.Drawing.Size(575, 402);
            this.ListUsers.TabIndex = 0;
            this.ListUsers.UseCompatibleStateImageBehavior = false;
            this.ListUsers.View = System.Windows.Forms.View.Details;
            // 
            // ColumnUsername
            // 
            this.ColumnUsername.Text = "Username";
            this.ColumnUsername.Width = 70;
            // 
            // ColumnPassword
            // 
            this.ColumnPassword.Text = "Password";
            this.ColumnPassword.Width = 70;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.Text = "Status";
            this.ColumnStatus.Width = 50;
            // 
            // ColumnFirstName
            // 
            this.ColumnFirstName.Text = "First name";
            this.ColumnFirstName.Width = 70;
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.Text = "Last name";
            this.ColumnLastName.Width = 70;
            // 
            // ColumnLocation
            // 
            this.ColumnLocation.Text = "Location";
            this.ColumnLocation.Width = 70;
            // 
            // ColumnAge
            // 
            this.ColumnAge.Text = "Age";
            this.ColumnAge.Width = 40;
            // 
            // ColumnFriends
            // 
            this.ColumnFriends.Text = "Friends";
            this.ColumnFriends.Width = 100;
            // 
            // PanelSuspend
            // 
            this.PanelSuspend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelSuspend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelSuspend.Controls.Add(this.label4);
            this.PanelSuspend.Controls.Add(this.label3);
            this.PanelSuspend.Controls.Add(this.label1);
            this.PanelSuspend.Controls.Add(this.ListReports);
            this.PanelSuspend.Controls.Add(this.ListSuspendInfo);
            this.PanelSuspend.Controls.Add(this.ButtonSearch);
            this.PanelSuspend.Controls.Add(this.ButtonSuspendUser);
            this.PanelSuspend.Controls.Add(this.FieldSearch);
            this.PanelSuspend.Location = new System.Drawing.Point(215, 34);
            this.PanelSuspend.Name = "PanelSuspend";
            this.PanelSuspend.Size = new System.Drawing.Size(626, 431);
            this.PanelSuspend.TabIndex = 11;
            this.PanelSuspend.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(11, 252);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 21);
            this.label4.TabIndex = 12;
            this.label4.Text = "Reports";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(11, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(11, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Username";
            // 
            // ListReports
            // 
            this.ListReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListReports.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19});
            this.ListReports.FullRowSelect = true;
            this.ListReports.GridLines = true;
            this.ListReports.Location = new System.Drawing.Point(109, 252);
            this.ListReports.Name = "ListReports";
            this.ListReports.Size = new System.Drawing.Size(471, 121);
            this.ListReports.TabIndex = 10;
            this.ListReports.UseCompatibleStateImageBehavior = false;
            this.ListReports.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Reporter";
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Reported";
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Reason";
            // 
            // ListSuspendInfo
            // 
            this.ListSuspendInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListSuspendInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.ListSuspendInfo.FullRowSelect = true;
            this.ListSuspendInfo.GridLines = true;
            this.ListSuspendInfo.Location = new System.Drawing.Point(109, 99);
            this.ListSuspendInfo.Name = "ListSuspendInfo";
            this.ListSuspendInfo.Size = new System.Drawing.Size(471, 121);
            this.ListSuspendInfo.TabIndex = 10;
            this.ListSuspendInfo.UseCompatibleStateImageBehavior = false;
            this.ListSuspendInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Username";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Password";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Status";
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "First name";
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Last name";
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Location";
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Age";
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Friends";
            // 
            // ButtonSearch
            // 
            this.ButtonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSearch.ForeColor = System.Drawing.Color.White;
            this.ButtonSearch.Location = new System.Drawing.Point(434, 37);
            this.ButtonSearch.Name = "ButtonSearch";
            this.ButtonSearch.Size = new System.Drawing.Size(146, 23);
            this.ButtonSearch.TabIndex = 1;
            this.ButtonSearch.Text = "Search";
            this.ButtonSearch.UseVisualStyleBackColor = false;
            this.ButtonSearch.Click += new System.EventHandler(this.ButtonSearch_Click);
            // 
            // ButtonSuspendUser
            // 
            this.ButtonSuspendUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSuspendUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonSuspendUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSuspendUser.ForeColor = System.Drawing.Color.White;
            this.ButtonSuspendUser.Location = new System.Drawing.Point(434, 391);
            this.ButtonSuspendUser.Name = "ButtonSuspendUser";
            this.ButtonSuspendUser.Size = new System.Drawing.Size(146, 23);
            this.ButtonSuspendUser.TabIndex = 2;
            this.ButtonSuspendUser.Text = "Suspend";
            this.ButtonSuspendUser.UseVisualStyleBackColor = false;
            this.ButtonSuspendUser.Click += new System.EventHandler(this.ButtonSuspendUser_Click);
            // 
            // FieldSearch
            // 
            this.FieldSearch.Location = new System.Drawing.Point(109, 40);
            this.FieldSearch.Name = "FieldSearch";
            this.FieldSearch.Size = new System.Drawing.Size(247, 23);
            this.FieldSearch.TabIndex = 0;
            // 
            // PanelActivate
            // 
            this.PanelActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelActivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.PanelActivate.Controls.Add(this.ButtonSearch2);
            this.PanelActivate.Controls.Add(this.ButtonActivate);
            this.PanelActivate.Controls.Add(this.ListActivate);
            this.PanelActivate.Controls.Add(this.FieldUsernameActivate);
            this.PanelActivate.Controls.Add(this.label6);
            this.PanelActivate.Controls.Add(this.label5);
            this.PanelActivate.Location = new System.Drawing.Point(215, 34);
            this.PanelActivate.Name = "PanelActivate";
            this.PanelActivate.Size = new System.Drawing.Size(626, 431);
            this.PanelActivate.TabIndex = 12;
            this.PanelActivate.Visible = false;
            // 
            // ButtonSearch2
            // 
            this.ButtonSearch2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonSearch2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonSearch2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonSearch2.ForeColor = System.Drawing.Color.White;
            this.ButtonSearch2.Location = new System.Drawing.Point(434, 38);
            this.ButtonSearch2.Name = "ButtonSearch2";
            this.ButtonSearch2.Size = new System.Drawing.Size(146, 23);
            this.ButtonSearch2.TabIndex = 9;
            this.ButtonSearch2.Text = "Search";
            this.ButtonSearch2.UseVisualStyleBackColor = false;
            this.ButtonSearch2.Click += new System.EventHandler(this.ButtonSearch2_Click);
            // 
            // ButtonActivate
            // 
            this.ButtonActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonActivate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.ButtonActivate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ButtonActivate.ForeColor = System.Drawing.Color.White;
            this.ButtonActivate.Location = new System.Drawing.Point(434, 391);
            this.ButtonActivate.Name = "ButtonActivate";
            this.ButtonActivate.Size = new System.Drawing.Size(146, 23);
            this.ButtonActivate.TabIndex = 9;
            this.ButtonActivate.Text = "Activate";
            this.ButtonActivate.UseVisualStyleBackColor = false;
            this.ButtonActivate.Click += new System.EventHandler(this.ButtonActivate_Click);
            // 
            // ListActivate
            // 
            this.ListActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListActivate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.ListActivate.FullRowSelect = true;
            this.ListActivate.GridLines = true;
            this.ListActivate.Location = new System.Drawing.Point(119, 99);
            this.ListActivate.Name = "ListActivate";
            this.ListActivate.Size = new System.Drawing.Size(485, 258);
            this.ListActivate.TabIndex = 3;
            this.ListActivate.UseCompatibleStateImageBehavior = false;
            this.ListActivate.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Username";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Password";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "First name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Last name";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Age";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Location";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Friends";
            // 
            // FieldUsernameActivate
            // 
            this.FieldUsernameActivate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FieldUsernameActivate.Location = new System.Drawing.Point(119, 38);
            this.FieldUsernameActivate.Name = "FieldUsernameActivate";
            this.FieldUsernameActivate.Size = new System.Drawing.Size(256, 23);
            this.FieldUsernameActivate.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(22, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(22, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Username";
            // 
            // AdminMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(853, 480);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.PanelActivate);
            this.Controls.Add(this.PanelSuspend);
            this.Controls.Add(this.PanelViewAllUsers);
            this.Controls.Add(this.PanelRegister);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(340, 350);
            this.Name = "AdminMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.MenuStrip.ResumeLayout(false);
            this.SideBar.ResumeLayout(false);
            this.PanelRegister.ResumeLayout(false);
            this.PanelRegister.PerformLayout();
            this.PanelViewAllUsers.ResumeLayout(false);
            this.PanelSuspend.ResumeLayout(false);
            this.PanelSuspend.PerformLayout();
            this.PanelActivate.ResumeLayout(false);
            this.PanelActivate.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Button Exit;
        private Button Maximize;
        private Button Minimize;
        private Label WindowTitle;
        private Panel MenuStrip;
        private Panel SideBar;
        private Button RegisterNewUser;
        private Button ActivateUser;
        private Button SuspendUser;
        private Button ViewAllUsers;
        private Button LogOut;
        private Panel PanelRegister;
        private Label LastName;
        private Label FirstName;
        private Label Password;
        private Label Username;
        private TextBox FieldFriends;
        private TextBox FieldLocation;
        private TextBox FieldLastName;
        private TextBox FieldFirstName;
        private TextBox FieldPassword;
        private TextBox FieldUsername;
        private Label LocationLabel;
        private Label Friends;
        private Button RegisterUser;
        private Panel PanelViewAllUsers;
        private Label label2;
        private TextBox FieldAge;
        private ListView ListUsers;
        private Panel PanelSuspend;
        private Panel PanelActivate;
        private ColumnHeader ColumnUsername;
        private ColumnHeader ColumnPassword;
        private ColumnHeader ColumnFirstName;
        private ColumnHeader ColumnLastName;
        private ColumnHeader ColumnLocation;
        private ColumnHeader ColumnAge;
        private ColumnHeader ColumnFriends;
        private Label label4;
        private Label label3;
        private Label label1;
        private ListView ListReports;
        private ListView ListSuspendInfo;
        private Button ButtonSearch;
        private Button ButtonSuspendUser;
        private TextBox FieldSearch;
        private Button ButtonSearch2;
        private Button ButtonActivate;
        private ListView ListActivate;
        private TextBox FieldUsernameActivate;
        private Label label6;
        private Label label5;
        private ColumnHeader ColumnStatus;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
    }
}
