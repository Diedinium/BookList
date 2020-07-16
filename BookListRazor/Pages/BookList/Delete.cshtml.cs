using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Book Book { get; set; }

        public IActionResult OnGet()
        {
            return RedirectToPage("Index");
        }

        public async Task<JsonResult> OnDelete(int id)
        {
            Book = await _db.Book.FindAsync(id);
            _db.Book.Remove(Book);
            await _db.SaveChangesAsync();
            return new JsonResult(new Response("Book successfully removed"));
        }
    }
}