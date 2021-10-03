using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bantruc_core.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(/*string mes = null , int stt = -1, string Time = null, int second =-1 , string ghichu = null , string chuyen = null*/)
        {
           

            Services.BantrucService._BantrucService.taotinhieu();
            //if(chuyen != null)
            //{

            //    var tt = Demos.Demodulieus.lstinhieutruc.Find(x => x.stt == stt);
            //    Hubs.ChatHub.chuyen_bantruc_nvyt("0002" ,tt);
            //    return;
            //}
            //if (mes != null)
            //{
            //    var tinhieu = new Demos.TinHieuTruc(Demos.Demodulieus.biendemtinhieu);
            //    Demos.Demodulieus.biendemtinhieu++;
            //    tinhieu.settinhieu(mes);
            //    if(Time != null)
            //    {
            //        tinhieu.thoigiangoi = Time;
            //        tinhieu.thoiluonggoi = second;
            //        tinhieu.addinfoload("Trực gọi: " + Time + " thời lượng :" + second + "s");
            //        Demos.Demodulieus.tinhieumoi = false;
            //    }
            //    else
            //    {

            //        tinhieu.addinfoload("Gửi tín hiệu " + tinhieu.thoigiannhan);
            //        Demos.Demodulieus.tinhieumoi = true;
            //    }
            //    Demos.Demodulieus.lstinhieutruc.Insert(0, tinhieu);

            //}
            //else
            //{
            //    Demos.Demodulieus.tinhieumoi = false;
            //    if(stt > -1)
            //    {
            //        var index = Demos.Demodulieus.lstinhieutruc.FindIndex(x => x.stt == stt);
            //        if (index != -1)
            //        {
            //            if (ghichu != null)
            //            {
            //                Demos.Demodulieus.lstinhieutruc[index].addinfoload("ghi chú :" + ghichu);
            //            }
            //            if(Time != null)
            //            {
            //                Demos.Demodulieus.lstinhieutruc[index].thoigiangoi = Time;
            //                Demos.Demodulieus.lstinhieutruc[index].thoiluonggoi = second;
            //                Demos.Demodulieus.lstinhieutruc[index].addinfoload("Trực gọi: " + Time + " thời lượng :" + second + "s");

            //            }

            //        }
            //    }
            //}

        }

    }
}
