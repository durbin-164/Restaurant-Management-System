namespace restaurent_demo
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
            this.panel_welcome = new System.Windows.Forms.Panel();
            this.panel_login = new System.Windows.Forms.Panel();
            this.btn_back = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label_user = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.label_wel = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_staff_log = new System.Windows.Forms.Button();
            this.btn_man_log = new System.Windows.Forms.Button();
            this.panel_head = new System.Windows.Forms.Panel();
            this.label_res = new System.Windows.Forms.Label();
            this.panel_welcome.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.panel_head.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_welcome
            // 
            this.panel_welcome.BackColor = System.Drawing.Color.LightBlue;
            this.panel_welcome.Controls.Add(this.panel_login);
            this.panel_welcome.Controls.Add(this.label_wel);
            this.panel_welcome.Controls.Add(this.btn_exit);
            this.panel_welcome.Controls.Add(this.btn_staff_log);
            this.panel_welcome.Controls.Add(this.btn_man_log);
            this.panel_welcome.Location = new System.Drawing.Point(0, 108);
            this.panel_welcome.Name = "panel_welcome";
            this.panel_welcome.Size = new System.Drawing.Size(689, 339);
            this.panel_welcome.TabIndex = 0;
            this.panel_welcome.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_welcome_Paint);
            // 
            // panel_login
            // 
            this.panel_login.BackColor = System.Drawing.Color.Teal;
            this.panel_login.Controls.Add(this.btn_back);
            this.panel_login.Controls.Add(this.label2);
            this.panel_login.Controls.Add(this.label1);
            this.panel_login.Controls.Add(this.txt_pass);
            this.panel_login.Controls.Add(this.txt_email);
            this.panel_login.Controls.Add(this.label_user);
            this.panel_login.Controls.Add(this.btn_login);
            this.panel_login.Location = new System.Drawing.Point(0, 0);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(689, 339);
            this.panel_login.TabIndex = 4;
            this.panel_login.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_login_Paint);
            // 
            // btn_back
            // 
            this.btn_back.Location = new System.Drawing.Point(295, 241);
            this.btn_back.Name = "btn_back";
            this.btn_back.Size = new System.Drawing.Size(113, 24);
            this.btn_back.TabIndex = 8;
            this.btn_back.Text = "Back";
            this.btn_back.UseVisualStyleBackColor = true;
            this.btn_back.Click += new System.EventHandler(this.btn_back_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Password :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(154, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Email :";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(245, 152);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(215, 20);
            this.txt_pass.TabIndex = 5;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(245, 112);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(215, 20);
            this.txt_email.TabIndex = 4;
            // 
            // label_user
            // 
            this.label_user.AutoSize = true;
            this.label_user.Location = new System.Drawing.Point(242, 44);
            this.label_user.Name = "label_user";
            this.label_user.Size = new System.Drawing.Size(35, 13);
            this.label_user.TabIndex = 3;
            this.label_user.Text = "label1";
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(295, 202);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(113, 24);
            this.btn_login.TabIndex = 2;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // label_wel
            // 
            this.label_wel.AutoSize = true;
            this.label_wel.Location = new System.Drawing.Point(258, 44);
            this.label_wel.Name = "label_wel";
            this.label_wel.Size = new System.Drawing.Size(35, 13);
            this.label_wel.TabIndex = 3;
            this.label_wel.Text = "label1";
            // 
            // btn_exit
            // 
            this.btn_exit.Location = new System.Drawing.Point(245, 220);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(215, 34);
            this.btn_exit.TabIndex = 2;
            this.btn_exit.Text = "Exit";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_staff_log
            // 
            this.btn_staff_log.Location = new System.Drawing.Point(245, 165);
            this.btn_staff_log.Name = "btn_staff_log";
            this.btn_staff_log.Size = new System.Drawing.Size(215, 34);
            this.btn_staff_log.TabIndex = 1;
            this.btn_staff_log.Text = "Login as Staff";
            this.btn_staff_log.UseVisualStyleBackColor = true;
            this.btn_staff_log.Click += new System.EventHandler(this.btn_staff_log_Click);
            // 
            // btn_man_log
            // 
            this.btn_man_log.Location = new System.Drawing.Point(245, 115);
            this.btn_man_log.Name = "btn_man_log";
            this.btn_man_log.Size = new System.Drawing.Size(215, 34);
            this.btn_man_log.TabIndex = 0;
            this.btn_man_log.Text = "Login as Manager";
            this.btn_man_log.UseVisualStyleBackColor = true;
            this.btn_man_log.Click += new System.EventHandler(this.btn_man_log_Click);
            // 
            // panel_head
            // 
            this.panel_head.BackColor = System.Drawing.Color.DimGray;
            this.panel_head.Controls.Add(this.label_res);
            this.panel_head.Location = new System.Drawing.Point(0, 0);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(689, 109);
            this.panel_head.TabIndex = 1;
            // 
            // label_res
            // 
            this.label_res.AutoSize = true;
            this.label_res.Location = new System.Drawing.Point(242, 27);
            this.label_res.Name = "label_res";
            this.label_res.Size = new System.Drawing.Size(35, 13);
            this.label_res.TabIndex = 0;
            this.label_res.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 446);
            this.Controls.Add(this.panel_head);
            this.Controls.Add(this.panel_welcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel_welcome.ResumeLayout(false);
            this.panel_welcome.PerformLayout();
            this.panel_login.ResumeLayout(false);
            this.panel_login.PerformLayout();
            this.panel_head.ResumeLayout(false);
            this.panel_head.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_welcome;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_staff_log;
        private System.Windows.Forms.Button btn_man_log;
        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.Label label_res;
        private System.Windows.Forms.Label label_wel;
        private System.Windows.Forms.Panel panel_login;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label_user;
        private System.Windows.Forms.Button btn_login;
    }
}

