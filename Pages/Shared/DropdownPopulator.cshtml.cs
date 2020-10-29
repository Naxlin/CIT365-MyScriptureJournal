using MyScriptureJournal.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MyScriptureJournal.Pages
{
    public class DropdownPopulator : PageModel
    {
        public SelectList Dropdown { get; set; }

        public void PopulateDropdown(string table, MyScriptureJournal.Data.MyScriptureJournalContext _context,
            object selectedItem = null)
        {
            if (table == "Volume")
            {
                var query = from list in _context.Volume
                                   orderby list.VolumeId // Sort by name.
                                   select list;
                Dropdown = new SelectList(query.AsNoTracking(),
                        "ID", "Name", selectedItem);
            }
            else if (table == "Book")
            {
                var query = from list in _context.Book
                                   orderby list.BookId // Sort by name.
                                   select list;
                Dropdown = new SelectList(query.AsNoTracking(),
                        "ID", "Name", selectedItem);
            }
            else
            {
                return; // Exit, no context found.
            }
        }
    }
}