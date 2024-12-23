using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskB
{

using System;
using System.Collections.Generic;

namespace TaskB
    {
        class Program
        {
            // Generic selection sort to sort any type of data
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

            // Generic swapping
            public static void Swap<T>(ref T x, ref T y)
            {
                T temp = x;
                x = y;
                y = temp;
            }

            static void Main(string[] args)
            {
                Console.WriteLine("Select sorting type:\n1. Integers\n2. Books");
                Console.Write("Choice (1/2): ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        // Sorting integers
                        Console.Write("Number of integers: ");
                        int numIntegers = Convert.ToInt32(Console.ReadLine());
                        int[] intArray = new int[numIntegers];

                        Console.WriteLine("Enter integers:");
                        for (int i = 0; i < numIntegers; i++)
                        {
                            intArray[i] = Convert.ToInt32(Console.ReadLine());
                        }

                        SelectionSortGen(intArray);
                        Console.WriteLine("\nSorted integers:");
                        foreach (int num in intArray)
                        {
                            Console.WriteLine(num);
                        }
                        break;

                    case 2:
                        // Sorting books
                        Console.Write("Number of books: ");
                        int numBooks = Convert.ToInt32(Console.ReadLine());
                        List<Book> booksList = new List<Book>();

                        for (int i = 0; i < numBooks; i++)
                        {
                            Console.WriteLine($"Enter details for Book #{i + 1}:");
                            Console.Write("Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Author: ");
                            string author = Console.ReadLine();

                            Console.Write("ISBN: ");
                            int isbn = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Publication Year: ");
                            int publicationYear = Convert.ToInt32(Console.ReadLine());

                            booksList.Add(new Book(title, author, isbn, publicationYear));
                        }

                        Book[] booksArray = booksList.ToArray();
                        SelectionSortGen(booksArray);
                        Console.WriteLine("\nSorted books by title:");
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
}

