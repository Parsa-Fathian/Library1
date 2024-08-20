
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
        public int Quant { get; set; }

        public string Time { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}, quant: {Quant} , Time: {Time}");
        }
        public void BorrowBook()
        {
            if (Quant > 0)
            {
                Quant--;
            }
            else
            {
                Console.WriteLine("No more copies available to borrow.");
            }
        }
        public void ReturnBook()
        {
            Quant++;
        }
        public void DisplayInfosearch()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Quantity: {Quant}");
        }
    }
