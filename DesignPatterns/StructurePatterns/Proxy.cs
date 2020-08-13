using DesignPatterns.BehavioralPatterns.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DesignPatterns.StructurePatterns.Proxy
{
    //
    // Fromal form
    //
    class Client
    {
        void Main()
        {
            Subject subject = new Proxy();
            subject.Request();
        }
    }
    abstract class Subject
    {
        public abstract void Request();
    }

    class RealSubject : Subject
    {
        public override void Request() { }
    }
    class Proxy : Subject
    {
        RealSubject realSubject;
        public override void Request()
        {
            if (realSubject == null)
                realSubject = new RealSubject();
            realSubject.Request();
        }
    }
    //
    // Example
    //
    class Program
    {
        static void Main()
        {
            using(IBook book = new BookStoreProxy())
            {
                Page page1 = book.GetPage(1);
                Console.WriteLine(page1.Text);

                Page page2 = book.GetPage(2);
                Console.WriteLine(page2.Text);

                Page page3 = book.GetPage(3);
                Console.WriteLine(page3.Text);
            }
        }
    }
    class Page
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
    }
    class PageContext : DbContext
    {
        public DbSet<Page> Pages { get; set; }
    }
    interface IBook : IDisposable
    {
        Page GetPage(int number);
    }
    class BookStore : IBook
    {
        PageContext db;
        public BookStore()
        {
            db = new PageContext();
        }
        public Page GetPage(int number)
        {
            return db.Pages.FirstOrDefault(p => p.Number == number);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
    class BookStoreProxy : IBook
    {
        List<Page> pages;
        BookStore bookStore;
        public BookStoreProxy()
        {
            pages = new List<Page>();
        }
        public Page GetPage(int number)
        {
            Page page = pages.FirstOrDefault(p => p.Number == number);
            if (page == null)
            {
                if (bookStore == null)
                    bookStore = new BookStore();
                page = bookStore.GetPage(number);
                pages.Add(page);
            }
            return page;
        }
        public void Dispose()
        {
            if (bookStore != null)
                bookStore.Dispose();
        }
    }
}
