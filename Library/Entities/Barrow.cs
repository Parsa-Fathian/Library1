public class Barrow : IEntity
{
    public int Id { get; set; }

    public int PersonId { get; set; }
    public Person Person { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }
    
    public DateTime Date { get; set; }
}