namespace GUI
{
    partial class UserLogin
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
            this.LoginScreen = new System.Windows.Forms.Panel();
            this.Remember = new System.Windows.Forms.CheckBox();
            this.LoingAsAdmin = new System.Windows.Forms.Button();
            this.LogIn = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.Panel();
            this.LoginScreen.SuspendLayout();
            this.MenuStrip.SuspendLayout();
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
            // LoginScreen
            // 
            this.LoginScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.LoginScreen.Controls.Add(this.Remember);
            this.LoginScreen.Controls.Add(this.LoingAsAdmin);
            this.LoginScreen.Controls.Add(this.LogIn);
            this.LoginScreen.Controls.Add(this.Password);
            this.LoginScreen.Controls.Add(this.Address);
            this.LoginScreen.Location = new System.Drawing.Point(260, 100);
            this.LoginScreen.Name = "LoginScreen";
            this.LoginScreen.Size = new System.Drawing.Size(330, 300);
            this.LoginScreen.TabIndex = 5;
            // 
            // Remember
            // 
            this.Remember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Remember.AutoSize = true;
            this.Remember.ForeColor = System.Drawing.Color.White;
            this.Remember.Location = new System.Drawing.Point(20, 198);
            this.Remember.Name = "Remember";
            this.Remember.Size = new System.Drawing.Size(104, 19);
            this.Remember.TabIndex = 2;
            this.Remember.Text = "Remember me";
            this.Remember.UseVisualStyleBackColor = true;
            // 
            // LoingAsAdmin
            // 
            this.LoingAsAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LoingAsAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.LoingAsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LoingAsAdmin.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.LoingAsAdmin.Location = new System.Drawing.Point(90, 253);
            this.LoingAsAdmin.Name = "LoingAsAdmin";
            this.LoingAsAdmin.Size = new System.Drawing.Size(146, 23);
            this.LoingAsAdmin.TabIndex = 4;
            this.LoingAsAdmin.Text = "Login as admin";
            this.LoingAsAdmin.UseVisualStyleBackColor = false;
            this.LoingAsAdmin.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // LogIn
            // 
            this.LogIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LogIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.LogIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LogIn.ForeColor = System.Drawing.Color.White;
            this.LogIn.Location = new System.Drawing.Point(90, 223);
            this.LogIn.Name = "LogIn";
            this.LogIn.Size = new System.Drawing.Size(146, 23);
            this.LogIn.TabIndex = 3;
            this.LogIn.Text = "Log in";
            this.LogIn.UseVisualStyleBackColor = false;
            this.LogIn.Click += new System.EventHandler(this.LogIn_Click);
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(20, 161);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(292, 23);
            this.Password.TabIndex = 1;
            // 
            // Address
            // 
            this.Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Address.Location = new System.Drawing.Point(20, 130);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(292, 23);
            this.Address.TabIndex = 0;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.MenuStrip.Controls.Add(this.Minimize);
            this.MenuStrip.Controls.Add(this.Exit);
            this.MenuStrip.Controls.Add(this.Maximize);
            this.MenuStrip.Location = new System.Drawing.Point(1, 1);
            this.MenuStrip.MinimumSize = new System.Drawing.Size(100, 27);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(851, 27);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            this.MenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseMove);
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(853, 480);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.LoginScreen);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(340, 350);
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.LoginScreen.ResumeLayout(false);
            this.LoginScreen.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button Exit;
        private Button Maximize;
        private Button Minimize;
        private Label WindowTitle;
        private Panel LoginScreen;
        private CheckBox Remember;
        private Button LoingAsAdmin;
        private Button LogIn;
        private TextBox Password;
        private TextBox Address;
        private Panel MenuStrip;
    }
}