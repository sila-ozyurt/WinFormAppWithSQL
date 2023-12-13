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
using System.Configuration;



namespace ödevprojesi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
           InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VV6EKJV;Initial Catalog=SEFERLER;Integrated Security=True");


        private void VerileriGoster(string data)
        {
            SqlDataAdapter da = new SqlDataAdapter(data,baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];


        }
        private void Form3_Load(object sender, EventArgs e)
        {
            VerileriGoster("Select* from Sefer_Listesi");
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }
        private void seferlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
        }
        private void seferÇıkarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            button3.Enabled = false;
            button4.Enabled = true;
        }
        private void seferGüncelleToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = true;
        }
        private void seferÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }    

        private void seferGüncelleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            splitContainer1.Visible = true;
            button3.Enabled = true;
        }
        private void Temizle()
        {
            textBox4.Clear();
            textBox1.Clear();
            comboBox1.Text="";
            comboBox2.Text="";
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //dateTimePicker1.CustomFormat = " ";
            dateTimePicker1.Text = "";
            textBox2.Clear();
            textBox3.Clear();
            comboBox3.Text = "";
            textBox4.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != comboBox2.Text)
                {
                    splitContainer1.Visible = true;
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Sefer_Listesi (SeferNo,Plaka,KalkisYeri,VarisYeri,Tarih,Saat,Fiyat,Sofor) values('" + textBox4.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox3.Text + "')", baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("kayıt eklendi");
                    VerileriGoster("select* from Sefer_Listesi");
                    baglanti.Close();
                    Temizle();
                }
                else
                {
                    MessageBox.Show("kalkış yeri ve varış yeri aynı seçilemez");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("aynı seferno numarasına sahip birden fazla sefer bulunamaz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from Sefer_Listesi where SeferNo=@seferno", baglanti);
            komut.Parameters.AddWithValue("@seferno", textBox4.Text);
            komut.ExecuteNonQuery();
            VerileriGoster("select* from Sefer_Listesi");
            baglanti.Close();
            Temizle();
        }

        private void seçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Sefer_Listesi set plaka='" + textBox1.Text + "',kalkisyeri='" + comboBox1.Text + "',varisyeri='" + comboBox2.Text + "',tarih='" + dateTimePicker1.Text + "',saat='" + textBox2.Text + "',fiyat='" + textBox3.Text + "',sofor='" + comboBox3.Text + "' where seferno='" + textBox4.Text + "'", baglanti);
            komut.ExecuteNonQuery();
            VerileriGoster("select* from Sefer_Listesi");
            baglanti.Close();
            Temizle();
        }
                                                                 

       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secili_alan = dataGridView1.SelectedCells[0].RowIndex;

            string seferno = dataGridView1.Rows[secili_alan].Cells[0].Value.ToString();
            string plaka = dataGridView1.Rows[secili_alan].Cells[1].Value.ToString();
            string kalkisyeri = dataGridView1.Rows[secili_alan].Cells[2].Value.ToString();
            string varisyeri = dataGridView1.Rows[secili_alan].Cells[3].Value.ToString();
            string tarih = dataGridView1.Rows[secili_alan].Cells[4].Value.ToString();
            string saat = dataGridView1.Rows[secili_alan].Cells[5].Value.ToString();
            string fiyat = dataGridView1.Rows[secili_alan].Cells[6].Value.ToString();
            string sofor = dataGridView1.Rows[secili_alan].Cells[7].Value.ToString();


            textBox4.Text = seferno;
            textBox1.Text = plaka;
            comboBox1.Text = kalkisyeri;
            comboBox2.Text = varisyeri;
            dateTimePicker1.Text = tarih;
            textBox2.Text = saat;
            textBox3.Text = fiyat;
            comboBox3.Text = sofor;
        }

      

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Temizle();
        }

       
    }
}

