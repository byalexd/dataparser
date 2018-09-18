using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Mvc;
using app3.Models;


namespace app3.Controllers
{
    public class HomeController : Controller
    {
        DocumentContext db = new DocumentContext();
        public ActionResult Index()
        {
            return View(db.Docs.ToList());
        }

        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase File, string poisk)
        {
            // Save file to Folder UploadedFiles //
            //if (File != null && File.ContentLength > 0)
            //{
            //    string _FileName = System.IO.Path.GetFileName(File.FileName);
            //    File.SaveAs(Server.MapPath("~/UploadedFiles/" +_FileName));
            //    ViewBag.Message = "Success";
            //}

            if (File != null && File.ContentLength > 0)
            {

                StreamReader reader = new StreamReader(File.InputStream);
                {

                    string searching = "";
                    
                    while ((searching = reader.ReadLine()) != null)
                    {
                        string[] sentences = searching.Split(new char[] { '.' });
                        foreach (var sentence in sentences)
                        {
                            if (sentence.Contains(poisk))
                            {
                                char[] mass = sentence.ToCharArray();
                                Array.Reverse(mass);
                                string output = new string(mass);
                                Document doc = new Document();
                                doc.Text = output;
                                db.Docs.Add(doc);
                                db.SaveChanges();
                            }
                        }
                        
                    }
                    reader.Close();
                }
            }

            return RedirectToAction("Index");



        }
    }
}