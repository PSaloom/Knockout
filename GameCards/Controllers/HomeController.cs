using GameCards.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Web.Services;

namespace GameCards.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [WebMethod]
        public JsonResult SaveGameList(List<Game> gamesList)
        {
            bool saved = false;
            ApplicationDbContext dbContext = new ApplicationDbContext();
            try
            {
                foreach (Game game in gamesList)
                {
                    dbContext.Games.Add(game);
                }
                saved = true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            return Json(new { result = saved });
        }

        [HttpPost]
        [WebMethod]
        public JsonResult LookUpGames(string search)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api-endpoint.igdb.com/games/?search=" + search + "&fields=id,name");
            request.Accept = "application/json";
            request.Headers.Add("user-key:035401943710759992f5f983b4b53af2");
            WebResponse response = (HttpWebResponse)request.GetResponse();
            string responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return Json(new { result = responseString });
        }
    }
}