using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sequences.Library
{
    public class StringSequence
    {
        private readonly List<string> _list = new List<string>();

        // "delegation" - this class implements Add by delegating the work to another class
        public void Add(string item)
        {
            _list.Add(item);
        }

        public void Remove(string item)
        {
            _list.Remove(item);
        }

        // overload index operator with delegation to the list
        public string this[int index] {
            get => _list[index];
            set => _list[index] = value;
        }

        public string LongestString()
        {
            // foreach loop is available on any class that implements the IEnumerable interface
            // LINQ is available on any IEnumerable also
            var maxLength = _list.Max(s => s.Length);
            return _list.First(s => s.Length == maxLength);
        }
    }
}
