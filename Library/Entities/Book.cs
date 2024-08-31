
    public class Book:IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quant { get; set; }
        public DateTime RegisterDate { get; set; }
    }