using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Volume
    {
        // Unique ID for the P_Key of the database
        public int ID { get; set; }

        // String for the Volume of scripture e.g. Old or New Testament, Book of Mormon, etc.
        [Required, StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
    }
}