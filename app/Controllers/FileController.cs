using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/
        [HttpGet]
        public ActionResult Index()
        {
            var map = new Dictionary<string, string>();
            map.Add("C#", "0");
            map.Add("C++", "1");
            map.Add("C", "2");
            map.Add("VB", "2"); 
            return Json(new { Result = 0, Msg = "成功", data = map }, JsonRequestBehavior.AllowGet);
        }
    }
}
