using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bantruc_core.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

       public Demos.TinHieuTruc tht { get; set; }
    }
}
