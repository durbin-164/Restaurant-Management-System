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
    public partial class FormReserveStaff : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";
        String cart;
        public FormReserveStaff(String cart_id)
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(db);
            cart = cart_id;

            String query = "Select * from table_cart_make where table_cart_id='" + cart_id + "'";
            //String query = "Select * From Order_details";// where cart_id='" + cart_id + "'";

            SqlDataAdapter cmd = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();

            cmd.Fill(dt);
            dataGridView1.DataSource = dt;

            String query1 = "Select id,name,email,phone,address from customer inner join table_cart_make on customer_id=id where table_cart_id='" + cart_id + "'";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query1, con);
            DataTable dt1 = new DataTable();
            cmd1.Fill(dt1);
            lbl_cus_id.Text = dt1.Rows[0][0].ToString();
            lbl_cus_name.Text = dt1.Rows[0][1].ToString();
            lbl_cus_email.Text = dt1.Rows[0][2].ToString();
            lbl_cus_num.Text = dt1.Rows[0][3].ToString();
            lbl_cus_add.Text = dt1.Rows[0][4].ToString();

            String query2 = "Select table_cart_id,date,start_time,end_time,status from table_cart_make where table_cart_id='" + cart_id + "'";
            SqlDataAdapter cmd2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            cmd2.Fill(dt2);
            
            lbl_cart_id.Text = dt2.Rows[0][0].ToString();
            lbl_cart_date.Text = dt2.Rows[0][1].ToString();
            lbl_cart_st.Text = dt2.Rows[0][2].ToString();
            lbl_cart_et.Text = dt2.Rows[0][3].ToString();


            comboBox1.Items.Add("Pending");
            comboBox1.Items.Add("Accepted");
            comboBox1.Items.Add("Canceled");
            comboBox1.Items.Add("Arraived");
            comboBox1.SelectedItem = dt2.Rows[0][4].ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(db);
            try
            {
                String query = "update table_cart_make set status='" + comboBox1.SelectedItem.ToString() + "' where table_cart_id='" + cart + "'";


                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Successful");
            }
            catch (Exception)
            {

                MessageBox.Show("Can not update the status");
            }



            String query2 = "Select table_cart_id,date,start_time,end_time,status from table_cart_make where table_cart_id='" + cart + "'";
            SqlDataAdapter cmd2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            cmd2.Fill(dt2);

            lbl_cart_id.Text = dt2.Rows[0][0].ToString();
            lbl_cart_date.Text = dt2.Rows[0][1].ToString();
            lbl_cart_st.Text = dt2.Rows[0][2].ToString();
            lbl_cart_et.Text = dt2.Rows[0][3].ToString();


            comboBox1.SelectedItem = dt2.Rows[0][3].ToString();
        }

    }
}
