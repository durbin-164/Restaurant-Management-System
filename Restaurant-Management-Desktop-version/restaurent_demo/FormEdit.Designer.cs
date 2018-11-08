namespace restaurent_demo
{
    partial class FormEdit
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
            this.lbl_head = new System.Windows.Forms.Label();
            this.lbl_id_txt = new System.Windows.Forms.Label();
            this.lbl_value = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_id = new System.Windows.Forms.Label();
            this.txt_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_head
            // 
            this.lbl_head.AutoSize = true;
            this.lbl_head.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_head.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_head.Location = new System.Drawing.Point(226, 29);
            this.lbl_head.Name = "lbl_head";
            this.lbl_head.Size = new System.Drawing.Size(217, 26);
            this.lbl_head.TabIndex = 1;
            this.lbl_head.Text = "Edit Category Details";
            // 
            // lbl_id_txt
            // 
            this.lbl_id_txt.AutoSize = true;
            this.lbl_id_txt.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_id_txt.Location = new System.Drawing.Point(97, 85);
            this.lbl_id_txt.Name = "lbl_id_txt";
            this.lbl_id_txt.Size = new System.Drawing.Size(22, 13);
            this.lbl_id_txt.TabIndex = 6;
            this.lbl_id_txt.Text = "Id :";
            // 
            // lbl_value
            // 
            this.lbl_value.AutoSize = true;
            this.lbl_value.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_value.Location = new System.Drawing.Point(97, 127);
            this.lbl_value.Name = "lbl_value";
            this.lbl_value.Size = new System.Drawing.Size(41, 13);
            this.lbl_value.TabIndex = 7;
            this.lbl_value.Text = "Name :";
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.IndianRed;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(504, 211);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(105, 30);
            this.btn_save.TabIndex = 11;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.IndianRed;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(384, 211);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(105, 30);
            this.btn_cancel.TabIndex = 12;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_id.Location = new System.Drawing.Point(147, 85);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(19, 13);
            this.lbl_id.TabIndex = 13;
            this.lbl_id.Text = "Id ";
            // 
            // txt_box
            // 
            this.txt_box.Location = new System.Drawing.Point(150, 124);
            this.txt_box.Name = "txt_box";
            this.txt_box.Size = new System.Drawing.Size(254, 20);
            this.txt_box.TabIndex = 14;
            // 
            // FormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(682, 277);
            this.Controls.Add(this.txt_box);
            this.Controls.Add(this.lbl_id);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.lbl_value);
            this.Controls.Add(this.lbl_id_txt);
            this.Controls.Add(this.lbl_head);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormEdit";
            this.Text = "FormEdit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_head;
        private System.Windows.Forms.Label lbl_id_txt;
        private System.Windows.Forms.Label lbl_value;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_id;
        private System.Windows.Forms.TextBox txt_box;
    }
}