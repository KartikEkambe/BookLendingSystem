using BookLendingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookLendingSystem.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
         ApplicationDbContext db=new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult Edit(int id)
        {
            Book b = db.Books.Find(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        public ActionResult Delete(int id)
        {
             Book b=db.Books.Find(id);
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}