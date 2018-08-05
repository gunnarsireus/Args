using System.Collections.Generic;

namespace com.cleancoder.args
{
    public class Iterator<T> : IIterator<T>
    {
        public IList<T> List = new List<T>();

        protected int position = 0;

        public bool HasNext()
        {
            return (position < List.Count);
        }

        public T Next()
        {
            if (position > List.Count - 1)
            {
                throw new NoSuchElementException();
            }
            return List[position++];
        }

        public void Remove()
        {
            if (position < 0 || position > List.Count - 1)
            {
                throw new NoSuchElementException();
            }
            else
            {
                List.Remove(List[position]);
            }
        }
    }
}
