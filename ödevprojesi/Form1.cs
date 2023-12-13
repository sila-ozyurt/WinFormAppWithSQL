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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "Telefon numarası";
            textBox2.Text = "Şifre";

        }
        Kullanici user = new Kullanici();
        public string a, b, c, d;      //  giriş bilgilerini diğer forma çekicem
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VV6EKJV;Initial Catalog=SEFERLER;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel2.Visible = true;
            textBox1.Text = "Telefon numarası";
            textBox1.Font = new Font(textBox1.Font, textBox1.Font.Style ^ FontStyle.Italic);

            textBox2.Text = "Şifre";
            textBox2.Font = new Font(textBox2.Font, textBox2.Font.Style ^ FontStyle.Italic);

            textBox3.Text = "TEL NO GİRİNİZ";
            textBox3.Font = new Font(textBox3.Font, textBox3.Font.Style ^ FontStyle.Italic);

            textBox4.Text = "ŞİFRE GİRİNİZ";
            textBox4.Font = new Font(textBox4.Font, textBox4.Font.Style ^ FontStyle.Italic);

            textBox5.Text = "ADINIZI GİRİNİZ";
            textBox5.Font = new Font(textBox5.Font, textBox5.Font.Style ^ FontStyle.Italic);
           
            textBox6.Text = "SOYADINIZI GİRİNİZ";
            textBox6.Font = new Font(textBox6.Font, textBox6.Font.Style ^ FontStyle.Italic);


            textBox7.Text = "TEKRAR SİFRE GİRİNİZ";
            textBox7.Font = new Font(textBox7.Font, textBox7.Font.Style ^ FontStyle.Italic);

        }
        private void textBox1_Enter_1(object sender, EventArgs e)
        {

            textBox1.Text = "";

        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Telefon numarası";
            }
        }
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Text = "";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "TEL NO GİRİNİZ";
            }
        }
        private void textBox4_Enter(object sender, EventArgs e)
        {
             textBox4.Text = "";
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "ŞİFRE GİRİNİZ";
            }
        }
        private void textBox5_Enter(object sender, EventArgs e)
        {
            textBox5.Text = "";
        }
    
        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "ADINIZI GİRİNİZ";
            }
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
              textBox6.Text = "";
    
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                textBox6.Text = "SOYADINIZI GİRİNİZ";
            }
        }
        private void textBox7_Enter(object sender, EventArgs e)
        {
            textBox7.Text = "";

        }
        private void textBox7_Leave(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                textBox7.Text = "TEKRAR SİFRE GİRİNİZ";
            }
        }
        public void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel3.Visible = true;

            try
            {
                if (textBox5.Text != "ADINIZI GİRİNİZ" && textBox5.Text != "" && textBox6.Text != "SOYADINIZI GİRİNİZ" && textBox6.Text != "" && textBox3.Text != "TEL NO GİRİNİZ" && textBox3.Text != "" && textBox4.Text != "ŞİFRE GİRİNİZ" && textBox4.Text != "" && textBox7.Text != "TEKRAR SİFRE GİRİNİZ" && textBox7.Text != "")
                {
                    a = textBox3.Text;
                    user.yenikullanici(textBox5, textBox6, textBox3, textBox4, textBox7);
                    this.Hide();
                }
                else 
                {
                    MessageBox.Show("lütfen herhangi bir alanı boş bırakmayınız");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("işlem gerçekleştirilemedi lütfen tekrar deneyiniz");
            }
        }




        public void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel3.Visible = false;        
            panel1.Visible = true;
            
            if(textBox1.Text != "Telefon numarası" && textBox1.Text != "" && textBox2.Text != "Şifre" && textBox2.Text != "")
            {
                a = textBox1.Text;
                user.kullanici(textBox1, textBox2);

                this.Hide();
            }          
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "1234")
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hatalı bilgi girişi yaptınız lütfen tekrar deneyiniz");

            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox2.PasswordChar.ToString() == "*")
            {
                textBox2.PasswordChar = char.Parse("\0");
                linkLabel2.Text = "Gizle";
            }
            else
            {
                textBox2.PasswordChar = char.Parse("*");
                linkLabel2.Text = "Göster";
            }
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (textBox4.PasswordChar.ToString() == "*" && textBox4.PasswordChar.ToString() == "*")
            {
                textBox4.PasswordChar = char.Parse("\0");
                textBox7.PasswordChar = char.Parse("\0");
                linkLabel3.Text = "Gizle";
            }
            else
            {
                textBox4.PasswordChar = char.Parse("*");
                textBox7.PasswordChar = char.Parse("*");
                linkLabel3.Text = "Göster";
            }
        }
    }
}
