public class Person
{
    public Person(int id, string name, string lastName)
    {
        Id = id;
        Name = name;
        LastName = lastName;
        Time1 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }
    public int Id { get; set; }
    public  string Name { get; set; }
    public string LastName { get; set; }

    public string Time1 { get; set; }

    public void ShowMember()
    {
        Console.WriteLine($"ID= {Id} ,Name= {Name}, LastName = {LastName}, Time= {Time1}");
    }
}