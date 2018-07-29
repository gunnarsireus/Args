//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace com.cleancoder.args
{

    public interface IArgumentMarshaler
    {
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: void set(java.util.Iterator<String> currentArgument) throws ArgsException;
        void set(IListIterator<string> currentArgument);
    }

}