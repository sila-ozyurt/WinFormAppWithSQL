using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ödevprojesi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            label5.Visible = false;
            textBox5.Visible = false;
            button1.Visible = false;
            button3.Visible = false;

            VerileriGoster("select* from Sefer_Listesi");

            Form1 form1 = new Form1();

            baglanti.Open();
            SqlCommand komut = new SqlCommand("select* from kullanicilar where telno like '" + form1.a + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                textBox1.Text = oku["ad"].ToString();
                textBox2.Text = oku["soyad"].ToString();
                textBox3.Text = oku["telno"].ToString();
                textBox4.Text = oku["sifre"].ToString();
            }
            baglanti.Close();
        }
        
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VV6EKJV;Initial Catalog=SEFERLER;Integrated Security=True");
        private void VerileriGoster(string data)
        {
            SqlDataAdapter da = new SqlDataAdapter(data, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];


        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select* from Sefer_Listesi  where KalkisYeri like '%" + comboBox1.Text + "%' AND VarisYeri like '%"+comboBox2.Text+"%'", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
              
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\GRUNDIG\Desktop\formprojem\kişi.jpg");                 
        }      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            label5.Visible = true;
            textBox5.Visible = true;
            button1.Visible = true;
            button3.Visible = true;
            label4.Text = "Yeni Şifre";

        }
        Kullanici user = new Kullanici();
        private void button1_Click(object sender, EventArgs e)
        {
            label5.Visible = true;
            textBox5.Visible = true;
            user.sifre(textBox1, textBox2, textBox3, textBox4, textBox5);
        }

        private void biletAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.a = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            form4.b = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            form4.c = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            form4.d = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            form4.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
