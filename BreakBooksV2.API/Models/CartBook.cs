
﻿namespace BreakBooks.Models
{
    public class CartBook
    {
        public int? CartId { get; internal set; }
        public int? BookId { get; internal set; }
        public virtual Cart? Cart { get; internal set; }
        public virtual Book? Book { get; internal set; }
    }
}