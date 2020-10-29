using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Book { get; set; }
        [Range(1, 151)]
        public int Chapter { get; set; }
        [Range(1, 256)]
        public int Verse { get; set; }

        public DateTime NoteDate { get; set; }
    }
}