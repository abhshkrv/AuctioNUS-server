using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuctioNUS.Domain.Abstract;
using System.Web.Script.Serialization;
using AuctioNUS.Domain.Entities;
using System.IO;
using Microsoft.WindowsAzure.StorageClient;
using Microsoft.WindowsAzure;
using System.Configuration;

namespace AuctioNUS.WebUI.Controllers
{
    public class DealController : Controller
    {
      IDealRepository _dealRepo;
      IBidRepository _bidRepo;
      IUserRepository _userRepo;
      public DealController(IDealRepository dealrepo, IBidRepository bidrepo, IUserRepository userrepo)
        {
            _dealRepo = dealrepo;
            _bidRepo = bidrepo;
            _userRepo = userrepo;
        }


        //
        // GET: /Deal/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult listDeals()
        {  
            //var response["status"] = "success";
            //var response["deals"] = 
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            result.Add("deals", _dealRepo.Deals);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getDeal(int dealID)
        {
            Deal deal = _dealRepo.Deals.FirstOrDefault(d => d.DealID == dealID);
            
            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            result.Add("deal", deal);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult postDeal(string matric_no, string LAPI_key, string title, int price, DateTime closing_date, HttpPostedFileBase  image, bool deal_type, string author = null, string publisher = null,
                                        string isbn = null)
        {
            Deal deal = new Deal();
            deal.bookName = title;
            deal.author = author;
            deal.closingDate = closing_date;
            deal.ISBN = isbn;
            deal.type = deal_type;
            deal.price = price;

            if (image.ContentLength > 0) 
            {
                var storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnection"].ConnectionString);
                var blobStorage = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobStorage.GetContainerReference("user-images");
                if (container.CreateIfNotExist())
                {
                    // configure container for public access
                    var permissions = container.GetPermissions();
                    permissions.PublicAccess = BlobContainerPublicAccessType.Container;
                    container.SetPermissions(permissions);
                }
                
                string uniqueBlobName = string.Format("user-images/image_{0}{1}", 
                Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
                CloudBlockBlob blob = blobStorage.GetBlockBlobReference(uniqueBlobName);
                blob.Properties.ContentType = image.ContentType;
                blob.UploadFromStream(image.InputStream);
                deal.imgUrl = blob.Uri.AbsoluteUri;
            }

            _dealRepo.saveDeal(deal);

            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult getTopbid(int dealID)
        {
            Bid bid = _bidRepo.Bids.OrderByDescending(b => b.DealID == dealID).First();

            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            result.Add("bids", bid);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult postBid(string matric_no, string LAPI_key, int dealID, int value)
        {
            Bid bid = new Bid();
            bid.DealID = dealID;
            bid.points = value;
            User user = _userRepo.Users.FirstOrDefault(u => u.matricNo == matric_no);
            bid.UserID = user.UserID;
            bid.timeStamp = DateTime.Now;

            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
