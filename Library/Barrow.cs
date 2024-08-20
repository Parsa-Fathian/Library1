
public class Barrow()
{
    public Barrow(int pid, int bid) : this()
    {
        PID = pid;
        BID = bid;
        Time2 = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
    }
    public int PID { get; set; }
    public int  BID { get; set; }
    public string Time2 { get; set; }
    
    public void ShowBarows()
    {
        Console.WriteLine($"PERSON ID= {PID}  BOOK ID={BID}  Time= {Time2} ");
    }
}