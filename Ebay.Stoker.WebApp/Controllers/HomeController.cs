using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;

namespace Ebay.Stoker.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private static ApiContext apiContext = null;
        public ActionResult Index(string period, string sellerid)
        {

            //ApiContext apiContext = GetApiContext();
            //GetSellerListCall apicall = new GetSellerListCall(apiContext);
            //apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
            //Pagination is required
            //apicall.Pagination = new PaginationType();
            //apicall.Pagination.PageNumber = 1;
            //apicall.Pagination.EntriesPerPage = 200;
            //if (campatitor.Length > 0)
            //    apicall.UserID = campatitor;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult EbayStocker()
        {
            return View();
        }
        /// <summary>
        /// Populate eBay SDK ApiContext object with data from application configuration file
        /// </summary>
        /// <returns>ApiContext</returns>
        static ApiContext GetApiContext()
        {
            //apiContext is a singleton,
            //to avoid duplicate configuration reading
            if (apiContext != null)
            {
                return apiContext;
            }
            else
            {
                apiContext = new ApiContext();

                //set Api Server Url
                apiContext.SoapApiServerUrl =
                    ConfigurationManager.AppSettings["Environment.ApiServerUrl"];
                //set Api Token to access eBay Api Server
                ApiCredential apiCredential = new ApiCredential();
                apiCredential.eBayToken =
                    ConfigurationManager.AppSettings["UserAccount.ApiToken"];
                apiContext.ApiCredential = apiCredential;
                //set eBay Site target to US
                apiContext.Site = SiteCodeType.US;

                return apiContext;
            }
        }
    }

}