using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();
            if (id == null)
            {
                // When creating, this is called as ID is null.
                return Page();
            }

            // When and ID is provided (meaning that this is an edit) then the Book object is queried and populated.
            Book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                //Book bookToUpdate = await _db.Book.FindAsync(Book.Id);
                //if (bookToUpdate != null)
                //{
                //    bookToUpdate.Name = Book.Name;
                //    bookToUpdate.Author = Book.Author;
                //    bookToUpdate.ISBN = Book.ISBN;
                //    await _db.SaveChangesAsync();
                //    return RedirectToPage("Index");
                //}
                //else
                //{
                //    return Page();
                //}

                // If newly initialized the id is 0
                if (Book.Id == 0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book);
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}