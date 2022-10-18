using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleAsynAjax.Models;
using Newtonsoft.Json;
using System.Net;
using System.Data;
using System.Threading;


namespace SimpleAsynAjax.Controllers
    {

    public class HomeController : Controller
        {

        public ExampleDatabaseEntities db = new ExampleDatabaseEntities();
        public ActionResult Index()
            {
            return View();
            }

        //[HttpPost]
        public string Create()
            {
            //----------- Edit Here -----------

                object databaseData = db.ExampleTables.Select(p => new { SimpleID = p.SimpleID, SimpleAttribute = p.SimpleAttribute}).ToList();
                return JsonConvert.SerializeObject(databaseData);
        }

        public JsonResult GetExampleTable()
            {
            //----------- Edit Here -----------
            object databaseData = db.ExampleTables.Select(p => new { SimpleID = p.SimpleID, SimpleAttribute = p.SimpleAttribute }).ToList();
            return Json(databaseData, JsonRequestBehavior.AllowGet); // <<<<<<<<< You will need to change this to a Json return.
            }

        public string Add(string name)
        {
            db.ExampleTables.Add(new ExampleTable { SimpleAttribute = name });

            db.SaveChanges();

            return JsonConvert.SerializeObject(new { message = "New playlist added!" });
        }

        public string Get(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            object tracks = db.ExampleTables.Include("Track.Album.Artist").Where(p => p.SimpleID == id);

            object data = new
            {
                db.ExampleTables.Where(p => p.SimpleID == id).First().SimpleID,
                Tracks = tracks
            };

            return JsonConvert.SerializeObject(data);
        }
    }
    }


