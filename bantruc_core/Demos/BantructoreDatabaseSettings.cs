using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bantruc_core.Demos
{
    public class BantructoreDatabaseSettings : IBantructoreDatabaseSettings
    {
        public string ConnectionString { get  ; set  ; }
        public string DatabaseName { get  ; set  ; }
        public string ThietBiCollectionName { get  ; set  ; }
        public string GiuongBenhCollectionName { get  ; set  ; }
        public string BenhNhanCollectionName { get  ; set  ; }
        public string PhongBenhCollectionName { get  ; set  ; }
        public string NhomTrucCollectionName { get  ; set  ; }
        public string TinHieuTrucCollectionName { get  ; set  ; }
    }

    public interface IBantructoreDatabaseSettings
    {
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
         string ThietBiCollectionName { get; set; }
         string GiuongBenhCollectionName { get; set; }
         string BenhNhanCollectionName { get; set; }
         string PhongBenhCollectionName { get; set; }
         string NhomTrucCollectionName { get; set; }
         string TinHieuTrucCollectionName { get; set; }
    }
}
