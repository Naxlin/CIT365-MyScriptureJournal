using MyScriptureJournal.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages
{
    public class NameByIdPopulator : PageModel
    {
        public ValueTask<Volume> VolName { get; set; }
        public ValueTask<Book> BookName { get; set; }
        public string Name { get; set; }

        public string ConvertIdToName(string table, int id, MyScriptureJournal.Data.MyScriptureJournalContext _context)
        {
            if (table == "Volume")
            {
                VolName = _context.Volume.FindAsync(id);
                Name = VolName.Result.VolumeName;
                return Name;
            }
            else if (table == "Book")
            {
                BookName = _context.Book.FindAsync(id);
                Name = BookName.Result.BookName;
                return Name;
            }
            else
            {
                return ""; // Exit, no context found.
            }
        }
    }
}