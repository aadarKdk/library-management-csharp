using System;
using System.Collections.Generic;
using System.IO;

namespace LibraryManagement.Data
{
    public class BookFileManager
    {
        private string filePath;
        private List<Book> books;

        public BookFileManager(string filePath)
        {
            this.filePath = filePath;
            books = new List<Book>();
            LoadBooksFromFile();
        }
        private void LoadBooksFromFile()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);
                File.Create(filePath).Close();
            }
            books.Clear();
            string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    try
                    {
                        books.Add(Book.FromFileString(line));
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"Skipping invalid line: {line} ({ex.Message})");
                    }
                }
            }
        }
        private void SaveBooksToFile()
        {
            var lines = new List<string>();
            foreach (var book in books)
            {
                lines.Add(book.ToFileString());
            }
            File.WriteAllLines(filePath, lines);
        }
        public bool AddBook(Book newBook)
        {
            if (books.Exists(b => (b.Id == newBook.Id) && (b.Title.ToLower().Trim() == newBook.Title.ToLower().Trim())))
            {
                Console.WriteLine($"A book with ID {newBook.Id} already exists.");
                return false;
            }
            books.Add(newBook);
            SaveBooksToFile();
            Console.WriteLine($"Book '{newBook.Title}' added successfully.");
            return true;
        }
    }
}
