using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ebay.Stoker.WebApp.Controllers
{
    public class EbayStockerController : Controller
    {
        // GET: EbayStocker
        public ActionResult Index()
        {
            return View();
        }
    }
}