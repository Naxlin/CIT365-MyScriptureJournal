using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Book
    {
        // Unique ID for the P_Key of the database
        public int ID { get; set; }

        // String for the Book of scripture e.g. 1 Nephi (will be changing this to dropdown)
        [Required, StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        // Scripture Volume F_KEY e.g. Old or New Testament, Book of Mormon, etc. 
        [Required, Range(0, 4)]
        public int Volume { get; set; }
    }
}