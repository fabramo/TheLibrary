using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using FrontEnd.Models;
using FrontEnd.ViewModels;

namespace FrontEnd.Controllers
{
    public class BooksController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();

        // GET: Books
        public ActionResult Index()
        {
            var bookViewModels = new List<BookViewModel>();

            var books = (from b in db.Books
                         join ab in db.BookAuthors on b.ID equals ab.BookId
                         join a in db.Authors on ab.AuthorId equals a.ID
                         select new
                         {
                             Id = b.ID,
                             Title = b.Title,
                             Author = a.Name
                         }).ToList();

            if (books != null)
            {
                books.ForEach(b =>
                {
                    var result = bookViewModels.FirstOrDefault(bvm => bvm.ID == b.Id);

                    if (result != null)
                    {
                        result.Authors.Add(b.Author);
                    }
                    else
                    {
                        var x = new BookViewModel(b.Id, b.Title);
                        x.Authors.Add(b.Author);

                        bookViewModels.Add(x);
                    }
                });
            }

            return View(bookViewModels);
        }

        // GET: Books/Details/5
        public ActionResult Details(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //the result is a list of item with the same ID and Title
            var book = (from b in db.Books
                        join ab in db.BookAuthors on b.ID equals ab.BookId
                        join a in db.Authors on ab.AuthorId equals a.ID
                        where b.ID.Equals(id)
                        select new
                        {
                            Id = b.ID,
                            Title = b.Title,
                            Author = a.Name
                        }).ToList();

            BookViewModel bookViewModel;
            if (book != null)
            {
                bookViewModel = new BookViewModel(book[0].Id, book[0].Title);

                book.ForEach(b => bookViewModel.Authors.Add(b.Author));
            }
            else
            {
                return HttpNotFound();
            }

            return View(bookViewModel);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            BookEditModel books = new BookEditModel() { Authors = PopulateAuthorsList() };
            return View(books);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,SelectedAuthors")] BookEditModel bookEditModel)
        {
            if (ModelState.IsValid)
            {
                string id = Guid.NewGuid().ToString();

                db.Books.Add(MapBookEditModelToBook(id, bookEditModel));
                db.BookAuthors.AddRange(MapBookEditModelToBookAuthors(id, bookEditModel));
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookEditModel);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(string id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private List<SelectListItem> PopulateAuthorsList()
        {
            return (from d in db.Authors
                    orderby d.Name
                    select new SelectListItem()
                    {
                        Text = d.Name,
                        Value = d.ID
                    }).ToList();
        }

        private Book MapBookEditModelToBook(string id, BookEditModel model)
        {
            return new Book() { ID = id, Title = model.Title };
        }

        private IEnumerable<BookAuthors> MapBookEditModelToBookAuthors(string id, BookEditModel model)
        {
            var result = model.SelectedAuthors.Select(a =>
            {
                return new BookAuthors() { ID = Guid.NewGuid().ToString(), BookId = id, AuthorId = a };
            }
            );

            return result;
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
