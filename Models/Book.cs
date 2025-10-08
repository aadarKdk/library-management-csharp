namespace LibraryManagement
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }

    public Book(int id, string title, string author, bool isAvailable)
    {
        Id = id;
        Title = title;
        Author = author;
        IsAvailable = isAvailable;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"--- Book ID: {Id} ---");
        Console.WriteLine($"\tTitle: {Title}");
        Console.WriteLine($"\tAuthor: {Author}");
        Console.WriteLine($"\tAvailable: {(IsAvailable ? "Available" : "Not Available")}");
    }
    public string ToFileString()
    {
        return $"{Id}|{Title}|{Author}|{IsAvailable}";
    }
    public static Book FromFileString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length != 4)
        {
            throw new FormatException("Invalid book data format.");
        }
        int id = int.Parse(parts[0]);
        string title = parts[1];
        string author = parts[2];
        bool isAvailable = bool.Parse(parts[3]);
        return new Book(id, title, author, isAvailable);
    }
}
}