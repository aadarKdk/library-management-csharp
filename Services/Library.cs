using System.Collections.Generic;

namespace LibraryManagement.Services
{
    public class Library
    {
        private List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }
        public void AddBook(Book book)
        { }

        public void BorrowBook()
        { }

        public void ReturnBook()
        { }

        public void ViewAllBooks()
        { }
        public void SearchBooks()
        { }
    }
}

