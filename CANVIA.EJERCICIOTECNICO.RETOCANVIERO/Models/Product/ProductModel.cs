using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CANVIA.EJERCICIOTECNICO.RETOCANVIERO.Models.Product
{
    public class ProductModel
    {
        public int? ProductId { set; get; }
        public string Name { set; get; }
        public string Brand { set; get; }
        public DateTime CreateDate { set; get; }
        public DateTime? UpdateDate { set; get; }
        public string Status { set; get; }
        public decimal? Price { set; get; }
    }
}