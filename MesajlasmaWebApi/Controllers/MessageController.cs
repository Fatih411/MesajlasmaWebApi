using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MesajlasmaWebApi.Controllers
{
    public class MessageController:ApiController
    {
        sosyalMedyaDbEntities1 _ent = new sosyalMedyaDbEntities1();

        [HttpGet]
        public List<MessageModel> getMessage(int pushId,int getId)
        {
            return _ent.mesajTbl.Where(p=>p.mesajiAtanId==pushId&&p.mesajiAlanId==getId||p.mesajiAlanId==pushId&&p.mesajiAtanId==getId).Select(p=> new MessageModel()
            {
                mesajId=p.mesajId,
                mesajiAlanId=p.mesajiAlanId,
                mesajiAtanId=p.mesajiAtanId,
                mesajIcerik=p.mesajIcerik,
            }).ToList();
        }
        [HttpPost]
        public string addMessage(MessageModel message)
        {
            mesajTbl ms=new mesajTbl();
            ms.mesajiAlanId= message.mesajiAlanId;
            ms.mesajiAtanId= message.mesajiAtanId;
            ms.mesajIcerik = message.mesajIcerik;
            _ent.mesajTbl.Add(ms);
            _ent.SaveChanges();
            return "basarili";

        }
    }
}
public class MessageModel
{
    public int mesajId { get; set; }
    public int mesajiAtanId { get; set; }
    public int mesajiAlanId { get; set; }
    public string mesajIcerik { get; set; }
    public System.DateTime mesajTarih { get; set; }
}