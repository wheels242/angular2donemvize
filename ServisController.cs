using dosyaportali.Models;
using dosyaportali.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace dosyaportali.Controllers
{
    public class ServisController : ApiController
    {
        haberportalEntities db = new haberportalEntities();
        SonucModel sonuc = new SonucModel();

        [HttpGet]
        [Route("api/kullaniciliste")]
        public List<KullaniciModel> KullaniciListe()
        {
            List<KullaniciModel> liste = db.Kullanici.Select(x => new KullaniciModel()
            {
                kulId = x.kulId,
                kulAdSoyad = x.kulAdSoyad,
                kulDogumTarihi = x.kulDogumTarihi,
                kulMail = x.kulMail,
                kulSifre = x.kulSifre,
            }).ToList();
            return liste;
        }

        [HttpGet]
        [Route("api/kullanicibyid/{kulId}")]
        public KullaniciModel Kullanicibyid(string kulId)
        {
            KullaniciModel kayit = db.Kullanici.Where(s => s.kulId == kulId).Select(x => new
            KullaniciModel()
            {
                kulId = x.kulId,
                kulAdSoyad = x.kulAdSoyad,
                kulDogumTarihi = x.kulDogumTarihi,
                kulMail = x.kulMail,
                kulSifre = x.kulSifre,
            }).SingleOrDefault();

            return kayit;
        }

        [HttpPost]
        [Route("api/kullaniciekle")]
        public SonucModel KullaniciEkle(KullaniciModel model)
        {
            if (db.Kullanici.Count(c => c.kulId == model.kulId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kullanıcı eklenemez!";
                return sonuc;
            }
            Kullanici yeni = new Kullanici();

            yeni.kulAdSoyad = model.kulAdSoyad;
            yeni.kulMail = model.kulMail;
            yeni.kulSifre = model.kulSifre;
            yeni.kulDogumTarihi = model.kulDogumTarihi;
            db.Kullanici.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanici Eklendi";
            return sonuc;
        }


        [HttpPut]
        [Route("api/kullaniciduzenle")]
        public SonucModel KullaniciDuzenle(KullaniciModel model)
        {
            Kullanici kayit = db.Kullanici.Where(s => s.kulId == model.kulId).FirstOrDefault
           ();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.kulAdSoyad = model.kulAdSoyad;
            kayit.kulMail = model.kulMail;
            kayit.kulSifre = model.kulSifre;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanıcı Güncellendi";
            return sonuc;
        }

        [HttpDelete]
        [Route("api/kullanicisil/{kulId}")]
        public SonucModel KullaniciSil(string kulId)
        {
            Kullanici kayit = db.Kullanici.Where(s => s.kulId == kulId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.Kullanici.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Öğrenci Silindi";

            return sonuc;
        }


        [HttpGet]
        [Route("api/dosyaliste")]
        public List<DosyaModel> DosyaListe()
        {
            List<DosyaModel> liste = db.Dosya.Select(x => new DosyaModel()
            {
                dosyaId = x.dosyaId,
                dosyaAdı = x.dosyaAdı,
                dosyaIcerigi = x.dosyaIcerigi,
                dosyaTuru = x.dosyaTuru,
            }).ToList();
            return liste;
        }


        [HttpGet]
        [Route("api/dosyabyid/{dosyaId}")]
        public DosyaModel Dosyabyid(string dosyaId)
        {
            DosyaModel kayit = db.Dosya.Where(s => s.dosyaId == dosyaId).Select(x => new
            DosyaModel()
            {
                dosyaId = x.dosyaId,
                dosyaAdı = x.dosyaAdı,
                dosyaIcerigi = x.dosyaIcerigi,
                dosyaTuru = x.dosyaTuru,
            }).SingleOrDefault();

            return kayit;
        }


        [HttpPost]
        [Route("api/dosyaekle")]
        public SonucModel DosyaEkle(DosyaModel model)
        {
            if (db.Dosya.Count(c => c.dosyaId == model.dosyaId) > 0)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Dosya eklenemez!";
                return sonuc;
            }
            Dosya yeni = new Dosya();

            yeni.dosyaAdı = model.dosyaAdı;
            yeni.dosyaIcerigi = model.dosyaIcerigi;
            yeni.dosyaTuru = model.dosyaTuru;
            db.Dosya.Add(yeni);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Kullanici Eklendi";
            return sonuc;
        }


        [HttpPut]
        [Route("api/dosyaduzenle")]
        public SonucModel DosyaDuzenle(DosyaModel model)
        {
            Dosya kayit = db.Dosya.Where(s => s.dosyaId == model.dosyaId).FirstOrDefault
           ();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            kayit.dosyaAdı = model.dosyaAdı;
            kayit.dosyaIcerigi = model.dosyaIcerigi;
            kayit.dosyaTuru = model.dosyaTuru;
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Dosya Güncellendi";
            return sonuc;
        }


        [HttpDelete]
        [Route("api/kullanicisil/{dosyaId}")]
        public SonucModel DosyaSil(string dosyaId)
        {
            Dosya kayit = db.Dosya.Where(s => s.dosyaId == dosyaId).FirstOrDefault();
            if (kayit == null)
            {
                sonuc.islem = false;
                sonuc.mesaj = "Kayıt Bulunamadı!";
                return sonuc;
            }
            db.Dosya.Remove(kayit);
            db.SaveChanges();
            sonuc.islem = true;
            sonuc.mesaj = "Dosya Silindi";

            return sonuc;
        }
    }
}
