﻿using System.Linq;

namespace Mission09_jnw53.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set;}
        public PageInfo PageInfo { get; set;}
    }
}
