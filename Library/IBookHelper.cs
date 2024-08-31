public interface IBookHelper
{
    public Book Add();
    public List<Book> List();
    public List<Book> Search(int id, string title,string auther);
}