using System.Collections.Generic;

namespace com.cleancoder.args
{
    public class ListIterator<T> : IListIterator<T>
    {
        private IList<T> _list = new List<T>();

        public IList<T> List
        {
            get { return _list; }
            set
            {
                _list = value;
                if (_list.Count > 0)
                {
                    _next = 0;
                }
            }
        }

        int? _cursor;
        int? _next;
        int? _previous;


        public void Add(T t)
        {
            List.Add(t);
        }

        public bool HasNext()
        {
            if (_list.Count > 0)
            {
                return (_next < _list.Count);
            }

            return false;
        }

        public bool HasPrevious()
        {
            if (_list.Count > 0)
            {
                return (_previous != null);
            }

            return false;
        }

        public T Next()
        {
            if (_cursor == null)
            {
                _cursor = 0;
                _next = 1;
                return List[0];
            }

            _previous = _cursor;
            _cursor++;
            _next = _cursor + 1;
            if (_cursor > _list.Count - 1)
            {
                throw new NoSuchElementException();
            }
            return List[(int)_cursor];
        }

        public int NextIndex()
        {
            if (_next != null)
            {
                return (int)_next;
            }
            else
            {
                return 0;
            }
        }

        public T Previous()
        {
            if (_cursor == null)
            {
                throw new NoSuchElementException();
            }
            if (_cursor > _list.Count - 1)
            {
                throw new NoSuchElementException();
            }
            _next--;
            _previous--;
            return List[(int)_cursor];
        }

        public int PreviousIndex()
        {
            if (_previous != null && _previous > -1)
            {
                return (int)_previous;
            }
            else
            {
                throw new NoSuchElementException();
            }
        }

        public void Remove()
        {
            if (_cursor != null)
            {
                List.Remove(List[(int)_cursor]);
            }
            else
            {
                throw new NoSuchElementException();
            }
        }

        public void Set(T t)
        {
            if (_cursor != null)
            {
                List[(int)_cursor] = t;
            }
            else
            {
                throw new NoSuchElementException();
            }
        }
    }
}
