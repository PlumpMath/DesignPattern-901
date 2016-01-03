using System;
using System.Collections;
using static System.Console;

namespace IntSet
{
    /// <summary>
    /// 1. Design an internal "iterator" class for the "collection" class
    /// 2. Add a CreateIterator() member to the collection class
    /// 3. Clients ask the collection object to create an iterator object
    /// 4. Clients use the First(), IsDone(), Next(), and CurrentItem() protocol
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            var set = new IntSet();
            for (var i = 2; i < 10; i += 2)
            {
                set.Add(i);
            }
            for (var i = 1; i < 9; i++)
            {
                Write(i + "-" + set.IsMember(i) + "  ");
            }

            // 3. Clients ask the collection object to create many iterator objects
            var it1 = set.CreateIterator();
            var it2 = set.CreateIterator();

            // 4. Clients use the First(), IsDone(), Next(), CurrentItem() protocol
            Write("\nIterator:    ");
            for (it1.First(), it2.First(); !it1.IsDone(); it1.Next(), it2.Next())
            {
                Write(it1.CurrentItem() + " " + it2.CurrentItem() + "  ");
            }

            //C# uses a different collection traversal "idiom" called Enumerator
            Write("\nEnumeration: ");
            foreach (var element in set.GetHashtable().Keys)
            {
                Write(element + "  ");
            }

            WriteLine("");
            ReadKey();
        }
    }

    internal class IntSet
    {
        private readonly Hashtable _ht = new Hashtable();

        public void Add(int ins)
        {
            _ht.Add(ins, "null");
        }

        public bool IsMember(int i)
        {
            return _ht.ContainsKey(i);
        }

        public Hashtable GetHashtable()
        {
            return _ht;
        }

        // 2. Add a CreateIterator() member to the collection class
        public Iterator CreateIterator()
        {
            return new Iterator(this);
        }
    }

    // 1. Design an internal "iterator" class for the "collection" class
    internal class Iterator
    {
        private readonly IntSet _set;
        private IDictionaryEnumerator _enumerator;
        private int? _current;

        public Iterator(IntSet ins)
        {
            _set = ins;
        }

        public void First()
        {
            _enumerator = _set.GetHashtable().GetEnumerator();
        }

        public bool IsDone()
        {
            return _current == null;
        }

        public int? CurrentItem()
        {
            return _current;
        }

        public void Next()
        {
            try
            {
                _enumerator.MoveNext();
                _current = (int)_enumerator.Key;
            }
            catch (Exception)
            {
                _current = null;
            }
        }
    }
}