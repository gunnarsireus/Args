using System.Collections.Generic;

namespace com.cleancoder.args
{
    public class ListIterator<T> : IListIterator<T>
    {

        public IList<T> List = new List<T>();

        int? position;

        public void Add(T t)
        {
            List.Add(t);
        }

        public bool HasNext()
        {
            if (List.Count > 0)
            {
                if (position == null) return true;
                if (position < List.Count - 1) return true;
            }

            return false;
        }

        public bool HasPrevious()
        {
            if (List.Count > 0)
            {
                if (position == null) return true;
                if (position > 0) return true;
            }

            return false;
        }

        public T Next()
        {
            if (position == null)
            {
                position = 0;
                return List[0];
            }
            position++;
            if (position > List.Count - 1)
            {
                throw new NoSuchElementException();
            }
            return List[(int)position];
        }

        public int NextIndex()
        {
            if (position != null)
            {
                return (int)position + 1;
            }
            else
            {
                return 0;
            }
        }

        public T Previous()
        {
            if (position == null || position == 0)
            {
                throw new NoSuchElementException();
            }

            position--;
            return List[(int)position];

        }

        public int PreviousIndex()
        {
            if (position != null && position > 0)
            {
                return (int)position - 1;
            }
            throw new NoSuchElementException();
        }

        public void Remove()
        {
            if (position != null && position < List.Count)
            {
                List.Remove(List[(int)position]);
            }
            else
            {
                throw new NoSuchElementException();
            }
        }

        public void Set(T t)
        {
            if (position != null && position < List.Count)
            {
                List[(int)position] = t;
            }
            else
            {
                throw new NoSuchElementException();
            }
        }
    }
}
