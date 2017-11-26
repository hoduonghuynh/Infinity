using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Ketnoimaytinh
{
    public partial class QLCSDL : Form
    {
        SqlConnection con;
        public QLCSDL()
        {
            InitializeComponent();
        }

        private void QLCSDL_Load(object sender, EventArgs e)
        {
            string connectionString = null;
            connectionString = @"Data Source=DESKTOP-573U9KU\SQLCHO;Initial Catalog=DataTiemPhong;Integrated Security=True";
            con = new SqlConnection(connectionString);
            con.Open();
            Hienthi();
        }

        private void QLCSDL_FormClosing(object sender, FormClosingEventArgs e)
        {

            con.Close();
        }
        public void Hienthi()
        {
            string sqSELECT = "SELECT *FROM Data";
            SqlCommand cmd = new SqlCommand(sqSELECT, con);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataCho.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sqlTiemkiem = "SELECT *FROM Data WHERE Ngaytiemcuoi=@Ngaytiemcuoi";
            SqlCommand cmd = new SqlCommand(sqlTiemkiem, con);
            cmd.Parameters.AddWithValue("Ngaytiemcuoi", textBox1.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataCho.DataSource = dt;
        }

        public object UID { get; set; }

        private void dataCho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
