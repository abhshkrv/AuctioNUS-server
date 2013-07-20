using AuctioNUS.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuctioNUS.WebUI.Controllers
{
    public class SearchController : Controller
    {
        IDealRepository _dealRepo;
        public SearchController(IDealRepository repo)
        {
            _dealRepo = repo;
        }
        //
        // GET: /Search/

        public ActionResult Index(string name = null, string module = null, string isbn = null, string details = null, string price = null)
        {
            var matches = _dealRepo.Deals.Where(m => (m.bookName.Contains(name)||m.ISBN.Contains(isbn)||details.Contains(m.author)));

            var result = new Dictionary<string, object>();
            result.Add("status", "success");
            result.Add("deals", matches);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
