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
    public partial class FormStaffDetails : Form
    {
        String db = "data source = (local)\\SQLEXPRESS;database=Restaurant;Integrated Security =SSPI";
        String current;
        String id, name, age, sex, email, pass, phone, address;
        String imageLocation = "";

        Image image;
        public FormStaffDetails(String Id, String cur)
        {
            InitializeComponent();
            current = cur;
            if (current == "view")
            {
                id = Id;
                panel_update.Hide();

                
                SqlConnection con = new SqlConnection(db);

                String query = "Select employee_name,age,sex,email,password,phone,adress,image from employee where employee_id='" + id + "'";
                SqlDataAdapter cmd = new SqlDataAdapter(query, con);


                DataTable dt = new DataTable();

                cmd.Fill(dt);
                name = dt.Rows[0][0].ToString();
                age = dt.Rows[0][1].ToString();
                sex = dt.Rows[0][2].ToString();
                email = dt.Rows[0][3].ToString();
                pass = dt.Rows[0][4].ToString();
                phone = dt.Rows[0][5].ToString();
                address = dt.Rows[0][6].ToString();
                try
                {
                    image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][7]));
                }
                catch(Exception e)
                {
                    
                }



                lbl_id.Text = id;
                lbl_name.Text = name;
                lbl_age.Text = age;
                lbl_sex.Text = sex;
                lbl_email.Text = email;
                lbl_pass.Text = pass;
                lbl_phone.Text = phone;
                lbl_address.Text = address;
                pic_box.Image = image;
                comboBox_sex.Items.Add("Male");
                comboBox_sex.Items.Add("Female");
                comboBox_sex.SelectedItem = "Male";
            }
            else
            {
                lbl_head.Text = "ADD STAFF";

                comboBox_sex.Items.Add("Male");
                comboBox_sex.Items.Add("Female");


                comboBox_sex.SelectedItem = "Male";
                lbl_update_id.Hide();
                lbl_up_id.Hide();
                btn_chn_photo.Text = "Upload Photo";
                btn_update_save.Text = "Add";
                imageLocation = "";

                panel_update.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
        private void btn_update_save_Click(object sender, EventArgs e)
        {
            if (current == "view")
            {

                String up_name, up_age, up_email, up_pass, up_phone, up_address;
                up_name = txt_update_name.Text;
                up_age = txt_update_age.Text;
                up_email = txt_update_email.Text;
                up_pass = txt_update_pass.Text;
                up_phone = txt_update_phone.Text;
                up_address = txt_update_address.Text;
                if (up_name != "" && up_age != "" && up_email != "" && up_pass != "" && up_phone != "" && up_address != "")
                {
                    SqlConnection con = new SqlConnection(db);
                    if (imageLocation == "")
                    {
                        String update_query = "update employee set employee_name = '" + up_name + "', age = '" + up_age + "', email = '" + up_email + "', password = '" + up_pass + "', phone = '" + up_phone + "', adress = '" + up_address + "', sex = '" + comboBox_sex.SelectedItem.ToString() + "') where employee_id ='" + id + "'";



                        SqlCommand cmd1 = new SqlCommand(update_query, con);
                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        String update_query = "update employee set employee_name =@emp_name, age =@emp_age, email =@email, password =@password, phone =@phone, adress =@address, sex =@sex, image=@image where employee_id =@employee_id";

                        //SqlConnection con = new SqlConnection(db);

                        SqlCommand cmd1 = new SqlCommand(update_query, con);

                        cmd1.Parameters.AddWithValue("@emp_name", up_name);
                        cmd1.Parameters.AddWithValue("@emp_age", up_age);

                        cmd1.Parameters.AddWithValue("@email", up_email);
                        cmd1.Parameters.AddWithValue("@password", up_pass);
                        cmd1.Parameters.AddWithValue("@phone", up_phone);
                        cmd1.Parameters.AddWithValue("@address", up_address);

                        cmd1.Parameters.AddWithValue("@sex", comboBox_sex.SelectedItem.ToString());

                        cmd1.Parameters.AddWithValue("@employee_id", id);

                        FileInfo finfo = new FileInfo(imageLocation);

                        byte[] btImage = new byte[finfo.Length];
                        FileStream fStream = finfo.OpenRead();

                        fStream.Read(btImage, 0, btImage.Length);
                        fStream.Close();

                        SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                        imageParameter.Value = btImage;

                        cmd1.Parameters.Add(imageParameter);

                        con.Open();
                        cmd1.ExecuteNonQuery();
                        con.Close();
                    }
                    String query = "Select employee_name,age,sex,email,password,phone,adress,image from employee where employee_id='" + id + "'";
                    SqlDataAdapter cmd = new SqlDataAdapter(query, con);


                    DataTable dt = new DataTable();

                    cmd.Fill(dt);
                    name = dt.Rows[0][0].ToString();
                    age = dt.Rows[0][1].ToString();
                    sex = dt.Rows[0][2].ToString();
                    email = dt.Rows[0][3].ToString();
                    pass = dt.Rows[0][4].ToString();
                    phone = dt.Rows[0][5].ToString();
                    address = dt.Rows[0][6].ToString();
                    try
                    {
                        image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][7]));
                    }
                    catch(Exception ex)
                    {

                    }


                    lbl_id.Text = id;
                    lbl_name.Text = name;
                    lbl_age.Text = age;
                    lbl_sex.Text = sex;
                    lbl_email.Text = email;
                    lbl_pass.Text = pass;
                    lbl_phone.Text = phone;
                    lbl_address.Text = address;
                    pic_box.Image = image;

                    panel_update.Hide();

                }
            }
            else
            {
                String up_name, up_age, up_email, up_pass, up_phone, up_address;
                up_name = txt_update_name.Text;
                up_age = txt_update_age.Text;
                up_email = txt_update_email.Text;
                up_pass = txt_update_pass.Text;
                up_phone = txt_update_phone.Text;
                up_address = txt_update_address.Text;
                if (up_name != "" && up_age != "" && up_email != "" && up_pass != "" && up_phone != "" && up_address != "" && imageLocation != "")
                {
                    String update_query = "insert into employee (type_id,employee_name, age, email, password, phone, adress, sex, image) values (@type_id, @emp_name, @emp_age, @email, @password, @phone, @address, @sex, @image)";

                    SqlConnection con = new SqlConnection(db);

                    SqlCommand cmd1 = new SqlCommand(update_query, con);


                    cmd1.Parameters.AddWithValue("@emp_name", up_name);
                    cmd1.Parameters.AddWithValue("@emp_age", up_age);

                    cmd1.Parameters.AddWithValue("@email", up_email);
                    cmd1.Parameters.AddWithValue("@password", up_pass);
                    cmd1.Parameters.AddWithValue("@phone", up_phone);
                    cmd1.Parameters.AddWithValue("@address", up_address);

                    cmd1.Parameters.AddWithValue("@sex", comboBox_sex.SelectedItem.ToString());

                    cmd1.Parameters.AddWithValue("@type_id", getType());

                    FileInfo finfo = new FileInfo(imageLocation);

                    byte[] btImage = new byte[finfo.Length];
                    FileStream fStream = finfo.OpenRead();

                    fStream.Read(btImage, 0, btImage.Length);
                    fStream.Close();

                    SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                    imageParameter.Value = btImage;

                    cmd1.Parameters.Add(imageParameter);

                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    String query = "Select employee_id,employee_name,age,sex,email,password,phone,adress,image from employee where employee_name='" + up_name + "' and age='" + up_age + "' and sex='" + comboBox_sex.SelectedItem.ToString() + "' and email='" + up_email + "' and password='" + up_pass + "'and phone='" + up_phone + "' and adress='" + up_address + "'";
                    SqlDataAdapter cmd = new SqlDataAdapter(query, con);


                    DataTable dt = new DataTable();

                    cmd.Fill(dt);
                    id = dt.Rows[0][0].ToString();
                    name = dt.Rows[0][1].ToString();
                    age = dt.Rows[0][2].ToString();
                    sex = dt.Rows[0][3].ToString();
                    email = dt.Rows[0][4].ToString();
                    pass = dt.Rows[0][5].ToString();
                    phone = dt.Rows[0][6].ToString();
                    address = dt.Rows[0][7].ToString();
                    try
                    {
                        image = Image.FromStream(new MemoryStream((byte[])dt.Rows[0][8]));
                    }
                    catch(Exception ex)
                    {

                    }


                    lbl_id.Text = id;
                    lbl_name.Text = name;
                    lbl_age.Text = age;
                    lbl_sex.Text = sex;
                    lbl_email.Text = email;
                    lbl_pass.Text = pass;
                    lbl_phone.Text = phone;
                    lbl_address.Text = address;
                    pic_box.Image = image;

                    imageLocation = "";
                    current = "view";
                    panel_update.Hide();

                }
            }
        }
        private void btn_back_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            btn_chn_photo.Text = "Change Photo";
            btn_update_save.Text = "Save";
            lbl_head.Text = "Update Staff Details";

            lbl_update_id.Text = id;
            txt_update_name.Text = name;
            txt_update_age.Text = age;
            txt_update_email.Text = email;
            txt_update_pass.Text = pass;
            txt_update_phone.Text = phone;
            txt_update_address.Text = address;

            comboBox_sex.SelectedItem = sex;
            imageLocation = "";
            panel_update.Show();

        }

        private void btn_chn_photo_Click(object sender, EventArgs e)
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

        private void btn_update_cancel_Click(object sender, EventArgs e)
        {

            if (current == "view")
            {
                panel_update.Hide();
                imageLocation = "";
            }
            else this.DialogResult = DialogResult.OK;
        }
        private String getType()
        {
            String query = "select type_id from employee_type where type_name = 'Staff'";
            SqlConnection con = new SqlConnection(db);
            SqlDataAdapter cmd = new SqlDataAdapter(query, con);


            DataTable dt = new DataTable();

            cmd.Fill(dt);
            return dt.Rows[0][0].ToString();
        }
    }
}
