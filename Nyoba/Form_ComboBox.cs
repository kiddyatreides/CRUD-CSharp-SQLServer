using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nyoba
{
    public partial class Form_ComboBox : Form
    {
        public Form_ComboBox()
        {
            InitializeComponent();
        }

        private int ValidateData()
        {
            int flag = 0;
            if (tb_nama.Text == "")
            {
                tb_nama.Focus();
                errorProvider1.SetError(tb_nama, "Please Fill in The Name");
                flag = 1;
            }
            if (cb_gaji.SelectedIndex == 0)
            {
                cb_gaji.Focus();
                errorProvider1.SetError(cb_gaji, "Please Fill in The Gaji");
                flag = 1;
            }
            return flag;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                if (ValidateData() == 0)
                {
                    Koneksi kon = new Koneksi();
                    SqlConnection sqlcon = kon.getConnection();
                    string msg = string.Empty;
                    using (sqlcon)
                    {
                        sqlcon.Open();
                        string sql = "insert into gajinasabah (nama, gaji) values( @nama, @gaji)";
                        SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                        using (sqlcom)
                        {
                            sqlcom.Parameters.AddWithValue("@nama", tb_nama.Text);
                            sqlcom.Parameters.AddWithValue("@gaji", cb_gaji.Text.ToString());
                            int res = sqlcom.ExecuteNonQuery();
                            msg = (res != 0 ? "Data has been saved." : "Oops, something went wrong.");
                        }
                        sqlcon.Close();
                    }
                    MessageBox.Show(msg);
                    //AutoGenerate();
                }
                else
                {
                    MessageBox.Show("Please Fix The Error");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
