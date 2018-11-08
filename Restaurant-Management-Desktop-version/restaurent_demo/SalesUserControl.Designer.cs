namespace restaurent_demo
{
    partial class salesUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_table = new System.Windows.Forms.Panel();
            this.btn_search_table = new System.Windows.Forms.Button();
            this.tlp_table = new System.Windows.Forms.TableLayoutPanel();
            this.label_reserve = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_table_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_table_capacity = new System.Windows.Forms.TextBox();
            this.panel_table.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_table
            // 
            this.panel_table.BackColor = System.Drawing.Color.White;
            this.panel_table.Controls.Add(this.txt_table_capacity);
            this.panel_table.Controls.Add(this.label2);
            this.panel_table.Controls.Add(this.txt_table_number);
            this.panel_table.Controls.Add(this.label1);
            this.panel_table.Controls.Add(this.btn_search_table);
            this.panel_table.Controls.Add(this.tlp_table);
            this.panel_table.Controls.Add(this.label_reserve);
            this.panel_table.Location = new System.Drawing.Point(0, 3);
            this.panel_table.Name = "panel_table";
            this.panel_table.Size = new System.Drawing.Size(771, 417);
            this.panel_table.TabIndex = 13;
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
            // label_reserve
            // 
            this.label_reserve.AutoSize = true;
            this.label_reserve.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_reserve.ForeColor = System.Drawing.Color.IndianRed;
            this.label_reserve.Location = new System.Drawing.Point(331, 9);
            this.label_reserve.Name = "label_reserve";
            this.label_reserve.Size = new System.Drawing.Size(65, 26);
            this.label_reserve.TabIndex = 0;
            this.label_reserve.Text = "Table";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(75, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Table Number :";
            // 
            // txt_table_number
            // 
            this.txt_table_number.Location = new System.Drawing.Point(161, 58);
            this.txt_table_number.Name = "txt_table_number";
            this.txt_table_number.Size = new System.Drawing.Size(138, 20);
            this.txt_table_number.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.IndianRed;
            this.label2.Location = new System.Drawing.Point(318, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Capacity :";
            // 
            // txt_table_capacity
            // 
            this.txt_table_capacity.Location = new System.Drawing.Point(378, 57);
            this.txt_table_capacity.Name = "txt_table_capacity";
            this.txt_table_capacity.Size = new System.Drawing.Size(138, 20);
            this.txt_table_capacity.TabIndex = 18;
            // 
            // salesUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel_table);
            this.Name = "salesUserControl";
            this.Size = new System.Drawing.Size(774, 423);
            this.panel_table.ResumeLayout(false);
            this.panel_table.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_table;
        private System.Windows.Forms.Button btn_search_table;
        private System.Windows.Forms.TableLayoutPanel tlp_table;
        private System.Windows.Forms.Label label_reserve;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_table_number;
        private System.Windows.Forms.TextBox txt_table_capacity;
        private System.Windows.Forms.Label label2;
    }
}
