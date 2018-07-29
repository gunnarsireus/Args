//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace com.cleancoder.args
{
    using System.Linq;
    using static com.cleancoder.args.ArgsException.ErrorCode;

    public class StringArrayArgumentMarshaler : IArgumentMarshaler
    {
        private IList<string> strings = new List<string>();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void set(Iterator<String> currentArgument) throws ArgsException
        public virtual void set(IListIterator<string> currentArgument)
        {
            try
            {
                //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                strings.Add(currentArgument.Next());
            }
            catch (NoSuchElementException)
            {
                throw new ArgsException(MISSING_STRING);
            }
        }

        public static string[] getValue(IArgumentMarshaler am)
        {
            if (am != null && am is StringArrayArgumentMarshaler)
            {
                return ((StringArrayArgumentMarshaler)am).strings.ToArray();
            }
            else
            {
                return new string[0];
            }
        }
    }

}