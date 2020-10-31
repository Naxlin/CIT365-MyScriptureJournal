using System;
using System.ComponentModel.DataAnnotations;

namespace MyScriptureJournal.Models
{
    public class Book
    {
        // Unique ID for the P_Key of the database
        public int BookId { get; set; }

        // String for the Book of scripture e.g. 1
        [Required, StringLength(60, MinimumLength = 3), Display(Name = "Book")]
        public string BookName { get; set; }

        // Scripture Volume F_KEY e.g. Old or New Testament, Book of Mormon, etc. 
        [Required, Range(1, 5), Display(Name = "Volume")]
        public int VolumeId { get; set; }

        // Navigation properties:
        public Volume Volume { get; set; }
    }
}