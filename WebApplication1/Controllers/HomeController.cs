using MovieList.DAL;
using MovieList.Models;
using MovieList.Utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext db = new ProjectContext();
        public ActionResult Index()
        {
            
            Utils utils = new Utils();
            string r = utils.APIRequester(page: "1");
            JObject data = JObject.Parse(r);

            int page = (int)data["page"];
            string next = (string)data["next"];
            JArray results = (JArray)data["results"];
            List<Object> treatedResult = new List<Object>();
            foreach (JObject result in results)
            {
                MovieProperties x = new MovieProperties();

                if (result?["id"] != null)
                {
                    x.id = (string)result["id"];
                }
                if (result["primaryImage"] is JObject primaryImage && primaryImage["url"] != null)
                {

                    x.imageAddress = (string)primaryImage["url"];

                    if (result?["primaryImage"]?["caption"]?["plainText"] != null)
                    {
                        x.description = (string)result["primaryImage"]?["caption"]?["plainText"];
                        byte[] a = Encoding.Default.GetBytes(x.description);
                        x.description = Encoding.UTF8.GetString(a);
                    }
                }
                if (result?["titleText"]?["text"] != null)
                {
                    x.title = (string)result["titleText"]["text"];
                    byte[] a = Encoding.Default.GetBytes(x.title);
                    x.title = Encoding.UTF8.GetString(a);
                }
                if (result?["releaseYear"]?["year"] != null)
                {
                    x.releaseYear = (int)result["releaseYear"]["year"];
                }


                treatedResult.Add(x);
            }
            ViewBag.altImage = Server.MapPath("~/Assets/movie-banner.jpg");
            ViewBag.results = treatedResult;

            try
            {
                ICollection<WatchedMovieList> mvl = db.watchedMovieLists.ToList();
                ICollection<ToWatchMovieList> tmvl = db.toWatchMovieLists.ToList();
                if (mvl.Count > 0)
                {
                    ViewBag.mvl = mvl;
                }
                if (tmvl.Count > 0)
                {
                    ViewBag.tmvl = tmvl;
                }
            }
            catch(Exception ex)
            {
                
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Search(string searchString, string pageUrl = "")
        {
            Utils utils = new Utils();
            string response = "";
            if (string.IsNullOrEmpty(pageUrl))
            {
                response = utils.APIRequester(apiop: APIOperation.SEARCH_BY_TITLE, s: searchString);

            }
            else
            {
                response = utils.APIRequester(apiop: APIOperation.PAGINATE, s: searchString, page: pageUrl);
            }
            JObject data = JObject.Parse(response);
            int page = (int)data["page"];
            string nextUrl = (string)data["next"];
            if (data["next"] is JObject next && next != null)
            {
                nextUrl = (string)next;
            }
            JArray results = (JArray)data["results"];
            List<Object> treatedResult = new List<Object>();

            foreach (JObject result in results)
            {
                MovieProperties x = new MovieProperties();

                if (result?["id"] != null)
                {
                    x.id = (string)result["id"];
                }
                if (result["primaryImage"] is JObject primaryImage && primaryImage["url"] != null)
                {

                    x.imageAddress = (string)primaryImage["url"];

                    if (result?["primaryImage"]?["caption"]?["plainText"] != null)
                    {
                        x.description = (string)result["primaryImage"]?["caption"]?["plainText"];
                        byte[] a = Encoding.Default.GetBytes(x.description);
                        x.description = Encoding.UTF8.GetString(a);
                    }
                }
                if (result?["titleText"]?["text"] != null)
                {
                    x.title = (string)result["titleText"]["text"];
                    byte[] a = Encoding.Default.GetBytes(x.title);
                    x.title = Encoding.UTF8.GetString(a);
                }
                if (result?["releaseYear"] is JObject releaseYear && releaseYear["year"] != null)
                {
                    x.releaseYear = (int)releaseYear["year"];
                }


                treatedResult.Add(x);

            }
            if (treatedResult.Count == 0)
            {
                ViewBag.Message = "Não foram encontrados resultados.";
                return View();
            }
            if (!string.IsNullOrEmpty(nextUrl))
            {
                ViewBag.results = treatedResult;
                ViewBag.page = page;
                ViewBag.nextPageUrl = nextUrl;
                return View();

            }
            ViewBag.results = treatedResult;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}