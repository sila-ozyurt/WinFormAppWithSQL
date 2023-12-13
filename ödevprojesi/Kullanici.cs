using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ödevprojesi
{
    internal class Kullanici
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-VV6EKJV;Initial Catalog=SEFERLER;Integrated Security=True");
        SqlCommand komut;
        SqlDataReader read;
        public SqlDataReader kullanici(TextBox telno,TextBox sifre)
        {
            baglanti.Open();
            komut = new SqlCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select* from kullanicilar where telno='" + telno.Text + "'";
            read=komut.ExecuteReader();
            if (read.Read())
            {
                if (sifre.Text == read["sifre"].ToString())
                {
                    MessageBox.Show("giris basarili");
                    Form2 form2 = new Form2();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("hatali sifre girisi");
                }
            }
            else           
            {
                MessageBox.Show("hatali bilgi girisi");
            }
            baglanti.Close();

            return read;
        }

        public void yenikullanici(TextBox ad, TextBox soyad, TextBox telno,TextBox sifre,TextBox sifretekrar)
        {
            try
            {
                if (sifre.Text == sifretekrar.Text)
                {
                    baglanti.Open();
                    komut = new SqlCommand();
                    komut.Connection = baglanti;
                    komut.CommandText = "insert into kullanicilar values('" + ad.Text + "','" + soyad.Text + "','" + telno.Text + "','" + sifre.Text + "')";
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("kullanıcı eklendi");

                    Form2 form2 = new Form2();
                    form2.Show();

                }
                else
                {
                    MessageBox.Show("sifreler uyusmuyor");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("muhtemelen girdiginiz telefon numarası kayıtlı lütfen tekrar deneyiniz");
            }
        }
        public void sifre(TextBox ad, TextBox soyad, TextBox telno, TextBox sifre, TextBox sifretekrar)
        {
            if (sifre.Text==sifretekrar.Text)
            {
                baglanti.Open();
                komut = new SqlCommand("select* from kullanicilar where telno='" + telno.Text + "'", baglanti);
                read = komut.ExecuteReader();
                if (read.Read())
                {
                    if (telno.Text == read["telno"].ToString())
                    {
                        baglanti.Close();
                        baglanti.Open();
                        komut = new SqlCommand("update kullanicilar set ad='"+ad.Text+"',soyad='"+soyad.Text+"',sifre='"+sifre.Text+"' where telno='"+telno.Text+"'",baglanti);
                        komut.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("sifre değiştirme işlemi başarılı");

                    }
                    else
                    {
                        MessageBox.Show("telefon no kısmı hariç diğer bilgilerinizi kontrol ediniz");
                    }
                }
                else
                {
                    MessageBox.Show("bilgilerinizi kontrol ediniz");
                }
                baglanti.Close();
            }   
            else
            {
                MessageBox.Show("sifreler uyusmuyor");
            }
        }
    }
}
