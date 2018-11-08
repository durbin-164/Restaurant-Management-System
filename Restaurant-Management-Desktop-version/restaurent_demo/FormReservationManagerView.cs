using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class FormReservationManagerView : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";

        public FormReservationManagerView(String cart_id)
        {
            InitializeComponent();

            SqlConnection con = new SqlConnection(db);

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
            for (int i = 0; i < dt2.Columns.Count; i++)
            {
                Debug.WriteLine("i=" + i + " value=" + dt2.Rows[0][i].ToString());
            }
            lbl_cart_id.Text = dt2.Rows[0][0].ToString();
            lbl_cart_date.Text = dt2.Rows[0][1].ToString();
            lbl_cart_st.Text = dt2.Rows[0][2].ToString();
            lbl_cart_et.Text = dt2.Rows[0][3].ToString();
            lbl_cart_status.Text = dt2.Rows[0][4].ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
