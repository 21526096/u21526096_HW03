using HW3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW3.Controllers
{
    public class FileController : Controller
    {

        public ActionResult Index()
        {
            // All files from the Documents folder
            string[] filesInDocument = Directory.GetFiles(Server.MapPath("~/Media/Documents/"));
     
            // List to store alll 
            List<FileModel> files = new List<FileModel>();

            // For each file 
            foreach (string filePath in filesInDocument)
            {
                // Create a file model
                FileModel fileModel = new FileModel();
                // Assign the file property the File name
                fileModel.FileName = Path.GetFileName(filePath);
                // Add to the list
                files.Add(fileModel);
            }

            // Send the list to the view 
            return View(files);
            

        }


        public FileResult Download(string fileName) // Why fileName and not FileName????
                                                        // Because of using.
        {
            //Build the File Path.

            string path = Server.MapPath("~/Media/Documents/") + fileName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.

            //The OCTET-STREAM format is used for file attachments on the Web with an
            //unknown file type. These .octet-stream files are arbitrary binary data
            //files that may be in any multimedia format.

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult Delete(string FileName)
        {
            // Find the path
            string path = Request.MapPath("~/Media/Documents/" + FileName);
            // Delete the file from the path
            System.IO.File.Delete(path);
            return RedirectToAction("Index");

        }

    }
}