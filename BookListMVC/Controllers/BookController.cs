using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BookListMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookListMVC.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            IndexModel indexModel = new IndexModel { Books = await _db.Book.ToListAsync() };

            return View(indexModel);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            CreateModel createModel = new CreateModel();

            if (id == null)
            {
                createModel.Book = new Book();
                return View(createModel);
            }
            else
            {
                createModel.Book = await _db.Book.FirstOrDefaultAsync(x => x.Id == id);

                if (createModel.Book == null)
                {
                    return NotFound();
                }
                return View(createModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    _db.Book.Add(book);
                }
                else
                {
                    _db.Book.Update(book);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound(new { code = "404", message = "Not found", detailedMessage = string.Format("Book with id {0} was not found, has it already been deleted (reload the page)", id) });
            }

            _db.Remove(book);
            await _db.SaveChangesAsync();
            return new JsonResult(new { ResponseMessage = string.Format("Book \"{0}\" successfully removed", book.Name) });
        }
    }
}

