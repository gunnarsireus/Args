//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace com.cleancoder.args
{
    using static com.cleancoder.args.ArgsException.ErrorCode;

    public class MapArgumentMarshaler : IArgumentMarshaler
    {
        private IDictionary<string, string> map = new Dictionary<string, string>();

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void set(java.util.Iterator<String> currentArgument) throws ArgsException
        public virtual void set(Iterator<string> currentArgument)
        {
            try
            {
                //JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
                string[] mapEntries = currentArgument.Next().Split(",");
                foreach (string entry in mapEntries)
                {
                    string[] entryComponents = entry.Split(":", true);
                    if (entryComponents.Length != 2)
                    {
                        throw new ArgsException(MALFORMED_MAP);
                    }
                    map[entryComponents[0]] = entryComponents[1];
                }
            }
            catch (NoSuchElementException)
            {
                throw new ArgsException(MISSING_MAP);
            }
        }

        public static IDictionary<string, string> getValue(IArgumentMarshaler am)
        {
            if (am != null && am is MapArgumentMarshaler)
            {
                return ((MapArgumentMarshaler)am).map;
            }
            else
            {
                return new Dictionary<string, string>();
            }
        }
    }

}