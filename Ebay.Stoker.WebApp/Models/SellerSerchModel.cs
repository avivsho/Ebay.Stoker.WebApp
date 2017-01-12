using System;
using eBay.Service.Core.Soap;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ebay.Stoker.WebApp.Models
{
    public class SellerSerchModel
    {
        public string sellerName { get; set; }
        public DateTime startdate { get; set; }
        public DateTime endDate { get; set; }
        public ItemTypeCollection sellerlist;

    }   
}