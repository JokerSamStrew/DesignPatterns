﻿using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace DesignPatterns.BehavioralPatterns.Iterator
{
    //
    // Formal Form
    //
    class Client
    {
        public void Main()
        {
            Aggregate a = new ConcreteAggregate();

            Iterator i = a.CreateIterator();

            object item = i.First();
            while (!i.IsDone())
            {
                item = i.Next();
            }
        }
    }

    abstract class Aggregate
    {
        public abstract Iterator CreateIterator();
        public abstract int Count { get; protected set; }
        public abstract object this[int index] { get; set; }
    }

    class ConcreteAggregate : Aggregate
    {
        private readonly ArrayList _items = new ArrayList();

        public override Iterator CreateIterator()
        {
            return new ConcreteIterator(this);
        }

        public override int Count
        {
            get { return _items.Count; }
            protected set { }
        }

        public override object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }
    abstract class Iterator
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    class ConcreteIterator : Iterator
    {
        private readonly Aggregate _aggregate;
        private int _current;

        public ConcreteIterator(Aggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;

            _current++;

            if (_current < _aggregate.Count)
            {
                ret = _aggregate[_current];
            }

            return ret;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }
    }

    //
    // Example
    //

    class Program
    {
        static void Main()
        {
            Library library = new Library();
            Reader reader = new Reader();
            reader.SeeBooks(library);
        }
    }

    class Reader
    {
        public void SeeBooks(Library library)
        {
            IBookIterator iterator = library.CreateNumerator();
            while(iterator.HasNext())
            {
                Book book = iterator.Next();
                Console.WriteLine(book.Name);
            }
        }
    }
    interface IBookIterator
    {
        bool HasNext();
        Book Next();
    }
    interface IBookNumerable
    {
        IBookIterator CreateNumerator();
        int Count { get; }
        Book this[int index] { get; }
    }
    class Book
    {
        public string Name { get; set; }
    }
    class Library : IBookNumerable
    {
        private Book[] books;
        public Library()
        {
            books = new Book[]
            {
                new Book{Name="War and peace"},
                new Book{Name="Fathers and sons"},
                new Book{Name="Cherry garden"}
            };
        }
        public int Count
        {
            get { return books.Length; }
        }
        public Book this[int index]
        {
            get { return books[index]; }
        }
        public IBookIterator CreateNumerator()
        {
            return new LibraryNumerator(this);
        }
    }
    class LibraryNumerator : IBookIterator
    {
        IBookNumerable aggregate;
        int index = 0;
        public LibraryNumerator(IBookNumerable a)
        {
            aggregate = a;
        }
        public bool HasNext()
        {
            return index < aggregate.Count;
        }
        public Book Next()
        {
            return aggregate[index++];
        }
    }
}
