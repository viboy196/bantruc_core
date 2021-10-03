using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bantruc_core.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace bantruc_core.Demos
{

    public class ThietBi
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Name")]
        public String type { get; set; }
        public String SipCode { get; set; }
    }
    public class GiuongBenh
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Name")]
        public string magiuong { get; set; }
        public string TenGiuong { get; set; }
        public ThietBi ThietBi { get; set; }
    }
    public class BenhNhan
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Name")]
        public string maBenhNhan { get; set; }
        public string TenBenhNhan { get; set; }
        public GiuongBenh Giuong { get; set; }
    }
    public class PhongBenh
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Name")]
        public string maphongbenh { get; set; }
        public string tenphongbenh { get; set; }

        public string loaiphongbenh { get; set; }
        public List<GiuongBenh> listGiuongBenh { get; set; }
    }
    public class NhomTruc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Name")]
        public string manhomtruc { get; set; }
        public string tennhomtruc { get; set; }
        public List<PhongBenh> listphongbenh { get; set; }
        public NhomTruc()
        {
            listphongbenh = new List<PhongBenh>();
        }
    }
    public class TinHieuTruc
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [BsonElement("Name")]
        public int stt { get; set; }
        public string mathietbi { get; set; }
        public string tenNhomtruc { get; set; }
        public string TenPhongBenh { get; set; }
        public string tengiuongbenh { get; set; }
        public string tenBenhnhan { get; set; }
        public string thoigiannhan { get; set; }

        public string thoigiangoi { get; set; }

        public int thoiluonggoi { get; set; }
        public List<string> infoadd { get; set; }
        public TinHieuTruc(int dtt)
        {

            stt = dtt;
            infoadd = new List<string>();
        }
        public void settinhieu(string sipcode)
        {
            mathietbi = sipcode;
            ThietBi tb = Services.BantrucService._BantrucService.GetThietBi().Find(x => x.SipCode == mathietbi);
            tengiuongbenh = Services.BantrucService._BantrucService.GetGiuongBenh().Find(x => x.ThietBi.SipCode == mathietbi).TenGiuong;
            tenBenhnhan = Services.BantrucService._BantrucService.GetBenhNhan().Find(x => x.Giuong.TenGiuong == tengiuongbenh).TenBenhNhan;
            TenPhongBenh = Services.BantrucService._BantrucService.GetPhongBenh().Find(x => x.listGiuongBenh.Find(i => i.TenGiuong == tengiuongbenh) != null).tenphongbenh;
            tenNhomtruc = Services.BantrucService._BantrucService.GetNhomTruc().Find(x => x.listphongbenh.Find(i => i.tenphongbenh == TenPhongBenh) != null).tennhomtruc;

            thoigiannhan = DateTime.Now.ToString("h:mm:ss");
        }
        public void addinfoload(string str)
        {
            infoadd.Add(str);
        }
    }


}
