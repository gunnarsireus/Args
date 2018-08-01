namespace com.cleancoder.args
{
    public interface IIterator<T>
    {
        bool HasNext();
        T Next();
        void Remove();
    }
}
