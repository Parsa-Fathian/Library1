using System;
using System.Collections.Generic;
using System.Threading.Channels;

class menu
{
    public void Show_menu()
    {
        Console.WriteLine("\n\nLibrary Management System");
        Console.WriteLine("2. Add Member");
        Console.WriteLine("3. Display Books");
        Console.WriteLine("4. Display Members");
        Console.WriteLine("5.Barrow Books");
        Console.WriteLine("6.Show barrows");
        Console.WriteLine("1. Add Book");
        Console.WriteLine("7.Return");
        Console.WriteLine("8. Search");
        Console.WriteLine("9. History");
        Console.WriteLine("10. Exit");
        Console.Write("Select an option: ");
    }
}

class Library
{
    // public List<Book> Books = new ();
    public List<Book> books = new List<Book>();
    public List<Person> Persons = new List<Person>();
    public List<Barrow> Barrows = new List<Barrow>();
    public List<History> Histories = new List<History>();
    // public List<time> time = new List<time>();
    int i = 0;
    int v = 0;
    public string time;

    public void add_book()
    {
        int num;
        Console.WriteLine("Enter book id:");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int id))
        {
            var isDuplicate = books.Any(i => i.Id == id);
            if (isDuplicate == true)
            {
                Console.WriteLine("THIS ID HAS EXIST");
                return;
            }

            Console.WriteLine("Enter Title: ");
            string title = Console.ReadLine();
            // var isDuplicateTitile = books.Any(i => i.Title == Console.ReadLine());
            var isDuplicateTitile = books.Any(i => i.Title == title);

            if (isDuplicateTitile == true)
                Console.WriteLine("THIS ID HAS EXIST");

            Console.WriteLine("Author:");
            string author = Console.ReadLine();
            Console.WriteLine("quant:");
            int quant = Convert.ToInt32(Console.ReadLine());

            if (quant < 1)
            {
                Console.WriteLine("Negative or zero numbers are not acceptable");
                Console.ReadKey();
                return;
            }

            books.Add(new Book
            {
                Id = id,
                Title = title,
                Author = author,
                Quant = quant,
                Time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            });
            Histories.Add(new History
            {
            Id = id,
            Bar_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
            });
            Console.WriteLine("Added successful");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer");
            Console.ReadKey();
        }
    }


    public void add_member()
    {
        Console.WriteLine("Enter Firstname");
        string x1 = Console.ReadLine();
        Console.WriteLine("Enter Lasttname");
        string x2 = Console.ReadLine();
        Console.WriteLine("ENTER ID");
        int x3 = Convert.ToInt32(Console.ReadLine());
        foreach (var ass in Persons)
        {
            if (ass.Id == x3)
            {
                Console.WriteLine("THIS ID HAS EXIST");
                Console.ReadKey();
                return;
            }
        }

        Person per = new Person(x3, x1, x2);
        Persons.Add(per);
        Console.WriteLine("Added successful");
        Console.ReadKey();
    }


    public void Display()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
        }
        else
        {
            foreach (var book in books)
            {
                book.DisplayInfo();
            }
        }

        Console.ReadKey();
    }

    public void ShowMember()
    {
        foreach (var ss in Persons)
        {
            ss.ShowMember();
        }

        Console.ReadKey();
    }


    public void barrow()
    {
        Console.WriteLine("Enter Member ID:");
        int memberId = Convert.ToInt32(Console.ReadLine());
        Person member = null;
        //Barrow memmber = null;
        foreach (var person in Persons)
        {
            if (person.Id == memberId)
            {
                member = person;
                break;
            }
        }

        if (member == null)
        {
            Console.WriteLine("Member not found.");
            return;
        }

        Console.WriteLine("Enter Book ID to borrow:");
        int bookId = Convert.ToInt32(Console.ReadLine());
        Book book = null;
        foreach (var b in books)
        {
            if (b.Id == bookId)
            {
                book = b;
                break;
            }
        }

        Barrow bar = new Barrow(memberId, bookId);
        Barrows.Add(bar);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
        }
        else
        {
            book.BorrowBook();
            Console.WriteLine("Book borrowed successfully.");
        }

        Console.ReadKey();
    }


    public void show_barow()
    {
        foreach (var boook in Barrows)
        {
            boook.ShowBarows();
        }

        Console.ReadKey();
    }

    public void Return()
    {
        Console.WriteLine("Enter Book ID to return:");
        int bookId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter Person ID to return:");
        int persId = Convert.ToInt32(Console.ReadLine());

        // پیدا کردن کتاب با استفاده از Book ID
        Book book = null;
        foreach (Book b in books)
        {
            if (b.Id == bookId)
            {
                book = b;
                break;
            }
        }

        // پیدا کردن کاربر با استفاده از Person ID
        Person pers = null;
        foreach (Person p in Persons)
        {
            if (p.Id == persId)
            {
                pers = p;
                break;
            }
        }

        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        if (pers == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        // حذف رکوردهای قرض بر اساس Book ID و Person ID
        int removedCount = 0;
        for (int i = Barrows.Count - 1; i >= 0; i--)
        {
            if (Barrows[i].BID == bookId && Barrows[i].PID == persId)
            {
                Barrows.RemoveAt(i);
                removedCount++;
            }
        }

        if (removedCount > 0)
        {
            book.ReturnBook();
            Console.WriteLine("Book returned successfully.");
            foreach (var his in Histories)
            {
                if (his.Id ==persId )
                {
                    his.Ret_time = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                }
            }
        }
        else
        {
            Console.WriteLine("No matching borrow record found.");
        }

        Console.ReadKey();
    }

    public void search()
    {
        Console.WriteLine("Enter the title to search:");
        string titleToSearch = Console.ReadLine();

        var result = books.Where(i => i.Title.Contains(titleToSearch));

        if (result.Any() == false)
            Console.WriteLine("No books found.");

        Console.WriteLine("search result : ");

        foreach (var foundBook in result)
            foundBook.DisplayInfo();

        Console.ReadKey();
    }

    public void show_history()
    {
        foreach (var his in Histories)
        {
            his.show_History();
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
    Library lib = new Library();
        menu Show = new menu();
        while (true)
        {
            Show.Show_menu();
            string input = Console.ReadLine();
            if (int.TryParse(input, out int s))
            {
                if (s == 1)
                {
                    lib.add_book();
                }
                else if (s == 2)
                {
                    lib.add_member();
                }
                else if (s == 3)
                {
                    lib.Display();
                }
                else if (s == 4)
                {
                    lib.ShowMember();
                }
                else if (s == 5)
                {
                    lib.barrow();
                }
                else if (s == 6)
                {
                    lib.show_barow();
                }
                else if (s == 7)
                {
                    lib.Return();
                }
                else if (s == 8)
                {
                    lib.search();
                }
                else if (s == 9)
                {
                    lib.show_history();
                }
                else if (s == 10)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option. Please select a valid menu option.");
                }
            }
            else
            {
                //Console.ForegroundColor = System.Drawing.Color.Yellow;
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}

