﻿using LibraryAPI.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models.Books
{
    public class BookCreateDTO
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(50)]
        public string Author { get; set; }
        [MaxLength(4)]
        public int PublicationYear { get; set; }
        public int CategoryId { get; set; }
    }
}
