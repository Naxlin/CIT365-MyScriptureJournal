using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Data;
using MyScriptureJournal.Models;
using MyScriptureJournal.Pages;

namespace MyScriptureJournal.Pages_Scriptures
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Data.MyScriptureJournalContext _context;

        // Initializing sort & filter variables:
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public List<string> BookNames;

        public IndexModel(MyScriptureJournal.Data.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Scripture> Scriptures { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            // Appending values to sort & filter
            DateSort = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            BookSort = sortOrder == "Book" ? "book_desc" : "Book";
            CurrentFilter = searchString;

            IQueryable<Scripture> ScriptureIQ = from s in _context.Scripture select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                ScriptureIQ = ScriptureIQ.Where(s => s.Book.BookName.Contains(searchString)
                                                || s.Note.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "book_desc":
                    ScriptureIQ = ScriptureIQ.OrderByDescending(s => s.Book.BookName);
                    break;
                case "Book":
                    ScriptureIQ = ScriptureIQ.OrderBy(s => s.Book.BookName);
                    break;
                case "date_desc":
                    ScriptureIQ = ScriptureIQ.OrderByDescending(s => s.Date);
                    break;
                default:
                    ScriptureIQ = ScriptureIQ.OrderBy(s => s.Date);
                    break;
            }

            Scriptures = await ScriptureIQ
                .Include(s => s.Book)
                .Include(s => s.Book.Volume)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
