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
using System.Media;

namespace ödevprojesi
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VV6EKJV;Initial Catalog=SEFERLER;Integrated Security=True");

        private void Temizle()
        {
            textBox3.Text="";
            textBox4.Text="";
            textBox2.Text="";
            textBox5.Text="";
            textBox6.Text="";
            textBox7.Text="";
            textBox8.Text="";
            textBox9.Text="";
            comboBox1.Text="";
        }
        private void VerileriGoster(string data)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select* from Biletim";
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["SeferNo"].ToString();
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Saat"].ToString());
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["TelNo"].ToString());
                ekle.SubItems.Add(oku["KoltukNo"].ToString());
                ekle.SubItems.Add(oku["Ucret"].ToString());
                ekle.SubItems.Add(oku["Cinsiyet"].ToString());
                listView1.Items.Add(ekle);
            }
            oku.Close();
            baglanti.Close();
        }
        private void button27_Click(object sender, EventArgs e)
        {
            try
            {

                if (comboBox1.Text != "" && textBox3.Text!="" && textBox4.Text != "" && textBox2.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {
                    listView1.Items.Clear();
                    baglanti.Open();
                    SqlCommand komut = new SqlCommand("insert into Biletim (SeferNo,Tarih,Saat,Ad,Soyad,TelNo,KoltukNo,Ucret,Cinsiyet) values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox1.Text + "')", baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("kayıt eklendi");
                    baglanti.Close();
                    VerileriGoster("select* from Biletim");
                    if (comboBox1.Text == "Kadın")
                    {
                        System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                        ses.SoundLocation = "C:\\Users\\GRUNDIG\\Desktop\\formprojem\\kadınanons.wav";
                        ses.Play();
                    }
                    else if (comboBox1.Text == "Erkek")
                    {
                        System.Media.SoundPlayer ses = new System.Media.SoundPlayer();
                        ses.SoundLocation = "C:\\Users\\GRUNDIG\\Desktop\\formprojem\\erkekanons.wav";
                        ses.Play();
                    }
                    Temizle();
                }
                else
                {
                    MessageBox.Show("herhangi bir alan boş bırakılamaz");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("lutfen seçili koltukları seçmeyin");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand();        
            komut.CommandText = "delete from Biletim where Ad='" + textBox5.Text + "' AND Soyad='" + textBox6.Text + "'";
            komut.Connection = baglanti;
            komut.ExecuteNonQuery();
            baglanti.Close();
            VerileriGoster("select* from Biletim");
            Temizle();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = ("update Biletim set SeferNo='" + textBox3.Text + "',Tarih='" + textBox4.Text + "',Saat='" + textBox2.Text + "',TelNo='" + textBox7.Text + "',KoltukNo='" + textBox8.Text + "',Ucret='" + textBox9.Text + "',Cinsiyet='" + comboBox1.Text + "' where Ad='" + textBox5.Text + "' AND Soyad='" + textBox6.Text + "'");
            komut.ExecuteNonQuery();
            baglanti.Close();
            VerileriGoster("select* from Biletim");
            Temizle();
        }

                                                                                                 
        public string a, b, c, d;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("şoför koltuğudur seçilemez");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox8.Text = "2";
            button2.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button2.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button2.BackColor = Color.Pink;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox8.Text = "3";
            button3.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button3.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button3.BackColor = Color.Pink;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox8.Text = "4";
            button4.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button4.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button4.BackColor = Color.Pink;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox8.Text = "5";
            button5.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button5.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button5.BackColor = Color.Pink;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox8.Text = "6";
            button6.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button6.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button6.BackColor = Color.Pink;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox8.Text = "7";
            button7.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button7.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button7.BackColor = Color.Pink;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox8.Text = "8";
            button8.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button8.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button8.BackColor = Color.Pink;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox8.Text = "9";
            button9.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button9.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button9.BackColor = Color.Pink;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            textBox8.Text = "10";
            button10.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button10.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın") 
            {
                button10.BackColor = Color.Pink;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textBox8.Text = "11";
            button11.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button11.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button11.BackColor = Color.Pink;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            textBox8.Text = "12";
            button12.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button12.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button12.BackColor = Color.Pink;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox8.Text = "13";
            button13.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button13.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button13.BackColor = Color.Pink;
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            textBox8.Text = "14";
            button14.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button14.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button14.BackColor = Color.Pink;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox8.Text = "15";
            button15.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button15.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button15.BackColor = Color.Pink;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox8.Text = "16";
            button16.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button16.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button16.BackColor = Color.Pink;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            textBox8.Text = "17";
            button17.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button17.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button17.BackColor = Color.Pink;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            textBox8.Text = "18";
            button18.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button18.BackColor = Color.Blue;
            }
            else if(comboBox1.Text == "Kadın")
            {
                button18.BackColor = Color.Pink;
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox8.Text = "19";
            button19.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button19.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button19.BackColor = Color.Pink;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            textBox8.Text = "20";
            button20.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button20.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button20.BackColor = Color.Pink;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            textBox8.Text = "21";
            button21.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button21.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button21.BackColor = Color.Pink;
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            textBox8.Text = "22";
            button22.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button22.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button22.BackColor = Color.Pink;
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            textBox8.Text = "23";
            button23.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button23.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button23.BackColor = Color.Pink;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            textBox8.Text = "24";
            button24.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button24.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button24.BackColor = Color.Pink;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            textBox8.Text = "25";
            button25.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button25.BackColor = Color.Blue;
            }
            else if (comboBox1.Text == "Kadın")
            {
                button25.BackColor = Color.Pink;
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            textBox8.Text = "26";
            button2.Enabled = false;
            if (comboBox1.Text == "Erkek")
            {
                button26.BackColor = Color.Blue;
            }
            else if(comboBox1.Text == "Kadın")
            {
                button26.BackColor = Color.Pink;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox3.Text = listView1.SelectedItems[0].SubItems[0].Text;
                textBox4.Text = listView1.SelectedItems[0].SubItems[1].Text;
                textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
                textBox5.Text = listView1.SelectedItems[0].SubItems[3].Text;
                textBox6.Text = listView1.SelectedItems[0].SubItems[4].Text;
                textBox7.Text = listView1.SelectedItems[0].SubItems[5].Text;
                textBox8.Text = listView1.SelectedItems[0].SubItems[6].Text;
                textBox9.Text = listView1.SelectedItems[0].SubItems[7].Text;
                comboBox1.Text = listView1.SelectedItems[0].SubItems[8].Text;

            }
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            VerileriGoster("select* from Bilet");
            textBox3.Text=a;
            textBox4.Text=b;
            textBox2.Text=c;
            textBox9.Text=d;
            
        }
    }
}
