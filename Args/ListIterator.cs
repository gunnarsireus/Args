using System.Collections.Generic;

namespace com.cleancoder.args
{
    public class ListIterator<T> : IListIterator<T>
    {
        public IList<T> List = new List<T>();

        int position = -1;

        public void Add(T t)
        {
            List.Add(t);
        }

        public bool HasNext()
        {
            return (position < List.Count - 1);
        }

        public bool HasPrevious()
        {
            return (position > 0);
        }

        public T Next()
        {
            position++;
            if (position > List.Count - 1)
            {
                throw new NoSuchElementException();
            }
            return List[position];
        }

        public int NextIndex()
        {
            return position + 1;
        }

        public T Previous()
        {
            position--;
            if (position < 0)
            {
                throw new NoSuchElementException();
            }
            return List[position];
        }

        public int PreviousIndex()
        {
            return position - 1;
        }

        public void Remove()
        {
            if (position < List.Count)
            {
                List.Remove(List[position]);
            }
            else
            {
                throw new NoSuchElementException();
            }
        }

        public void Set(T t)
        {
            if (position < List.Count)
            {
                List[position] = t;
            }
            else
            {
                throw new NoSuchElementException();
            }
        }
    }
}
