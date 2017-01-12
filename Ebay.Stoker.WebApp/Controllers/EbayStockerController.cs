using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using eBay.Service.Call;
using eBay.Service.Core.Sdk;
using eBay.Service.Core.Soap;
using Ebay.Stoker.WebApp.Models;

namespace Ebay.Stoker.WebApp.Controllers
{
    public class EbayStockerController : Controller
    {
        private static ApiContext apiContext = null;
        // GET: EbayStocker
        [HttpGet]
        public ActionResult Index(SellerSerchModel  serch) 
        {
            try
            {
            

                ApiContext apiContext = GetApiContext();
                GetSellerListCall apicall = new GetSellerListCall(apiContext);
                apicall.DetailLevelList.Add(DetailLevelCodeType.ReturnAll);
                ////Pagination is required
                apicall.Pagination = new PaginationType();
                apicall.Pagination.PageNumber = 1;
                apicall.Pagination.EntriesPerPage = 200;
                if (serch.sellerName != null)
                {

                    apicall.UserID = serch.sellerName;
                    serch.endDate.GetDateTimeFormats();
                    apicall.StartTimeFilter = new TimeFilter(serch.startdate, serch.endDate);
                    serch.sellerlist = apicall.GetSellerList();
                }
                return View(serch);
            }
          
            
             catch (Exception ex)
            {
               throw ;
            }
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