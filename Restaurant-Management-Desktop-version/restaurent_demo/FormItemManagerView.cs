using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurent_demo
{
    public partial class FormItemManagerView : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";
        String current;
        String imageLocation = "";

        String id;
        String name;
        String catagory;
        String description;
        String price;
        Image image;
        public FormItemManagerView(String item_id, String cur)
        {
            InitializeComponent();
            panel_update.Hide();
            panel_update.Location = new Point(0, 0);
            current = cur;
            if (current == "view")
            {
                panel_update.Hide();
                id = item_id;

                SqlConnection con = new SqlConnection(db);

                String query = "Select it.name,category.name,it.description,it.price,it.image from item as it inner join category on catid=category.id where it.id='" + id + "'";
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);


                DataTable dt = new DataTable();

                cmd.Fill(dt);

                name = dt.Rows[0][0].ToString();
                catagory = dt.Rows[0][1].ToString();
                description = dt.Rows[0][2].ToString();
                price = dt.Rows[0][3].ToString();
                //image= dt.Rows[0][0];
                try
                {
                    image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][4]));
                }
                catch (Exception ex)
                {

                }

                lbl_id.Text = id;
                lbl_name.Text = name;
                lbl_catagory.Text = catagory;
                lbl_description.Text = description;
                lbl_price.Text = price;
                pic_box.Image = image;
            }
            else
            {
                SqlConnection con1 = new SqlConnection(db);
                String query1 = "Select name from category";
                SqlDataAdapter cmd1 = new SqlDataAdapter(query1, con1);


                DataTable dt1 = new DataTable();

                cmd1.Fill(dt1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    comboBox_update_cat.Items.Add(dt1.Rows[i][0].ToString());
                }
                comboBox_update_cat.SelectedItem = dt1.Rows[0][0].ToString();


                lbl_head.Text = "Add Item";
                lbl_update_id.Hide();
                lbl_up_id.Hide();
                btn_chn_photo.Text = "Upload Photo";
                btn_update_save.Text = "Add";
                panel_update.Show();
                imageLocation = "";
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btn_chn_photo_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_cancel_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_save_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            lbl_head.Text = "Update Item Details";
            btn_chn_photo.Text = "Change Photo";
            btn_update_save.Text = "Save";
            lbl_update_id.Text = id;
            txt_update_name.Text = name;
            txt_update_price.Text = price;
            richTextBox_update_des.Text = description;
            pic_ch1.Image = image;

            SqlConnection con1 = new SqlConnection(db);
            String query1 = "Select name from category";
            SqlDataAdapter cmd1 = new SqlDataAdapter(query1, con1);


            DataTable dt1 = new DataTable();

            cmd1.Fill(dt1);
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                comboBox_update_cat.Items.Add(dt1.Rows[i][0].ToString());
            }
            comboBox_update_cat.SelectedItem = catagory;
            //pic_ch1.Image = image;

            imageLocation = "";
            panel_update.Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btn_update_cancel_Click_1(object sender, EventArgs e)
        {

            if (current == "view")
            {
                panel_update.Hide();
                imageLocation = "";
            }
            else this.DialogResult = DialogResult.OK;
        }

        private void btn_update_save_Click_1(object sender, EventArgs e)
        {
            if (current == "view")
            {
                String up_name = txt_update_name.Text;
                String up_price = txt_update_price.Text;
                String up_des = richTextBox_update_des.Text;
                if (up_name != "" && up_price != "" && up_des != "")
                {

                    SqlConnection con = new SqlConnection(db);
                    if (imageLocation == "")
                    {
                        String update_query = "update item set name = '" + up_name + "', description = '" + up_des + "', price = '" + up_price + "', catid = (select id from Category where Name = '" + comboBox_update_cat.SelectedItem.ToString() + "') where id ='" + id + "'";


                        SqlCommand cmd1 = new SqlCommand(update_query, con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();


                    }
                    else
                    {

                        String update_query = "update item set name =@item_name, description = @item_des, price =@item_price, catid = @cat_id, image=@item_image where id =@item_id";


                        SqlCommand cmd1 = new SqlCommand(update_query, con);


                        cmd1.Parameters.AddWithValue("@cat_id", getCatId(comboBox_update_cat.SelectedItem.ToString()));
                        cmd1.Parameters.AddWithValue("@item_name", up_name);

                        cmd1.Parameters.AddWithValue("@item_price", up_price);
                        cmd1.Parameters.AddWithValue("@item_des", up_des);
                        cmd1.Parameters.AddWithValue("@item_id", id);

                        FileInfo finfo = new FileInfo(imageLocation);

                        byte[] btImage = new byte[finfo.Length];
                        FileStream fStream = finfo.OpenRead();

                        fStream.Read(btImage, 0, btImage.Length);
                        fStream.Close();

                        SqlParameter imageParameter = new SqlParameter("@item_image", SqlDbType.Image);
                        imageParameter.Value = btImage;

                        cmd1.Parameters.Add(imageParameter);

                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                    String query = "Select it.name,category.name,it.description,it.price,it.image from item as it inner join category on catid=category.id where it.id='" + id + "'";
                    SqlDataAdapter cmd = new SqlDataAdapter(query, con);


                    DataTable dt = new DataTable();

                    cmd.Fill(dt);

                    name = dt.Rows[0][0].ToString();
                    catagory = dt.Rows[0][1].ToString();
                    description = dt.Rows[0][2].ToString();
                    price = dt.Rows[0][3].ToString();
                    image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][4]));

                    lbl_id.Text = id;
                    lbl_name.Text = name;
                    lbl_catagory.Text = catagory;
                    lbl_description.Text = description;
                    lbl_price.Text = price;
                    pic_box.Image = image;
                    panel_update.Hide();
                }

                else
                {
                    MessageBox.Show("Please insert image or fill name, price, description and select catagory to update item details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                String up_name = txt_update_name.Text;
                String up_price = txt_update_price.Text;
                String up_des = richTextBox_update_des.Text;
                String update_query = "";
                if (up_name != "" && up_price != "" && up_des != "" && imageLocation != "")
                {

                    SqlConnection con = new SqlConnection(db);

                    /* if (imageLocation == "")
                     {
                         update_query = "insert into item (catid,name,price,description) values ((select id from Category where name='" + comboBox_update_cat.SelectedItem.ToString() + "'),'" + up_name + "','" + up_price + "','" + up_des + "')";
                         SqlCommand cmd1 = new SqlCommand(update_query, con);

                         con.Open();
                         cmd1.ExecuteNonQuery();
                         con.Close();

                     }
                     else
                     {
                    */
                    update_query = "insert into item (catid,name,price,description,image) values (@cat_id, @item_name, @item_price, @item_des, @item_image)";
                    SqlCommand cmd1 = new SqlCommand(update_query, con);

                    cmd1.Parameters.AddWithValue("@cat_id", getCatId(comboBox_update_cat.SelectedItem.ToString()));
                    cmd1.Parameters.AddWithValue("@item_name", up_name);

                    cmd1.Parameters.AddWithValue("@item_price", up_price);
                    cmd1.Parameters.AddWithValue("@item_des", up_des);

                    FileInfo finfo = new FileInfo(imageLocation);

                    byte[] btImage = new byte[finfo.Length];
                    FileStream fStream = finfo.OpenRead();

                    fStream.Read(btImage, 0, btImage.Length);
                    fStream.Close();

                    SqlParameter imageParameter = new SqlParameter("@item_image", SqlDbType.Image);
                    imageParameter.Value = btImage;

                    cmd1.Parameters.Add(imageParameter);


                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                    // }


                    current = "view";


                    String query = "Select it.id,it.name,category.name,it.description,it.price,it.image from item as it inner join category on catid=category.id where it.name='" + up_name + "' and category.name='" + comboBox_update_cat.SelectedItem.ToString() + "' and it.description='" + up_des + "' and it.price='" + up_price + "'";
                    SqlDataAdapter cmd = new SqlDataAdapter(query, con);


                    DataTable dt = new DataTable();

                    cmd.Fill(dt);
                    id = dt.Rows[0][0].ToString();
                    name = dt.Rows[0][1].ToString();
                    catagory = dt.Rows[0][2].ToString();
                    description = dt.Rows[0][3].ToString();
                    price = dt.Rows[0][4].ToString();
                    //image= dt.Rows[0][0];
                    image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][5]));

                    lbl_id.Text = id;
                    lbl_name.Text = name;
                    lbl_catagory.Text = catagory;
                    lbl_description.Text = description;
                    lbl_price.Text = price;
                    pic_box.Image = image;
                    panel_update.Hide();
                }
                else
                {
                    MessageBox.Show("Please insert image and fill name, price, description and select catagory to add item.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            //pic_box.Image = image;
        }

        private void btn_chn_photo_Click_1(object sender, EventArgs e)
        {
            imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.InitialDirectory = "c:\\";
                //dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| All Files(*.*)|*.*|";
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;
                    pic_ch1.ImageLocation = imageLocation;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("An Error Occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private String getCatId(String s)
        {
            String query = "select id from Category where name='" + s + "'";
            SqlConnection con = new SqlConnection(db);
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            cmd.Fill(dt);
            return dt.Rows[0][0].ToString();
        }
    }
}
