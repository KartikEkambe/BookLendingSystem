using BookLendingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLendingSystem.Controllers
{
    public class BorrowersController : Controller
    {
        // GET: Borrowers
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Borrowers.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                db.Borrowers.Add(borrower);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {

            return View(borrower);
            }
        }

        public ActionResult Edit(int id)
        {
            Borrower b = db.Borrowers.Find(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Edit(Borrower borrower)
        {
            if (ModelState.IsValid)
            {
                db.Entry(borrower).State=System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(borrower);
            }
        }

        public ActionResult Delete(int id)
        {
            Borrower b = db.Borrowers.Find(id);
            db.Borrowers.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}