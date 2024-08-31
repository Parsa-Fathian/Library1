public class BookHelper : IBookHelper
{
    public Book Add()
    {
        Console.WriteLine("Enter Title: ");
        string title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title) == true)
        {
            Console.WriteLine("pls enter valid book title");
            Add();
        }

        Console.WriteLine("Author:");
        string author = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(title) == true)
        {
            Console.WriteLine("pls enter valid auther name");
            Add();
        }

        Console.WriteLine("quant:");
        int quant = Convert.ToInt32(Console.ReadLine());
        if (quant < 1)
        {
            Console.WriteLine("Negative or zero numbers are not acceptable");
            Add();
        }

        var book = new Book
        {
            Title = title,
            Author = author,
            Quant = quant,
            RegisterDate = DateTime.Now
        };
        
        // todo : add book to db using dbContext
        
        Console.WriteLine("Added successful");
        return book;
    }

    
    public List<Book> List()
    {
        return new List<Book>();
    }

    
    public List<Book> Search(int id, string title, string auther)
    {
        throw new NotImplementedException();
    }
}