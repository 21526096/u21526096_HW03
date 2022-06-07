using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string FileType, HttpPostedFileBase File)
        {
            if(FileType == "Image")
            {
                // Save the image in the images folder 

                if (File != null && File.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(File.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/Media/Images/"), fileName);

                    // The chosen default path for saving

                    File.SaveAs(path);
                }
          

                

            }
            else if(FileType == "Video")
            {
                // Save the image in the images folder 

                // Save the image in the images folder 

                if (File != null && File.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(File.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/Media/Videos/"), fileName);

                    // The chosen default path for saving

                    File.SaveAs(path);
                }

            }
            else if(FileType == "Document")
            {
                // Save the image in the images folder 

                if (File != null && File.ContentLength > 0)
                {
                    // extract only the filename

                    var fileName = Path.GetFileName(File.FileName);

                    // store the file inside ~/App_Data/uploads folder

                    var path = Path.Combine(Server.MapPath("~/Media/Documents/"), fileName);

                    // The chosen default path for saving

                    File.SaveAs(path);
                }

            }

       
            return View();
        }

    }
}