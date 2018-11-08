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
    public partial class FormEdit : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";
        String query;
        String current,id,type;
        public FormEdit(String Id,String cur,String t)
        {
            InitializeComponent();
            current = cur;
            id = Id;
            type = t;
            if (type == "view")
            {
                if (current == "category")
                {
                    query = "Select name from category where id='" + id + "'";

                }
                else if(current=="table")
                {
                    lbl_head.Text = "Edit Table Details";
                    lbl_value.Text = "Capacity";
                    query = "Select capacity from table_details where table_id='" + id + "'";

                }
                else
                {
                    lbl_head.Text = "Edit Ingrediant Name";
                    query = "Select name from ingradients where ing_id='" + id + "'";
                }

                SqlConnection con = new SqlConnection(db);
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();

                cmd.Fill(dt);
                lbl_id.Text = id;
                txt_box.Text = dt.Rows[0][0].ToString();
            }
            else
            {

                lbl_id.Hide();
                lbl_id_txt.Hide();


                btn_save.Text = "Add";
                if (current == "category")
                {
                    lbl_head.Text = "Add Catagory";
                }
                else if (current == "table") { lbl_head.Text = "Add Table"; lbl_value.Text = "Capacity"; }
                else lbl_head.Text = "Add Ingradients";
                
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            String value = txt_box.Text;
            if (type == "view")
            {
                
                if (current == "category")
                {
                    if (value != "") query = "update category set name='" + value + "' where id='" + id + "'";

                }
                else if(current=="table")
                {
                    if (value != "") query = "update table_details set capacity='" + value + "' where table_id='" + id + "'";

                }
                else
                {
                    if (value != "") query = "update ingradients set name='" + value + "' where ing_id='" + id + "'";

                }


            }
            else
            {
                if (current == "category")
                {
                    if (value != "") query = "insert into category(name) values ('" + value + "')";
                    


                }
                else if(current=="table")
                {
                    if (value != "") query = "insert into table_details(capacity) values('" + value + "')";
                    
                }
                else
                {
                    if (value != "") query = "insert into ingradients(name,quentity) values('" + value + "','0.000')";

                }
            }
            if (value != "")
            {
                SqlConnection con = new SqlConnection(db);
                SqlCommand cmd1 = new SqlCommand(query, con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }

            this.DialogResult = DialogResult.OK;


        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
