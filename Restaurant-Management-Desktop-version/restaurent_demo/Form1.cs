using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class Form1 : Form
    {
        private String user;

        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";

        public Form1()
        {
            InitializeComponent();

            

            panel_head.BackColor = Color.FromArgb(77, 77, 51);
            panel_welcome.BackColor = Color.FromArgb(153, 153, 102);
            panel_login.BackColor = Color.FromArgb(153, 153, 102);
            label_wel.Text = "WELCOME";
            label_wel.Font = new Font("Arial", 24, FontStyle.Bold);
            label_res.ForeColor = Color.FromArgb(255, 77, 77);
            label_res.Text = "TEN 11";
            label_res.Font = new Font("Arial", 40, FontStyle.Bold);
            label_user.Font = new Font("Arial", 20, FontStyle.Regular);
            panel_welcome.Visible = true;
            panel_login.Visible = false;
        }

        private void btn_man_log_Click(object sender, EventArgs e)
        {
            user = "Manager";
            label_user.Text = user+" Login";
            panel_login.Visible = true;
            //panel_welcome.Visible = false;
            txt_email.Text = "";
            txt_pass.Text = "";
        }

        private void panel_welcome_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_staff_log_Click(object sender, EventArgs e)
        {
            user = "Staff";
            label_user.Text = user+" Login";
            panel_login.Visible = true;
            //panel_welcome.Visible = false;
            txt_email.Text = "";
            txt_pass.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);
            String email = txt_email.Text;

            String query = "Select Count(*) from employee inner join employee_type on employee.type_id=employee_type.type_id where Email='"+ email+"' and Password='"+txt_pass.Text+"' and employee_type.type_name='"+user+"'";
            SqlDataAdapter cmd = new SqlDataAdapter(query,con);

            
            DataTable dt = new DataTable();

            cmd.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1") {
                query = "Select employee_id from employee inner join employee_type on employee.type_id=employee_type.type_id where Email='" + email + "' and Password='" + txt_pass.Text + "' and employee_type.type_name='" + user + "'";
                SqlDataAdapter cmd1 = new SqlDataAdapter(query, con);


                 dt = new DataTable();

                cmd1.Fill(dt);
                this.Hide();
            if (user == "Staff") (new FormStaff(dt.Rows[0][0].ToString())).ShowDialog();
            else (new FormItems(dt.Rows[0][0].ToString())).ShowDialog();
            this.Show();
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            //panel_welcome.Visible = true;
            panel_login.Visible = false;
            
        }

        private void panel_login_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
