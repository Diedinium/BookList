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
        public async Task<IActionResult> Upsert(CreateModel createModel)
        {
            if (ModelState.IsValid)
            {
                if (createModel.Book.Id == 0)
                {
                    _db.Book.Add(createModel.Book);
                }
                else
                {
                    _db.Book.Update(createModel.Book);
                }

                await _db.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(createModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _db.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _db.Remove(book);
            await _db.SaveChangesAsync();
            return new JsonResult(new { ResponseMessage = "Book successfully removed" });
        }
    }
}

