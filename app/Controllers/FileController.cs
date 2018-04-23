using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace app.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/
        [AllowCrossSiteJson]
        [HttpGet]
        public ActionResult Index()
        {
            string root_path = Path.Combine(Server.MapPath(""), "ShareFiles");
            DirectoryInfo dir = new DirectoryInfo(root_path);
            List<Dictionary<string, string>> arr = new List<Dictionary<string, string>>();
            var map = new Dictionary<string, string>();
            foreach (FileInfo d in dir.GetFiles())
            {
                map.Add("Name",d.Name);
                map.Add("FullName", d.FullName.Replace("\\","/"));
                arr.Add(map);
            }
            return Json(new { Result = 0, Msg = "成功", data = arr }, JsonRequestBehavior.AllowGet);
        }
    }
}
