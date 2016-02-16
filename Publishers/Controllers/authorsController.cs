using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Publishers.Models;
using PagedList;

namespace Publishers.Controllers
{
    public class authorsController : Controller
    {
        private PublishersContext db = new PublishersContext();

        //// GET: authors
        //public ActionResult Index()
        //{
        //    return View(db.authors.ToList());
        //}

        public ActionResult Index(Recherche recherche)
        {
            var lesAuteurs = db.authors.AsQueryable();
            // Les critères de recherche
            if (!string.IsNullOrWhiteSpace(recherche.nomAuteur))
            {
                if (recherche.typeRecherche == TypeRecherche.CommencePar)
                {
                    lesAuteurs = lesAuteurs.Where(n => n.au_lname.StartsWith(recherche.nomAuteur));
                }
                else
                {
                    lesAuteurs = lesAuteurs.Where(n => n.au_lname.Contains(recherche.nomAuteur));
                }
            }

            lesAuteurs = lesAuteurs.OrderBy(a => a.au_lname);

            // La pagination
            if (recherche.PageCourante == 0)
                recherche.PageCourante = 1;

            ViewBag.PageCourante = recherche.PageCourante;


            IPagedList<author> pagedList = lesAuteurs.ToPagedList(recherche.PageCourante, 10);
            ViewBag.PageCount = pagedList.PageCount;

            return View(pagedList);
        }


        // GET: authors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: authors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: authors/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "au_id,au_lname,au_fname,phone,address,city,state,zip,contract")] author author)
        {
            if (ModelState.IsValid)
            {
                db.authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: authors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: authors/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "au_id,au_lname,au_fname,phone,address,city,state,zip,contract")] author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: authors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            author author = db.authors.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            author author = db.authors.Find(id);
            db.authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Suppression auteur ajax
        [HttpPost]
        public ActionResult SupprAuteur(string id)
        {
            string message = "L'auteur a bien été supprimé";
            if (string.IsNullOrWhiteSpace(id))
            {
                message = "Aucune clé ne correspond à l'auteur";
            }
            //Recherche de l'auteur
            author AuteurADelete = db.authors.Where(aut => aut.au_id.Equals(id)).SingleOrDefault();
            if (AuteurADelete == null)
            {
                message = "L'auteur n'existe pas, ou a déjà été supprimé";
            }
            else
            {
                try
                {
                    // Suppression du panier
                    db.authors.Remove(AuteurADelete);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = "L'auteur n'a pas pu être supprimé : " + ex.Message;
                    id = "0";
                }
            }

            return Json(new { DeleteId = id, Message = message });
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
