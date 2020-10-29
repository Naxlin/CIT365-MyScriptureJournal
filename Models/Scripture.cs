using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        // Unique ID for the P_Key of the database
        public int ScriptureId { get; set; }

        // F_KEY for the Book of scripture e.g. 1 Nephi, etc.
        // [Required, Range(0, 150)] // Range bugged out when IDs generated in the 2000 range.
        public int BookId { get; set; }

        // Scripture chapter
        [Required, Range(1, 151)]
        public int Chapter { get; set; }

        // Scripture verse
        [Required, Range(1, 256)]
        public int Verse { get; set; }

        // Scripture Journal Entry
        [StringLength(1000, MinimumLength = 0)]
        public string Note { get; set; }

        // Date the Note was added, retrieved from system at data/time of note added.
        public DateTime Date { get; set; }

        // Navigation properties:
        public Book Book { get; set; }
    }
}