namespace com.cleancoder.args
{
    public interface IListIterator<T>
    {
        void Add(T t);
        bool HasNext();
        bool HasPrevious();
        T Next();
        int NextIndex();
        T Previous();
        int PreviousIndex();
        void Remove();
        void Set(T t);
    }
}
