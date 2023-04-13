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
    public class WatchedMovieListsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: WatchedMovieLists
        public ActionResult Index()
        {
            return View(db.watchedMovieLists.ToList());
        }

        // GET: WatchedMovieLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchedMovieList watchedMovieList = db.watchedMovieLists.Find(id);
            if (watchedMovieList == null)
            {
                return HttpNotFound();
            }
            return View(watchedMovieList);
        }

        // GET: WatchedMovieLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WatchedMovieLists/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MoviesIds")] WatchedMovieList watchedMovieList)
        {
            if (ModelState.IsValid)
            {
                db.watchedMovieLists.Add(watchedMovieList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(watchedMovieList);
        }

        // GET: WatchedMovieLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchedMovieList watchedMovieList = db.watchedMovieLists.Find(id);
            if (watchedMovieList == null)
            {
                return HttpNotFound();
            }
            return View(watchedMovieList);
        }

        // POST: WatchedMovieLists/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MoviesIds")] WatchedMovieList watchedMovieList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(watchedMovieList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(watchedMovieList);
        }

        // GET: WatchedMovieLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WatchedMovieList watchedMovieList = db.watchedMovieLists.Find(id);
            if (watchedMovieList == null)
            {
                return HttpNotFound();
            }
            return View(watchedMovieList);
        }

        // POST: WatchedMovieLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WatchedMovieList watchedMovieList = db.watchedMovieLists.Find(id);
            db.watchedMovieLists.Remove(watchedMovieList);
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
