using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Dz_Indexators
{
    class Book
    {
        public string Author { get; set; }
        public string NameBook { get; set; }
        public string Genre { get; set; }
        private int pages { get; set; }
        public int Pages
        {
            get { return pages; }

            set
            {
                if (value >= 0)
                {
                    pages = value;
                }
                else
                {
                    throw new ArgumentException("Incorrect pages!");
                }
            }
        }
        public Book(string author, string nameBook, string genre, int pages)
        {
            Author = author;
            NameBook = nameBook;
            Genre = genre;
            Pages = pages;
        }
        public void Print()
        {
            Console.WriteLine($"Author : {Author}, title : {NameBook}, genre : {Genre}, pages : {Pages}");
        }

    }
    class BookList
    {
        private Book[] books;
        public BookList(int size)
        {
            books = new Book[size];
        }
        public void AddBook(Book book)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == null)
                {
                    books[i] = book;
                    return;
                }
            }
            throw new InvalidOperationException("The book list is full.");
        }
        public void RemoveBook(Book book)
        {
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i] == book)
                {
                    books[i] = null;
                    return;
                }
            }
        }
        public bool ContainsBook(Book book)
        {
            return books.Contains(book);
        }

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < books.Length)
                {
                    return books[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (index >= 0 && index < books.Length)
                {
                    books[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        public Book this[string name]
        {
            get
            {
                foreach (var book in books)
                {
                    if (book != null && book.NameBook == name)
                    {
                        return book;
                    }
                }
                return null;
            }
        }
        public int Length => books.Length;

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList myBookList = new BookList(10);
            myBookList.AddBook(new Book("Тарас Шевченко", "Кобзар", "Поезія", 115));
            myBookList.AddBook(new Book("Джордж Орвелл", "1984", "Роман-антиутопія", 312));
            myBookList.AddBook(new Book("Валер'ян Підмогильний", "Місто", "Урбаністичний роман", 238));
            myBookList[0].Print();
            myBookList[1].Print();
            myBookList[2].Print();

            Console.WriteLine($"Is '1984' in the list? " + myBookList.ContainsBook(new Book("", "1984", "", 0)));
            myBookList.RemoveBook(new Book("", "1984", "", 312));
            Console.WriteLine("Number of books in the list: " + myBookList.Length);
            Console.WriteLine("First book in the list: ");
            myBookList[0].Print();
        }
    }
}