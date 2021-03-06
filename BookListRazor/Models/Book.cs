﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Book Name")]
        public string Name { get; set; }
        [Display(Name = "Book author")]
        public string Author { get; set; }
        public string ISBN { get; set; }

    }
}
