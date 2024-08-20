
public class History
{
    public int Id { get; set; }
    public string Bar_time { get; set; }
    public string Ret_time { get; set; }

    public void show_History()
    {
        if (Ret_time==null)
        {
            Console.WriteLine($"personID = {Id}, BarrowTime = {Bar_time}");
        }
        else
        {
            Console.WriteLine($"personID = {Id}, BarrowTime = {Bar_time} , ReturnTime = {Ret_time}");
        }
    }
}