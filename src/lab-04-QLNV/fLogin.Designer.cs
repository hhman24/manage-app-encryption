namespace lab_04_QLNV
{
    partial class fLogin
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
            this.pImage = new System.Windows.Forms.Panel();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.checkBoxPas = new System.Windows.Forms.CheckBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.tboxPassWord = new System.Windows.Forms.TextBox();
            this.labelPassWord = new System.Windows.Forms.Label();
            this.tboxUserName = new System.Windows.Forms.TextBox();
            this.labelUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pImage
            // 
            this.pImage.BackgroundImage = global::lab_04_QLNV.Properties.Resources.p2;
            this.pImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pImage.Location = new System.Drawing.Point(0, 0);
            this.pImage.Name = "pImage";
            this.pImage.Size = new System.Drawing.Size(317, 230);
            this.pImage.TabIndex = 0;
            this.pImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pImage_Paint);
            // 
            // ExitBtn
            // 
            this.ExitBtn.BackColor = System.Drawing.Color.White;
            this.ExitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ExitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitBtn.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExitBtn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ExitBtn.Location = new System.Drawing.Point(28, 496);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(254, 33);
            this.ExitBtn.TabIndex = 5;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // checkBoxPas
            // 
            this.checkBoxPas.AutoSize = true;
            this.checkBoxPas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxPas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxPas.Location = new System.Drawing.Point(132, 411);
            this.checkBoxPas.Name = "checkBoxPas";
            this.checkBoxPas.Size = new System.Drawing.Size(151, 27);
            this.checkBoxPas.TabIndex = 3;
            this.checkBoxPas.Text = "Show Password";
            this.checkBoxPas.UseVisualStyleBackColor = true;
            this.checkBoxPas.CheckedChanged += new System.EventHandler(this.checkBoxPas_CheckedChanged);
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.RoyalBlue;
            this.loginButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Nirmala UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.ForeColor = System.Drawing.Color.White;
            this.loginButton.Location = new System.Drawing.Point(29, 457);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(254, 33);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // tboxPassWord
            // 
            this.tboxPassWord.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.tboxPassWord.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxPassWord.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxPassWord.Location = new System.Drawing.Point(29, 372);
            this.tboxPassWord.Name = "tboxPassWord";
            this.tboxPassWord.PasswordChar = '*';
            this.tboxPassWord.Size = new System.Drawing.Size(254, 33);
            this.tboxPassWord.TabIndex = 2;
            this.tboxPassWord.TextChanged += new System.EventHandler(this.tboxPassWord_TextChanged);
            // 
            // labelPassWord
            // 
            this.labelPassWord.AutoSize = true;
            this.labelPassWord.Location = new System.Drawing.Point(25, 346);
            this.labelPassWord.Name = "labelPassWord";
            this.labelPassWord.Size = new System.Drawing.Size(84, 23);
            this.labelPassWord.TabIndex = 10;
            this.labelPassWord.Text = "Password";
            // 
            // tboxUserName
            // 
            this.tboxUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(233)))));
            this.tboxUserName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxUserName.Font = new System.Drawing.Font("MS UI Gothic", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxUserName.Location = new System.Drawing.Point(29, 297);
            this.tboxUserName.Name = "tboxUserName";
            this.tboxUserName.Size = new System.Drawing.Size(254, 33);
            this.tboxUserName.TabIndex = 1;
            this.tboxUserName.TextChanged += new System.EventHandler(this.tboxUserName_TextChanged);
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.Location = new System.Drawing.Point(24, 266);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(89, 23);
            this.labelUserName.TabIndex = 8;
            this.labelUserName.Text = "Username";
            // 
            // fLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(317, 544);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.checkBoxPas);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.tboxPassWord);
            this.Controls.Add(this.labelPassWord);
            this.Controls.Add(this.tboxUserName);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.pImage);
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "fLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginFrame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLogin_FormClosing);
            this.Load += new System.EventHandler(this.loginFrame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pImage;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.CheckBox checkBoxPas;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox tboxPassWord;
        private System.Windows.Forms.Label labelPassWord;
        private System.Windows.Forms.TextBox tboxUserName;
        private System.Windows.Forms.Label labelUserName;
    }
}