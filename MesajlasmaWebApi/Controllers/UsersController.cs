using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MesajlasmaWebApi.Controllers
{
    public class UsersController:ApiController
    {
        sosyalMedyaDbEntities1 _ent=new sosyalMedyaDbEntities1();
        [HttpGet]
        public List<UsersModel> login(string name,string password)
        {
            return _ent.kullaniciTbl.Where(p => p.isim == name && p.sifre == password).Select(p => new UsersModel() {id=p.id,isim=p.isim,soyad=p.soyad }).ToList();
        }
        [HttpGet]
        public List<UsersModel> isMesaj(int id)
        {
            return _ent.kullaniciTbl.Where(p=>p.mesajTbl.Any(k=>k.mesajiAlanId==id)||p.mesajTbl1.Any(k=>k.mesajiAtanId==id)).Select(p=>new UsersModel()
            {
                id=p.id,
                isim=p.isim,
                soyad=p.soyad
            }).ToList();
        }
        [HttpPost]
        public string register(UsersModel users)
        {
            try
            {
                kullaniciTbl us = new kullaniciTbl();
                us.isim = users.isim;
                us.soyad = users.soyad;
                us.mail = users.mail;
                us.sifre = users.sifre;
                us.yetki = "kullanici";
                _ent.kullaniciTbl.Add(us);
                _ent.SaveChanges();
                return "başarılı";
            }
            catch(Exception ex)
            {
                return ex.Message.ToString();
            }   
        }
        [HttpGet]
        public List<UsersModel> isUsers(int id)
        {
            return _ent.kullaniciTbl.Where(p=>p.id!=id).Select(p=>new UsersModel() { 
            id=p.id,
            isim=p.isim,
            soyad=p.soyad,
            }).ToList();
        }

    }
}
public class UsersModel
{
    public int id { get; set; }
    public string isim { get; set; }
    public string soyad { get; set; }
    public string mail { get; set; }
    public string sifre { get; set; }
    public string yetki { get; set; }

}