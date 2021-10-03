using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bantruc_core.Demos;
using MongoDB.Bson;
using MongoDB.Driver;
namespace bantruc_core.Services
{

    public class BantrucService
    {
        public static BantrucService _BantrucService ;
        private readonly IMongoCollection<ThietBi> _thiebis;
        private readonly IMongoCollection<GiuongBenh> _giuongbenhs;
        private readonly IMongoCollection<BenhNhan> _benhnhans;
        private readonly IMongoCollection<PhongBenh> _phongbenhs;
        private readonly IMongoCollection<NhomTruc> _nhomtrucs;
        private readonly IMongoCollection<TinHieuTruc> _tinhieutrucs;

        private MongoClient client;
        private IMongoDatabase database;

        public BantrucService(Demos.IBantructoreDatabaseSettings settings)
        {
            client = new MongoClient(settings.ConnectionString);
            database = client.GetDatabase(settings.DatabaseName);

            _thiebis = database.GetCollection<ThietBi>(settings.ThietBiCollectionName);
            _giuongbenhs = database.GetCollection<GiuongBenh>(settings.GiuongBenhCollectionName);
            _benhnhans = database.GetCollection<BenhNhan>(settings.BenhNhanCollectionName);
            _phongbenhs = database.GetCollection<PhongBenh>(settings.PhongBenhCollectionName);
            _nhomtrucs = database.GetCollection<NhomTruc>(settings.NhomTrucCollectionName);
            _tinhieutrucs = database.GetCollection<TinHieuTruc>(settings.TinHieuTrucCollectionName);

            
        }

        public void updateLoaiphongbenh()
        {
            _phongbenhs.Find<PhongBenh>(x => true).ForEachAsync(x =>
            {
                x.loaiphongbenh = "NT";
                _phongbenhs.ReplaceOne(st => st.Id == x.Id, x);
            });
        }
        public BsonArray GetPhong()
        {
            var bs = database.GetCollection<BsonDocument>("PhongBenh").Find(new BsonDocument { }).ToList();
            var b = new BsonArray();
            foreach(var n in bs)
            { 
                b.Add(n);
            }   
            return b;
        }

        public List<ThietBi> GetThietBi() =>
            _thiebis.Find<ThietBi>(thietbi => true).ToList();

        public ThietBi GetThietBi(string id) =>
            _thiebis.Find<ThietBi>(thietbi => thietbi.Id == id).FirstOrDefault();

        public ThietBi CreateThietBi(ThietBi tb)
        {
            _thiebis.InsertOne(tb);
            return tb;
        }

        public void UpdateThietBi(string id, ThietBi thietbiin) => _thiebis.ReplaceOne(thietBi => thietBi.Id == id, thietbiin);

        public void RemoveThietBi(ThietBi thietbiin) =>
            _thiebis.DeleteOne(tb => tb == thietbiin);

        public void RemoveThietBi(string id) =>
            _thiebis.DeleteOne(tb => tb.Id == id);

        public void RemoveAllThietBi()
        {
            _thiebis.DeleteMany(th => true);
        }
        public List<GiuongBenh> GetGiuongBenh() =>
             _giuongbenhs.Find<GiuongBenh>(gb => true).ToList();

        public GiuongBenh GetGiuongBenh(string id) =>
            _giuongbenhs.Find<GiuongBenh>(gb => gb.Id == id).FirstOrDefault();

        public GiuongBenh CreateGiuongBenh(GiuongBenh gb)
        {
            _giuongbenhs.InsertOne(gb);
            return gb;
        }

        public void UpdateGiuongBenh(string id, GiuongBenh gbb) => _giuongbenhs.ReplaceOne(gb => gb.Id == id, gbb);

        public void RemoveGiuongBenh(GiuongBenh gbb) =>
            _giuongbenhs.DeleteOne(gb => gb == gbb);

        public void RemoveGiuongBenh(string id) =>
            _giuongbenhs.DeleteOne(gb => gb.Id == id);
        public void RemoveAllGiuongBenh()
        {
            _giuongbenhs.DeleteMany(th => true);
        }
        public List<BenhNhan> GetBenhNhan() =>
            _benhnhans.Find<BenhNhan>(bn => true).ToList();

        public BenhNhan GetBenhNhan(string id) =>
            _benhnhans.Find<BenhNhan>(bn => bn.Id == id).FirstOrDefault();

        public BenhNhan CreateBenhNhan(BenhNhan bn)
        {
            _benhnhans.InsertOne(bn);
            return bn;
        }

        public void UpdateBenhNhan(string id, BenhNhan bnn) => _benhnhans.ReplaceOne(bn => bn.Id == id, bnn);

        public void RemoveBenhNhan(BenhNhan bnn) =>
            _benhnhans.DeleteOne(bn => bn == bnn);

        public void RemoveBenhNhan(string id) =>
            _benhnhans.DeleteOne(bn => bn.Id == id);

        // phong benh
        public List<PhongBenh> GetPhongBenh() =>
           _phongbenhs.Find<PhongBenh>(pb => true).ToList();

        public PhongBenh GetPhongBenh(string id) =>
            _phongbenhs.Find<PhongBenh>(pb => pb.Id == id).FirstOrDefault();

        public PhongBenh CreatePhongBenh(PhongBenh pb)
        {
            _phongbenhs.InsertOne(pb);
            return pb;
        }

        public void UpdatePhongBenh(string id, PhongBenh pbin) => _phongbenhs.ReplaceOne(pb => pb.Id == id, pbin);

        public void RemovePhongBenh(PhongBenh pbin) =>
            _phongbenhs.DeleteOne(pb => pb == pbin);

        public void RemovePhongBenh(string id) =>
            _phongbenhs.DeleteOne(pb => pb.Id == id);

        // nhoms truwc
        public List<NhomTruc> GetNhomTruc() =>
           _nhomtrucs.Find<NhomTruc>(nt => true).ToList();

        public NhomTruc GetNhomTruc(string id) =>
            _nhomtrucs.Find<NhomTruc>(nt => nt.Id == id).FirstOrDefault();

        public NhomTruc CreateNhomTruc(NhomTruc nt)
        {
            _nhomtrucs.InsertOne(nt);
            return nt;
        }

        public void UpdateNhomTruc(string id, NhomTruc ntin) => _nhomtrucs.ReplaceOne(nt => nt.Id == id, ntin);

        public void RemoveNhomTruc(NhomTruc ntin) =>
            _nhomtrucs.DeleteOne(nt => nt == ntin);

        public void RemoveNhomTruc(string id) =>
            _nhomtrucs.DeleteOne(nt => nt.Id == id);

        // tin hieu truc

        public List<TinHieuTruc> GetTinHieuTruc() =>
          _tinhieutrucs.Find<TinHieuTruc>(tht => true).ToList();

        public TinHieuTruc GetTinHieuTruc(string id) =>
            _tinhieutrucs.Find<TinHieuTruc>(tht => tht.Id == id).FirstOrDefault();

        public TinHieuTruc CreateTinHieuTruc(TinHieuTruc tht)
        {
            _tinhieutrucs.InsertOne(tht);
            return tht;
        }

        public void UpdateTinHieuTruc(string id, TinHieuTruc thtin) => _tinhieutrucs.ReplaceOne(tht => tht.Id == id, thtin);

        public void RemoveTinHieuTruc(TinHieuTruc thtin) =>
            _tinhieutrucs.DeleteOne(tht => tht == thtin);

        public void RemoveTinHieuTruc(string id) =>
            _tinhieutrucs.DeleteOne(tht => tht.Id == id);
        public void RemoveAllTinHieuTruc() =>
           _tinhieutrucs.DeleteMany(tht =>true);

        public void taotinhieu()
        {
            var pb = _phongbenhs.Find<PhongBenh>(pb => pb.Id == "614edc55212337c0b24afce5").FirstOrDefault();
            var gbb = _giuongbenhs.Find<GiuongBenh>(x => x.Id == "614edc55212337c0b24afc7e").FirstOrDefault();
            var id = pb.listGiuongBenh.FindIndex(x => x.Id == "614edc55212337c0b24afc7e");
            pb.listGiuongBenh[id] = gbb;
            _phongbenhs.ReplaceOne(x => x.Id == pb.Id, pb);
        }
    }
}
