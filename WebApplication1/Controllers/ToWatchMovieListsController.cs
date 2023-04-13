using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieList.DAL;
using MovieList.Models;

namespace WebApplication1.Controllers
{
    public class ToWatchMovieListsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ToWatchMovieLists
        public ActionResult Index()
        {
            return View(db.toWatchMovieLists.ToList());
        }

        // GET: ToWatchMovieLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToWatchMovieList toWatchMovieList = db.toWatchMovieLists.Find(id);
            if (toWatchMovieList == null)
            {
                return HttpNotFound();
            }
            return View(toWatchMovieList);
        }

        // GET: ToWatchMovieLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToWatchMovieLists/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MoviesTags,MovieIds")] ToWatchMovieList toWatchMovieList)
        {
            if (ModelState.IsValid)
            {
                db.toWatchMovieLists.Add(toWatchMovieList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toWatchMovieList);
        }

        // GET: ToWatchMovieLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToWatchMovieList toWatchMovieList = db.toWatchMovieLists.Find(id);
            if (toWatchMovieList == null)
            {
                return HttpNotFound();
            }
            return View(toWatchMovieList);
        }

        // POST: ToWatchMovieLists/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MoviesTags,MovieIds")] ToWatchMovieList toWatchMovieList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toWatchMovieList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toWatchMovieList);
        }

        // GET: ToWatchMovieLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToWatchMovieList toWatchMovieList = db.toWatchMovieLists.Find(id);
            if (toWatchMovieList == null)
            {
                return HttpNotFound();
            }
            return View(toWatchMovieList);
        }

        // POST: ToWatchMovieLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToWatchMovieList toWatchMovieList = db.toWatchMovieLists.Find(id);
            db.toWatchMovieLists.Remove(toWatchMovieList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
