using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dosyaportali.ViewModel
{
    public class KullaniciModel
    {
        public string kulId { get; set; }
        public string kulAdSoyad { get; set; }
        public string kulMail { get; set; }
        public string kulSifre { get; set; }
        public string kulDogumTarihi { get; set; }
    }
}