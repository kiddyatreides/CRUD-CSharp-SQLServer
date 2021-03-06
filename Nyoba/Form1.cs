﻿using System;
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
    public partial class Form1 : Form
    {
        Koneksi conn = new Koneksi();

        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'cCITFTUIDataSet.kontak' table. You can move, or remove it, as needed.
            loadTable();
            tb_id.Text = generateID();
            tb_id.Enabled = false;
            //this.reportViewer1.RefreshReport();
        }

        protected string generateID()
        {
            string sID = null;
            int ID = 0;
            Koneksi kon = new Koneksi();
            SqlConnection sqlconn = kon.getConnection();
            sqlconn.Open();
            DataTable dt = new DataTable();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select TOP 1 id from nasabah order by id DESC", sqlconn);
            myReader = myCommand.ExecuteReader();

            if (myReader.Read())
            {
                sID = (myReader["id"].ToString());
                ID = Convert.ToInt32(sID.Substring(1, 3));
                ID += 1;
                if (ID <= 9)
                {
                    sID = "N00" + ID;
                }
                else if (ID <= 90)
                {
                    sID = "N0" + ID;
                }
                else if (ID <= 900)
                {
                    sID = "N" + ID;
                }
            }
            else
            {
                sID = "N001";
            }
            sqlconn.Close();
            return sID;

        }

        private void loadTable()
        {
            try
            {
                Koneksi kon = new Koneksi();
                SqlConnection sqlcon = kon.getConnection();
                string sql = "select * from nasabah;";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcom;
                DataTable dTable = new DataTable();
                sqlda.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private int ValidateData()
        {
            int flag = 0;
            if (tb_id.Text == "")
            {
                tb_id.Focus();
                errorProvider1.SetError(tb_id, "Please Fill in The ID");
                flag = 1;
            }
            if (tb_nama.Text == "")
            {
                tb_nama.Focus();
                errorProvider1.SetError(tb_nama, "Please Fill in The Name");
                flag = 1;
            }
            if (tb_alamat.Text == "")
            {
                tb_alamat.Focus();
                errorProvider1.SetError(tb_alamat, "Please Fill in The Address");
                flag = 1;
            }
            if (tb_usia.Text == "")
            {
                tb_usia.Focus();
                errorProvider1.SetError(tb_usia, "Please Fill in The Age");
                flag = 1;
            }
            if (tb_nohp.Text == "")
            {
                tb_nohp.Focus();
                errorProvider1.SetError(tb_nohp, "Please Fill in The Phone Number");
                flag = 1;
            }
            return flag;
        }

        
        private void ClearForm()
        {
            try
            {
                tb_id.Enabled = false;
                btn_add.Enabled = true;
                tb_id.Text = null;
                tb_nama.Text = null;
                tb_usia.Text = null;
                tb_alamat.Text = null;
                tb_nohp.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
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
                        string sql = "insert into nasabah (id, nama, nohp, alamat, usia) values( @id, @nama, @nohp, @alamat, @usia)";
                        SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                        using (sqlcom)
                        {
                            sqlcom.Parameters.AddWithValue("@id", tb_id.Text.ToString());
                            sqlcom.Parameters.AddWithValue("@nama", tb_nama.Text);
                            sqlcom.Parameters.AddWithValue("@nohp", tb_nohp.Text);
                            sqlcom.Parameters.AddWithValue("@alamat", tb_alamat.Text);
                            sqlcom.Parameters.AddWithValue("@usia", tb_usia.Text.ToString());
                            int res = sqlcom.ExecuteNonQuery();
                            msg = (res != 0 ? "Data has been saved." : "Oops, something went wrong.");
                        }
                        sqlcon.Close();
                    }
                    MessageBox.Show(msg);
                    loadTable();
                    ClearForm();
                    tb_id.Text = generateID();
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

        private void btn_reset_Click(object sender, EventArgs e)
        {
            ClearForm();
            tb_id.Text = generateID();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi kon = new Koneksi();
                SqlConnection sqlcon = kon.getConnection();
                //string sql = "select * from nasabah where id = '" + tb_search.Text + "';";
                string sql = "select * from nasabah where nama like '%" + tb_search.Text + "%';";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                SqlDataAdapter sqlda = new SqlDataAdapter();
                sqlda.SelectCommand = sqlcom;
                DataTable dTable = new DataTable();
                sqlda.Fill(dTable);
                dataGridView1.DataSource = dTable; // here i have assign dTable object to the dataGridView1 object to display data.               
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    string id = row.Cells[0].Value.ToString();
                    string name = row.Cells[1].Value.ToString();
                    string alamat = row.Cells[2].Value.ToString();
                    string nohp = row.Cells[3].Value.ToString();
                    string usia = row.Cells[4].Value.ToString();

                    tb_id.Text = id;
                    tb_nama.Text = name;
                    tb_nohp.Text = nohp;
                    tb_usia.Text = usia;
                    tb_alamat.Text = alamat;

                    btn_add.Enabled = false;
                    tb_id.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                        string sql = "update nasabah set nama = @name, nohp = @nohp, alamat = @alamat, usia = @usia where id = @id";
                        SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                        using (sqlcom)
                        {
                            sqlcom.Parameters.AddWithValue("@id", tb_id.Text.ToString());
                            sqlcom.Parameters.AddWithValue("@name", tb_nama.Text);
                            sqlcom.Parameters.AddWithValue("@nohp", tb_nohp.Text.ToString());
                            sqlcom.Parameters.AddWithValue("@alamat", tb_alamat.Text);
                            sqlcom.Parameters.AddWithValue("@usia", tb_usia.Text.ToString());
                            int res = sqlcom.ExecuteNonQuery();
                            msg = (res != 0 ? "Data has been updated." : "Oops, something went wrong.");
                        }
                        sqlcon.Close();
                    }
                    MessageBox.Show(msg);
                    ClearForm();
                    loadTable();
                    tb_id.Text = generateID();
                }
                else
                {
                    MessageBox.Show("Please Fix The Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Koneksi kon = new Koneksi();
            SqlConnection sqlcon = kon.getConnection();
            string msg = string.Empty;
            using (sqlcon)
            {
                sqlcon.Open();
                string sql = "delete from nasabah where id = @id";
                SqlCommand sqlcom = new SqlCommand(sql, sqlcon);
                using (sqlcon)
                {
                    sqlcom.Parameters.AddWithValue("@id", tb_id.Text);
                    int res = sqlcom.ExecuteNonQuery();
                    msg = (res != 0 ? "Data has been deleted " : "Oops, something went wrong");

                }
                sqlcon.Close();
            }
            MessageBox.Show(msg);
            ClearForm();
            loadTable();
            tb_id.Text = generateID();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 move = new Form2();
            move.Show();
            
        }
    }
}
