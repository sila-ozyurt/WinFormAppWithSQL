using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ödevprojesi
{
    internal class Sefer_Bilgileri
    {
        int _sefer_no;
        string _plaka;
        string _kalkis_yeri;
        string _varis_yeri;
        string _tarih_ve_saat;
        float _fiyat;
        string _sofor;

        public int SeferNo { get => _sefer_no; set => _sefer_no = value; }
        public string Plaka { get => _plaka; set => _plaka = value; }
        public string KalkisYeri { get => _kalkis_yeri; set => _kalkis_yeri = value; }
        public string VarisYeri { get => _varis_yeri; set => _varis_yeri = value; }
        public string TarihVeSaat { get => _tarih_ve_saat; set => _tarih_ve_saat = value; }
        public float Fiyat { get => _fiyat; set => _fiyat = value; }
        public string Sofor { get => _sofor; set => _sofor = value; }

    }
}
