
public class method 
{
    public List<Book> books;
    public List<Person> persons;
    public List<Barrow> barrows;
    public List<History> histories;
    
    public void DisplayInfo(Book book)
    {
        Console.WriteLine($"ID: {book.Id}, Title: {book.Title}, Author: {book.Author}, quant: {book.Quant} , Time: {book.Time}");
    }
    public void ShowMember(Person person)
    {
        Console.WriteLine($"ID= {person.Id} ,Name= {person.Name}, LastName = {person.LastName}, Time= {person.Time1}");
    }
    public void BorrowBook(Book quantBook)
    {
        if (quantBook.Quant > 0)
        {
            quantBook.Quant--;
        }
        else
        {
            Console.WriteLine("No more copies available to borrow.");
        }
    }
    public void ReturnBook(Book bookplus)
    {
        bookplus.Quant++;
    }
    public void show_History(History history)
    {
        if (history.Ret_time==null)
        {
            Console.WriteLine($"personID = {history.Id}, BarrowTime = {history.Bar_time}");
        }
        else
        {
            Console.WriteLine($"personID = {history.Id}, BarrowTime = {history.Bar_time} , ReturnTime = {history.Ret_time}");
        }
    }
    public void ShowBarows(Barrow barrow)
    {
        Console.WriteLine($"PERSON ID= {barrow.PID}  BOOK ID={barrow.BID}  Time= {barrow.Time2} ");
    }
    
}