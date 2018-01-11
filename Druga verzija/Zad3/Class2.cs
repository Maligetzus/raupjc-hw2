using System.Collections;
using System.Collections.Generic;

namespace Zad3
{
    public class GenericListEnumerator<X> : IEnumerator<X>
    {
        private int _index;
        private GenericList<X> _list;

        public GenericListEnumerator(GenericList<X> list)
        {
            _index = -1;
            _list = list;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _index++;
            return _index <= _list.GetlastIndex;
        }

        public void Reset()
        {
            _index = -1;
        }

        public X Current { get => _list.GetinternalStorage[_index]; }

        object IEnumerator.Current { get => Current; }
    }
}