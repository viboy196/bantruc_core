using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bantruc_core
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListenBoxController : ControllerBase
    {
        // GET: api/<ListenBoxController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            Hubs.ChatHub._hubContext.Clients.All.SendAsync("ReceiveMessage", "đã gửi signalr");
            return new string[] { "value1", "value2" };
        }

        // GET api/<ListenBoxController>/5
        [HttpGet("{id}")]
        public string Get(String sip)
        {
            return sip;
        }

        // POST api/<ListenBoxController>
        [HttpPost(Name = nameof(SendInfo))]
        public ActionResult<SendInfo> SendInfo([FromBody] SendInfo value)
        {
            int stt = 0;
            var newtht = new Demos.TinHieuTruc(stt);
            newtht.settinhieu(value.value);
            newtht.addinfoload("gửi thông báo " + DateTime.Now.ToString("h:mm:ss tt"));
            Services.BantrucService._BantrucService.CreateTinHieuTruc(newtht);
            Hubs.ChatHub._hubContext.Clients.All.SendAsync("addnewTinHieu", newtht.Id);
            return Ok(value);
        }
        // POST: api/TodoItems
        
       
        // PUT api/<ListenBoxController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListenBoxController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       
    }

    public class SendInfo
    {
        public String id { get; set; }
        public String value { get; set; }
        public String type { get; set; }
    }

    
}
