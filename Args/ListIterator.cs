namespace com.cleancoder.args
{
    public class ListIterator<T> : Iterator<T>,IListIterator<T>
    {
        public void Add(T t)
        {
            List.Add(t);
        }

        public bool HasPrevious()
        {
            return (position > 0);
        }

        public int NextIndex()
        {
            return position ;
        }

        public T Previous()
        {
            if (position < 1)
            {
                throw new NoSuchElementException();
            }
            return List[--position];
        }

        public int PreviousIndex()
        {
            return position - 1;
        }

        public void Set(T t)
        {
            if (position < 0 || position > List.Count - 1)
            {
                throw new NoSuchElementException();
            }
            else
            {
                List[position] = t;
            }
        }
    }
}
