namespace GUI
{
    partial class MainWindow
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
            this.SignUp = new System.Windows.Forms.Button();
            this.SignIn = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.MenuStrip = new System.Windows.Forms.Panel();
            this.LoginScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.Image = global::GUI.Properties.Resources.window_close;
            this.Exit.Location = new System.Drawing.Point(807, 1);
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
            this.Maximize.Location = new System.Drawing.Point(778, 1);
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
            this.Minimize.Location = new System.Drawing.Point(749, 1);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(23, 23);
            this.Minimize.TabIndex = 3;
            this.Minimize.UseVisualStyleBackColor = false;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // WindowTitle
            // 
            this.WindowTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.WindowTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.WindowTitle.ForeColor = System.Drawing.Color.White;
            this.WindowTitle.Location = new System.Drawing.Point(340, 2);
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.Size = new System.Drawing.Size(115, 21);
            this.WindowTitle.TabIndex = 4;
            this.WindowTitle.Text = "Social Network";
            // 
            // LoginScreen
            // 
            this.LoginScreen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LoginScreen.AutoSize = true;
            this.LoginScreen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.LoginScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.LoginScreen.Controls.Add(this.Remember);
            this.LoginScreen.Controls.Add(this.SignUp);
            this.LoginScreen.Controls.Add(this.SignIn);
            this.LoginScreen.Controls.Add(this.Password);
            this.LoginScreen.Controls.Add(this.Address);
            this.LoginScreen.Location = new System.Drawing.Point(250, 67);
            this.LoginScreen.Name = "LoginScreen";
            this.LoginScreen.Size = new System.Drawing.Size(307, 258);
            this.LoginScreen.TabIndex = 5;
            // 
            // Remember
            // 
            this.Remember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Remember.AutoSize = true;
            this.Remember.ForeColor = System.Drawing.Color.White;
            this.Remember.Location = new System.Drawing.Point(20, 177);
            this.Remember.Name = "Remember";
            this.Remember.Size = new System.Drawing.Size(104, 19);
            this.Remember.TabIndex = 4;
            this.Remember.Text = "Remember me";
            this.Remember.UseVisualStyleBackColor = true;
            // 
            // SignUp
            // 
            this.SignUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.SignUp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SignUp.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SignUp.Location = new System.Drawing.Point(90, 232);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(123, 23);
            this.SignUp.TabIndex = 3;
            this.SignUp.Text = "SignUp";
            this.SignUp.UseVisualStyleBackColor = false;
            this.SignUp.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // SignIn
            // 
            this.SignIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SignIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.SignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SignIn.ForeColor = System.Drawing.Color.White;
            this.SignIn.Location = new System.Drawing.Point(90, 197);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(123, 23);
            this.SignIn.TabIndex = 2;
            this.SignIn.Text = "Sign in";
            this.SignIn.UseVisualStyleBackColor = false;
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(20, 140);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(269, 23);
            this.Password.TabIndex = 1;
            // 
            // Address
            // 
            this.Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Address.Location = new System.Drawing.Point(20, 109);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(269, 23);
            this.Address.TabIndex = 0;
            // 
            // MenuStrip
            // 
            this.MenuStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.MenuStrip.Location = new System.Drawing.Point(0, 1);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(831, 27);
            this.MenuStrip.TabIndex = 6;
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown_1);
            this.MenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseMove_1);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(831, 450);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.MenuStrip);
            this.Controls.Add(this.LoginScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainWindow_MouseDown);
            this.LoginScreen.ResumeLayout(false);
            this.LoginScreen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button Exit;
        private Button Maximize;
        private Button Minimize;
        private Label WindowTitle;
        private Panel LoginScreen;
        private CheckBox Remember;
        private Button SignUp;
        private Button SignIn;
        private TextBox Password;
        private TextBox Address;
        private Panel MenuStrip;
    }
}