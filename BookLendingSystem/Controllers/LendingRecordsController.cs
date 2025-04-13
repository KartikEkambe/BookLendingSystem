using BookLendingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BookLendingSystem.Controllers
{
    public class LendingRecordsController : Controller
    {
        // GET: LendingRecords
        ApplicationDbContext db=new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(db.LendingRecords.ToList());
        }
        public ActionResult Create()
        {
            ViewBag.Books=new SelectList(db.Books.Where(b=>b.IsAvailable),"BookId","Title");
            ViewBag.Borrowers =new SelectList( db.Borrowers,"BorrowerId","Name");
            return View();
        }
        [HttpPost]
        public ActionResult Create(LendingRecord lendingRecord)
        {
             
                Book b = db.Books.Find(lendingRecord.BookId);
                if(b==null || !b.IsAvailable)
                {
                    return RedirectToAction("Index");
                }

            int actives = db.LendingRecords.Count(l => l.BorrowerId == lendingRecord.BorrowerId && l.DateReturned == null);
                if (actives >= 3)
                {
                    return RedirectToAction("Index");
                }
                b.IsAvailable = false;
                db.LendingRecords.Add(new LendingRecord { BookId=lendingRecord.BookId,BorrowerId=lendingRecord.BorrowerId});
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        public ActionResult ReturnBook(int id)
        {
            var record = db.LendingRecords.Find(id);
            if(record!=null&& record.DateReturned == null)
            {
                record.DateReturned=System.DateTime.Now;
                record.Book.IsAvailable = true;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}