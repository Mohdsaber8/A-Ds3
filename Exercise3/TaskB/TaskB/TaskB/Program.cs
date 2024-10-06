using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskB
{

    class Program
    {
        // generic selection sort to sort any type of data type, in this case attributes of book objects
        public static void SelectionSortGen<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int smallest = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(array[smallest]) < 0)
                        smallest = j;
                }
                Swap(ref array[i], ref array[smallest]);
            }
        }

        //generic swapping
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Select the type of sorting:");
            Console.WriteLine("1. Sort an array of integers");
            Console.WriteLine("2. Sort an array of Book objects");
            //Console.WriteLine("3. Sort an array of Book objects by Publication Year"); (Change Title within the book class to Publication_Year)
            Console.Write("Enter your choice (1, 2): ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Sorting an array of integers
                    int[] intArray = { 5, 3, 8, 4, 1 };
                    SelectionSortGen(intArray);
                    Console.WriteLine("\nSorted integers:");
                    foreach (int num in intArray)
                    {
                        Console.WriteLine(num);
                    }
                    break;

                case 2:
                    // Sort an array of Book objects
                    Book[] booksArray = {
                        new Book("Book CB", "Author C", 1235006, 2001),
                        new Book("Book AB", "Author A", 123457, 2003),
                        new Book("Book BA", "Author B", 123487, 2017)
                    };

                    // Sor books by Title
                    SelectionSortGen(booksArray);
                    Console.WriteLine("Sorted books by title:");
                    foreach (Book book in booksArray)
                    {
                        Console.WriteLine($"{book.Title} by {book.Author}, ISBN: {book.ISBN}, Year: {book.Publication_Year}");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
