namespace restaurent_demo
{
    partial class HomeForm
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
            this.components = new System.ComponentModel.Container();
            this.panel_head = new System.Windows.Forms.Panel();
            this.btn_logout = new System.Windows.Forms.Button();
            this.label_res = new System.Windows.Forms.Label();
            this.ts_menu = new System.Windows.Forms.ToolStrip();
            this.panel_home = new System.Windows.Forms.Panel();
            this.panel_ingrediant = new System.Windows.Forms.Panel();
            this.btn_del_ingrediants = new System.Windows.Forms.Button();
            this.label_ingrediant = new System.Windows.Forms.Label();
            this.txt_quantity_ingrediants = new System.Windows.Forms.TextBox();
            this.btn_add_ingrediants = new System.Windows.Forms.Button();
            this.btn_search_ingrediants = new System.Windows.Forms.Button();
            this.label31 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txt_name_ingrediants = new System.Windows.Forms.TextBox();
            this.tlp_ingrediant = new System.Windows.Forms.TableLayoutPanel();
            this.panel_table = new System.Windows.Forms.Panel();
            this.txt_table_capacity = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.txt_table_number = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.btn_search_table = new System.Windows.Forms.Button();
            this.tlp_table = new System.Windows.Forms.TableLayoutPanel();
            this.label45 = new System.Windows.Forms.Label();
            this.panel_about = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel_head.SuspendLayout();
            this.panel_home.SuspendLayout();
            this.panel_ingrediant.SuspendLayout();
            this.panel_table.SuspendLayout();
            this.panel_about.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_head
            // 
            this.panel_head.Controls.Add(this.btn_logout);
            this.panel_head.Controls.Add(this.label_res);
            this.panel_head.Location = new System.Drawing.Point(-1, 1);
            this.panel_head.Name = "panel_head";
            this.panel_head.Size = new System.Drawing.Size(1304, 105);
            this.panel_head.TabIndex = 0;
            // 
            // btn_logout
            // 
            this.btn_logout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_logout.Location = new System.Drawing.Point(1139, 60);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Size = new System.Drawing.Size(108, 23);
            this.btn_logout.TabIndex = 1;
            this.btn_logout.Text = "Log Out";
            this.btn_logout.UseVisualStyleBackColor = true;
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // label_res
            // 
            this.label_res.AutoSize = true;
            this.label_res.Location = new System.Drawing.Point(421, 18);
            this.label_res.Name = "label_res";
            this.label_res.Size = new System.Drawing.Size(35, 13);
            this.label_res.TabIndex = 0;
            this.label_res.Text = "label1";
            // 
            // ts_menu
            // 
            this.ts_menu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ts_menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ts_menu.Location = new System.Drawing.Point(0, 0);
            this.ts_menu.Name = "ts_menu";
            this.ts_menu.Size = new System.Drawing.Size(26, 554);
            this.ts_menu.TabIndex = 0;
            this.ts_menu.Text = "toolStrip1";
            // 
            // panel_home
            // 
            this.panel_home.BackColor = System.Drawing.Color.LightGreen;
            this.panel_home.Controls.Add(this.panel_ingrediant);
            this.panel_home.Controls.Add(this.panel_table);
            this.panel_home.Controls.Add(this.panel_about);
            this.panel_home.Controls.Add(this.ts_menu);
            this.panel_home.Location = new System.Drawing.Point(0, 106);
            this.panel_home.Name = "panel_home";
            this.panel_home.Size = new System.Drawing.Size(1301, 554);
            this.panel_home.TabIndex = 1;
            this.panel_home.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_home_Paint);
            // 
            // panel_ingrediant
            // 
            this.panel_ingrediant.BackColor = System.Drawing.Color.White;
            this.panel_ingrediant.Controls.Add(this.btn_del_ingrediants);
            this.panel_ingrediant.Controls.Add(this.label_ingrediant);
            this.panel_ingrediant.Controls.Add(this.txt_quantity_ingrediants);
            this.panel_ingrediant.Controls.Add(this.btn_add_ingrediants);
            this.panel_ingrediant.Controls.Add(this.btn_search_ingrediants);
            this.panel_ingrediant.Controls.Add(this.label31);
            this.panel_ingrediant.Controls.Add(this.label32);
            this.panel_ingrediant.Controls.Add(this.txt_name_ingrediants);
            this.panel_ingrediant.Controls.Add(this.tlp_ingrediant);
            this.panel_ingrediant.Location = new System.Drawing.Point(48, 60);
            this.panel_ingrediant.Name = "panel_ingrediant";
            this.panel_ingrediant.Size = new System.Drawing.Size(1165, 588);
            this.panel_ingrediant.TabIndex = 53;
            this.panel_ingrediant.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_ingrediant_Paint);
            // 
            // btn_del_ingrediants
            // 
            this.btn_del_ingrediants.BackColor = System.Drawing.Color.IndianRed;
            this.btn_del_ingrediants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_del_ingrediants.ForeColor = System.Drawing.Color.White;
            this.btn_del_ingrediants.Location = new System.Drawing.Point(1017, 58);
            this.btn_del_ingrediants.Name = "btn_del_ingrediants";
            this.btn_del_ingrediants.Size = new System.Drawing.Size(104, 37);
            this.btn_del_ingrediants.TabIndex = 12;
            this.btn_del_ingrediants.Text = "Delete Ingrediant";
            this.btn_del_ingrediants.UseVisualStyleBackColor = false;
            // 
            // label_ingrediant
            // 
            this.label_ingrediant.AutoSize = true;
            this.label_ingrediant.BackColor = System.Drawing.Color.White;
            this.label_ingrediant.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ingrediant.ForeColor = System.Drawing.Color.IndianRed;
            this.label_ingrediant.Location = new System.Drawing.Point(472, 15);
            this.label_ingrediant.Name = "label_ingrediant";
            this.label_ingrediant.Size = new System.Drawing.Size(108, 26);
            this.label_ingrediant.TabIndex = 0;
            this.label_ingrediant.Text = "Ingrediant";
            // 
            // txt_quantity_ingrediants
            // 
            this.txt_quantity_ingrediants.Location = new System.Drawing.Point(459, 69);
            this.txt_quantity_ingrediants.Name = "txt_quantity_ingrediants";
            this.txt_quantity_ingrediants.Size = new System.Drawing.Size(134, 20);
            this.txt_quantity_ingrediants.TabIndex = 11;
            // 
            // btn_add_ingrediants
            // 
            this.btn_add_ingrediants.BackColor = System.Drawing.Color.IndianRed;
            this.btn_add_ingrediants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_add_ingrediants.ForeColor = System.Drawing.Color.White;
            this.btn_add_ingrediants.Location = new System.Drawing.Point(864, 58);
            this.btn_add_ingrediants.Name = "btn_add_ingrediants";
            this.btn_add_ingrediants.Size = new System.Drawing.Size(104, 37);
            this.btn_add_ingrediants.TabIndex = 10;
            this.btn_add_ingrediants.Text = "Add Ingrediant";
            this.btn_add_ingrediants.UseVisualStyleBackColor = false;
            // 
            // btn_search_ingrediants
            // 
            this.btn_search_ingrediants.BackColor = System.Drawing.Color.IndianRed;
            this.btn_search_ingrediants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search_ingrediants.ForeColor = System.Drawing.Color.White;
            this.btn_search_ingrediants.Location = new System.Drawing.Point(635, 58);
            this.btn_search_ingrediants.Name = "btn_search_ingrediants";
            this.btn_search_ingrediants.Size = new System.Drawing.Size(112, 37);
            this.btn_search_ingrediants.TabIndex = 9;
            this.btn_search_ingrediants.Text = "Search Ingrediants";
            this.btn_search_ingrediants.UseVisualStyleBackColor = false;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.ForeColor = System.Drawing.Color.IndianRed;
            this.label31.Location = new System.Drawing.Point(391, 73);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(52, 13);
            this.label31.TabIndex = 7;
            this.label31.Text = "Quantity :";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.ForeColor = System.Drawing.Color.IndianRed;
            this.label32.Location = new System.Drawing.Point(141, 74);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 13);
            this.label32.TabIndex = 6;
            this.label32.Text = "Name :";
            // 
            // txt_name_ingrediants
            // 
            this.txt_name_ingrediants.Location = new System.Drawing.Point(188, 71);
            this.txt_name_ingrediants.Name = "txt_name_ingrediants";
            this.txt_name_ingrediants.Size = new System.Drawing.Size(177, 20);
            this.txt_name_ingrediants.TabIndex = 2;
            // 
            // tlp_ingrediant
            // 
            this.tlp_ingrediant.ColumnCount = 1;
            this.tlp_ingrediant.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ingrediant.Location = new System.Drawing.Point(54, 132);
            this.tlp_ingrediant.Name = "tlp_ingrediant";
            this.tlp_ingrediant.RowCount = 1;
            this.tlp_ingrediant.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_ingrediant.Size = new System.Drawing.Size(1092, 438);
            this.tlp_ingrediant.TabIndex = 1;
            // 
            // panel_table
            // 
            this.panel_table.BackColor = System.Drawing.Color.White;
            this.panel_table.Controls.Add(this.txt_table_capacity);
            this.panel_table.Controls.Add(this.label43);
            this.panel_table.Controls.Add(this.txt_table_number);
            this.panel_table.Controls.Add(this.label44);
            this.panel_table.Controls.Add(this.btn_search_table);
            this.panel_table.Controls.Add(this.tlp_table);
            this.panel_table.Controls.Add(this.label45);
            this.panel_table.Location = new System.Drawing.Point(265, 69);
            this.panel_table.Name = "panel_table";
            this.panel_table.Size = new System.Drawing.Size(1165, 588);
            this.panel_table.TabIndex = 42;
            // 
            // txt_table_capacity
            // 
            this.txt_table_capacity.Location = new System.Drawing.Point(378, 57);
            this.txt_table_capacity.Name = "txt_table_capacity";
            this.txt_table_capacity.Size = new System.Drawing.Size(138, 20);
            this.txt_table_capacity.TabIndex = 18;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.ForeColor = System.Drawing.Color.IndianRed;
            this.label43.Location = new System.Drawing.Point(318, 58);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(54, 13);
            this.label43.TabIndex = 17;
            this.label43.Text = "Capacity :";
            // 
            // txt_table_number
            // 
            this.txt_table_number.Location = new System.Drawing.Point(161, 58);
            this.txt_table_number.Name = "txt_table_number";
            this.txt_table_number.Size = new System.Drawing.Size(138, 20);
            this.txt_table_number.TabIndex = 16;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.ForeColor = System.Drawing.Color.IndianRed;
            this.label44.Location = new System.Drawing.Point(75, 59);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(80, 13);
            this.label44.TabIndex = 15;
            this.label44.Text = "Table Number :";
            // 
            // btn_search_table
            // 
            this.btn_search_table.BackColor = System.Drawing.Color.IndianRed;
            this.btn_search_table.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_search_table.ForeColor = System.Drawing.Color.White;
            this.btn_search_table.Location = new System.Drawing.Point(559, 54);
            this.btn_search_table.Name = "btn_search_table";
            this.btn_search_table.Size = new System.Drawing.Size(107, 23);
            this.btn_search_table.TabIndex = 9;
            this.btn_search_table.Text = "Search";
            this.btn_search_table.UseVisualStyleBackColor = false;
            // 
            // tlp_table
            // 
            this.tlp_table.ColumnCount = 1;
            this.tlp_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_table.Location = new System.Drawing.Point(19, 104);
            this.tlp_table.Name = "tlp_table";
            this.tlp_table.RowCount = 1;
            this.tlp_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_table.Size = new System.Drawing.Size(733, 296);
            this.tlp_table.TabIndex = 1;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.ForeColor = System.Drawing.Color.IndianRed;
            this.label45.Location = new System.Drawing.Point(331, 9);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(65, 26);
            this.label45.TabIndex = 0;
            this.label45.Text = "Table";
            // 
            // panel_about
            // 
            this.panel_about.BackColor = System.Drawing.Color.DimGray;
            this.panel_about.Controls.Add(this.groupBox1);
            this.panel_about.Controls.Add(this.label_name);
            this.panel_about.Location = new System.Drawing.Point(150, 0);
            this.panel_about.Name = "panel_about";
            this.panel_about.Size = new System.Drawing.Size(1148, 551);
            this.panel_about.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(68, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1042, 418);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(829, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 156);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 268);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Salary :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Joining Date :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Post :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Contact Number :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mother Name :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Father Name :";
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(65, 60);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(35, 13);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "label1";
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 656);
            this.Controls.Add(this.panel_home);
            this.Controls.Add(this.panel_head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HomeForm";
            this.Text = "HomeForm";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.panel_head.ResumeLayout(false);
            this.panel_head.PerformLayout();
            this.panel_home.ResumeLayout(false);
            this.panel_home.PerformLayout();
            this.panel_ingrediant.ResumeLayout(false);
            this.panel_ingrediant.PerformLayout();
            this.panel_table.ResumeLayout(false);
            this.panel_table.PerformLayout();
            this.panel_about.ResumeLayout(false);
            this.panel_about.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_head;
        private System.Windows.Forms.Label label_res;
        private System.Windows.Forms.ToolStrip ts_menu;
        private System.Windows.Forms.Panel panel_home;
        private System.Windows.Forms.Button btn_logout;
        private System.Windows.Forms.Panel panel_about;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel_table;
        private System.Windows.Forms.TextBox txt_table_capacity;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox txt_table_number;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button btn_search_table;
        private System.Windows.Forms.TableLayoutPanel tlp_table;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Panel panel_ingrediant;
        private System.Windows.Forms.Button btn_del_ingrediants;
        private System.Windows.Forms.Label label_ingrediant;
        private System.Windows.Forms.TextBox txt_quantity_ingrediants;
        private System.Windows.Forms.Button btn_add_ingrediants;
        private System.Windows.Forms.Button btn_search_ingrediants;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox txt_name_ingrediants;
        private System.Windows.Forms.TableLayoutPanel tlp_ingrediant;
    }
}