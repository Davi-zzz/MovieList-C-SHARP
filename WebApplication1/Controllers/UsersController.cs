using MovieList.DAL;
using MovieList.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class UsersController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Users
        public ActionResult Index()
        {
            var users = db.users.Include(u => u.Person);
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            ViewBag.PersonId = new SelectList(db.people, "Id", "Name");
            return View();
        }

        // POST: Users/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,Password,Created_at,Updated_at,PersonId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PersonId = new SelectList(db.people, "Id", "Name", user.PersonId);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.PersonId = new SelectList(db.people, "Id", "Name", user.PersonId);
            return View(user);
        }

        // POST: Users/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,Password,Created_at,Updated_at,PersonId")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PersonId = new SelectList(db.people, "Id", "Name", user.PersonId);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.users.Find(id);
            db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Login(string email, string password)
        {
            User user;
            if (email != null && password != null)
            {
                user = db.users.Where(u => u.Email == email && u.Password == password).FirstOrDefault();
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        public ActionResult SignUp(string email, string password, string birthday, string name, string tags = "")
        {
            if (ModelState.IsValid)
            {
                try
                {

                Person person = new Person(name, DateTime.Parse(birthday), tags);
                db.people.Add(person);

                User user = new User(email, password);
                user.Person = person;
                db.users.Add(user);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
                }
                catch(Exception ex) {
                    ViewBag.message = $"algo deu errado... \n{ex}";
                    return View();
                }
                
            }
            return View();
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
