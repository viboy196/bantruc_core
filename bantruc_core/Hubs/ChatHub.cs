using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using MongoDB.Bson;

namespace bantruc_core.Hubs
{
    public class ChatHub : Hub
    {
        public static IHubProxy Center_Hub = null;
        public static string Center_ConnectionId = "";
        public static IHubContext<Hubs.ChatHub> _hubContext;
        public static void  Ketnoi()
        {
           
            var hubc = new HubConnection("http://ytemoi.com");
            Center_Hub = hubc.CreateHubProxy("ComHub");

            Center_Hub.On<string>("onConnected",(id)=>{
                Center_ConnectionId = id;
                Center_Hub.Invoke("dangkySVL", "BVPSHN_C3_01");
            });

            Center_Hub.On<string>("mes", (mes) => {
                var m = mes;
            });
            Center_Hub.On<string, string>("ketquachuyen_BT_NVYT" ,(status , string2)=> {
                if (status == "OK")
                {
                    _hubContext.Clients.All.SendAsync("ketquachuyen", status, string2);
                }
                else { }
            });


            Center_Hub.On<string>("reciveSVG", (json) => {
               BsonDocument b = BsonDocument.Parse(json);
              if (b.GetValue("loai",null) =="svl_phonggiuong")
                {
                    b.Set("kieu", "trả lời");
                    b.Set("svl_phong", Services.BantrucService._BantrucService.GetPhong());
                    string s = b.ToJson();
                    Center_Hub.Invoke("sendTo", s);
                }
                if (b.GetValue("loai", null) == "ncbg_sendsignal")
                {
                    //To do somethings
                    //b.getValue("id",null) type value
                    string s = (string)b.GetValue("value", null);
                    var newthm = new Demos.TinHieuTruc(123);
                    newthm.settinhieu(s);
                    newthm.addinfoload("gửi thông báo " + DateTime.Now.ToString("h:mm:ss tt"));
                    Services.BantrucService._BantrucService.CreateTinHieuTruc(newthm);
                    _hubContext.Clients.All.SendAsync("addnewTinHieu", newthm.Id , s, "global" );
                }

            });

            Center_Hub.On<string>("chuyen_NVYT_BT", (thongtin) => {
                Demos.TinHieuTruc info = JsonConvert.DeserializeObject<Demos.TinHieuTruc>(thongtin);
                Services.BantrucService._BantrucService.UpdateTinHieuTruc(info.Id, info);
                _hubContext.Clients.All.SendAsync("chuyen_NVYT_BT", info.Id);
            });
            try
            {
                hubc.Start().Wait();
            }
            catch { }


            
        }
        public static void sendSVL(string mes)
        {
            Center_Hub.Invoke("reciveSVL", mes);
        }
        public static void sendSVL_APP( Object text)
        {
            string thongtin = JsonConvert.SerializeObject(text);
            Center_Hub.Invoke("chuyen_BT_NVYT", "0002",thongtin);
        }
        public static void chuyen_bantruc_nvyt( string idApp, Object obj)
        {
            string thongtin = JsonConvert.SerializeObject(obj);
            Center_Hub.Invoke("chuyen_BT_NVYT", idApp, thongtin);

        }
        public class thongtin
        {
            public string idApp { get; set; }
            public string sip { get; set; }
            public string mes { get; set; }
            public thongtin(string _idApp , string _sip , string _mes)
            {
                idApp = _idApp;
                sip = _sip;
                mes = _mes;
            }

        }
        public void ghichu (string _id, string text)
        {
            var tinhieutruc = Services.BantrucService._BantrucService.GetTinHieuTruc(_id);
            tinhieutruc.addinfoload(text);
            Services.BantrucService._BantrucService.UpdateTinHieuTruc(_id, tinhieutruc);
            Clients.Caller.SendAsync("updateTinHieu", _id);
        }

        
    }
}
