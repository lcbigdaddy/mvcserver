using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

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
            List<Dictionary<string, string>> arr = new List<Dictionary<string, string>>();

            string root_path = ConfigurationManager.AppSettings["file_share_root"].ToString();
            if (!Directory.Exists(root_path))
            {
                root_path = Path.Combine(Server.MapPath(""), root_path);
                if (!Directory.Exists(root_path))
                {
                    return Json(new { Result = 0, Msg = "失败", data = arr }, JsonRequestBehavior.AllowGet);
                }
            }
            DirectoryInfo dir = new DirectoryInfo(root_path);
            
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
