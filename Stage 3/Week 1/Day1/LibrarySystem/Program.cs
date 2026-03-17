using System;

namespace Library;
class Program
{
    static void Main()
    {
        Book myBook = new Book();
        myBook.ReadBook();

        Library.CheckoutBook();

        Console.WriteLine("End of program.");
    }
}