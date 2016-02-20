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
    public class employeesController : Controller
    {
        private PublishersContext db = new PublishersContext();

        // GET: employees
        public ActionResult Index(Recherche recherche)
        {
            //var lesEmployes = db.employees.AsQueryable();
            var lesEmployes = db.employees.Include(e => e.publisher);

            // Les critères de recherche
            if (!string.IsNullOrWhiteSpace(recherche.nomEmp))
            {
                lesEmployes = lesEmployes.Where(n => n.lname.StartsWith(recherche.nomEmp));
            }
            if (!string.IsNullOrEmpty(recherche.Editeurs))
            {
                lesEmployes = lesEmployes.Where(n => n.pub_id.Equals(recherche.Editeurs));
            }

            ViewBag.Editeurs = new SelectList(db.publishers, "pub_id", "pub_name");

            lesEmployes = lesEmployes.OrderBy(a => a.lname);
            // La pagination
            if (recherche.PageCourante == 0)
                recherche.PageCourante = 1;

            ViewBag.PageCourante = recherche.PageCourante;


            IPagedList<employee> pagedList = lesEmployes.ToPagedList(recherche.PageCourante, 10);
            ViewBag.PageCount = pagedList.PageCount;

            return View(pagedList);
        }

        // GET: employees/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_desc");
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name");
            return View();
        }

        // POST: employees/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,fname,minit,lname,job_id,job_lvl,pub_id,hire_date")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_desc", employee.job_id);
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name", employee.pub_id);
            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_desc", employee.job_id);
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name", employee.pub_id);
            return View(employee);
        }

        // POST: employees/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,fname,minit,lname,job_id,job_lvl,pub_id,hire_date")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.job_id = new SelectList(db.jobs, "job_id", "job_desc", employee.job_id);
            ViewBag.pub_id = new SelectList(db.publishers, "pub_id", "pub_name", employee.pub_id);
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //POST: Suppression employe ajax
        [HttpPost]
        public ActionResult SupprEmploye(string id)
        {
            string message = "L'employé a bien été supprimé";
            if (string.IsNullOrWhiteSpace(id))
            {
                message = "Aucune clé ne correspond à l'employé";
            }
            //Recherche de l'auteur
            employee EmployeADelete = db.employees.Where(aut => aut.emp_id.Equals(id)).SingleOrDefault();
            if (EmployeADelete == null)
            {
                message = "L'employé n'existe pas, ou a déjà été supprimé";
            }
            else
            {
                try
                {
                    // Suppression du panier
                    db.employees.Remove(EmployeADelete);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    message = "L'employé n'a pas pu être supprimé : " + ex.Message;
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
