using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bantruc_core
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<PartialViewResult> _updateAsync(string stt =null , string sip = null, string infoadd = null , string Time = null , string second = null , string chuyen = null)
        {
            if(chuyen != null)
            {
                var message = new MulticastMessage()
                {
                    //Tokens = app.Select(c => c.DeviceCode).Distinct().ToList(),
                    Android = new AndroidConfig { Priority = Priority.High },
                };
                var thc = Services.BantrucService._BantrucService.GetTinHieuTruc(stt);
                message.Data = new Dictionary<string, string>()
                    {
                        { "deviceCode", sip},
                        { "patientId", "id"},
                        { "patientName", thc.tenBenhnhan},
                        { "Body", $"Có yêu cầu cuộc gọi từ { thc.tenBenhnhan}" },
                        { "Title", "Thông báo" }
                    };
                var responses = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
                Hubs.ChatHub.chuyen_bantruc_nvyt("0002", Services.BantrucService._BantrucService.GetTinHieuTruc(chuyen));
                ViewBag.stt = chuyen;
            }
            if(stt != null)
            {
                Demos.TinHieuTruc tht;
                if(stt != "new")
                {
                    tht = Services.BantrucService._BantrucService.GetTinHieuTruc(stt);
                    if (Time != null)
                    {
                        tht.addinfoload("Gọi lại bệnh nhân : " + Time + " Thời lượng :" + second + "s");
                    }
                    if (infoadd != null)
                    {
                        tht.addinfoload(infoadd);
                    }

                    Services.BantrucService._BantrucService.UpdateTinHieuTruc(stt, tht);
                    ViewBag.stt = stt;
                }
                 
                else
                {
                    tht = new Demos.TinHieuTruc(100);
                    tht.settinhieu(sip);
                    tht.addinfoload("Gọi bệnh nhân : " + Time + " Thời lượng :" + second + "s");
                    Services.BantrucService._BantrucService.CreateTinHieuTruc(tht);
                    ViewBag.stt = tht.Id;
                    Hubs.ChatHub._hubContext.Clients.All.SendAsync("addnewTinHieucall", tht.Id);
                }
                
            }
           
            return PartialView();
        }

        

    }
}
