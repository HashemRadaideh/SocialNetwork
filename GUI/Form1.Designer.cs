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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.Exit = new System.Windows.Forms.Button();
            this.Maximize = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Remember = new System.Windows.Forms.CheckBox();
            this.SignUp = new System.Windows.Forms.Button();
            this.SignIn = new System.Windows.Forms.Button();
            this.Password = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(831, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseDown);
            this.MenuStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseMove);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Exit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Exit.Image = ((System.Drawing.Image)(resources.GetObject("Exit.Image")));
            this.Exit.Location = new System.Drawing.Point(807, 0);
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
            this.Maximize.Location = new System.Drawing.Point(778, 0);
            this.Maximize.Name = "Maximize";
            this.Maximize.Size = new System.Drawing.Size(23, 23);
            this.Maximize.TabIndex = 2;
            this.Maximize.UseVisualStyleBackColor = false;
            // 
            // Minimize
            // 
            this.Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Minimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.Minimize.Location = new System.Drawing.Point(749, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(23, 23);
            this.Minimize.TabIndex = 3;
            this.Minimize.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(34)))), ((int)(((byte)(46)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(340, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Social Network";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(44)))), ((int)(((byte)(56)))));
            this.panel1.Controls.Add(this.Remember);
            this.panel1.Controls.Add(this.SignUp);
            this.panel1.Controls.Add(this.SignIn);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.Address);
            this.panel1.Location = new System.Drawing.Point(265, 47);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 357);
            this.panel1.TabIndex = 5;
            // 
            // Remember
            // 
            this.Remember.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Remember.AutoSize = true;
            this.Remember.ForeColor = System.Drawing.Color.White;
            this.Remember.Location = new System.Drawing.Point(20, 202);
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
            this.SignUp.Location = new System.Drawing.Point(90, 288);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(100, 23);
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
            this.SignIn.Location = new System.Drawing.Point(90, 241);
            this.SignIn.Name = "SignIn";
            this.SignIn.Size = new System.Drawing.Size(100, 23);
            this.SignIn.TabIndex = 2;
            this.SignIn.Text = "Sign in";
            this.SignIn.UseVisualStyleBackColor = false;
            // 
            // Password
            // 
            this.Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Password.Location = new System.Drawing.Point(20, 173);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(236, 23);
            this.Password.TabIndex = 1;
            // 
            // Address
            // 
            this.Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Address.Location = new System.Drawing.Point(20, 128);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(236, 23);
            this.Address.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(24)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(831, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.Maximize);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip MenuStrip;
        private Button Exit;
        private Button Maximize;
        private Button Minimize;
        private Label label1;
        private Panel panel1;
        private CheckBox Remember;
        private Button SignUp;
        private Button SignIn;
        private TextBox Password;
        private TextBox Address;
    }
}