namespace Crestron_NVX
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPAddress = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.IPAdd = new System.Windows.Forms.TextBox();
            this.Uname = new System.Windows.Forms.TextBox();
            this.Passwrd = new System.Windows.Forms.TextBox();
            this.HomePage = new System.Windows.Forms.GroupBox();
            this.Login = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SyncDetect = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Vertical = new System.Windows.Forms.TextBox();
            this.Horizontal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HomePage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPAddress
            // 
            this.IPAddress.AutoSize = true;
            this.IPAddress.Location = new System.Drawing.Point(63, 47);
            this.IPAddress.Name = "IPAddress";
            this.IPAddress.Size = new System.Drawing.Size(55, 13);
            this.IPAddress.TabIndex = 0;
            this.IPAddress.Text = "IPAddress";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(63, 76);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(63, 13);
            this.UserName.TabIndex = 1;
            this.UserName.Text = "User Name:";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(63, 108);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(56, 13);
            this.Password.TabIndex = 2;
            this.Password.Text = "Password:";
            // 
            // IPAdd
            // 
            this.IPAdd.Location = new System.Drawing.Point(134, 47);
            this.IPAdd.Name = "IPAdd";
            this.IPAdd.Size = new System.Drawing.Size(136, 20);
            this.IPAdd.TabIndex = 3;
            // 
            // Uname
            // 
            this.Uname.Location = new System.Drawing.Point(134, 76);
            this.Uname.Name = "Uname";
            this.Uname.Size = new System.Drawing.Size(136, 20);
            this.Uname.TabIndex = 4;
            // 
            // Passwrd
            // 
            this.Passwrd.Location = new System.Drawing.Point(134, 108);
            this.Passwrd.Name = "Passwrd";
            this.Passwrd.PasswordChar = '*';
            this.Passwrd.Size = new System.Drawing.Size(136, 20);
            this.Passwrd.TabIndex = 5;
            // 
            // HomePage
            // 
            this.HomePage.Controls.Add(this.Login);
            this.HomePage.Controls.Add(this.IPAdd);
            this.HomePage.Controls.Add(this.Passwrd);
            this.HomePage.Controls.Add(this.IPAddress);
            this.HomePage.Controls.Add(this.Uname);
            this.HomePage.Controls.Add(this.UserName);
            this.HomePage.Controls.Add(this.Password);
            this.HomePage.Location = new System.Drawing.Point(0, 12);
            this.HomePage.Name = "HomePage";
            this.HomePage.Size = new System.Drawing.Size(370, 238);
            this.HomePage.TabIndex = 6;
            this.HomePage.TabStop = false;
            this.HomePage.Text = "Login";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(156, 134);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(75, 23);
            this.Login.TabIndex = 6;
            this.Login.Text = "Login";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SyncDetect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.Vertical);
            this.groupBox2.Controls.Add(this.Horizontal);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(376, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 237);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resolution";
            // 
            // SyncDetect
            // 
            this.SyncDetect.Location = new System.Drawing.Point(144, 115);
            this.SyncDetect.Name = "SyncDetect";
            this.SyncDetect.ReadOnly = true;
            this.SyncDetect.Size = new System.Drawing.Size(100, 20);
            this.SyncDetect.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sync Detected:";
            // 
            // Vertical
            // 
            this.Vertical.Location = new System.Drawing.Point(144, 79);
            this.Vertical.Name = "Vertical";
            this.Vertical.ReadOnly = true;
            this.Vertical.Size = new System.Drawing.Size(100, 20);
            this.Vertical.TabIndex = 3;
            // 
            // Horizontal
            // 
            this.Horizontal.Location = new System.Drawing.Point(144, 46);
            this.Horizontal.Name = "Horizontal";
            this.Horizontal.ReadOnly = true;
            this.Horizontal.Size = new System.Drawing.Size(100, 20);
            this.Horizontal.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Vertical:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Horizontal:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 262);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.HomePage);
            this.Name = "Form1";
            this.Text = "NVX Device Helper";
            this.HomePage.ResumeLayout(false);
            this.HomePage.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label IPAddress;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.TextBox IPAdd;
        private System.Windows.Forms.TextBox Uname;
        private System.Windows.Forms.TextBox Passwrd;
        private System.Windows.Forms.GroupBox HomePage;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Vertical;
        private System.Windows.Forms.TextBox Horizontal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SyncDetect;
        private System.Windows.Forms.Label label3;
    }
}

