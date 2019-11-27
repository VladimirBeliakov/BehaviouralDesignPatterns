using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    public class StringCollection : IEnumerable<string>
    {
        private readonly string _itemOne;
        private readonly string _itemTwo;
        private readonly string _itemThree;

        public StringCollection(string itemOne, string itemTwo, string itemThree)
        {
            _itemOne = itemOne;
            _itemTwo = itemTwo;
            _itemThree = itemThree;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new StringEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private class StringEnumerator : IEnumerator<string>
        {
            private readonly StringCollection _enumerable;

            public StringEnumerator(StringCollection enumerable)
            {
                _enumerable = enumerable;
            }

            public bool MoveNext()
            {
                if (Current == null)
                {
                    Current = _enumerable._itemOne;
                    return true;
                }

                if (ReferenceEquals(Current, _enumerable._itemOne))
                {
                    Current = _enumerable._itemTwo;
                    return true;
                }

                if (ReferenceEquals(Current, _enumerable._itemTwo))
                {
                    Current = _enumerable._itemThree;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                Current = null;
            }

            public void Dispose()
            {
            }

            public string Current { get; private set; }

            object IEnumerator.Current => Current;
        }
    }
}