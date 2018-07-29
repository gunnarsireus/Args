//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;
using static com.cleancoder.args.ArgsException;

namespace com.cleancoder.args
{

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static com.cleancoder.args.ArgsException.ErrorCode.MISSING_STRING;

	public class StringArgumentMarshaler : IArgumentMarshaler
	{
	  private string stringValue = "";

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void set(java.util.Iterator<String> currentArgument) throws ArgsException
	  public virtual void set(IListIterator<string> currentArgument)
	  {
		try
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  stringValue = currentArgument.Next();
		}
		catch (NoSuchElementException)
		{
		  throw new ArgsException(ErrorCode.MISSING_STRING);
		}
	  }

	  public static string getValue(IArgumentMarshaler am)
	  {
		if (am != null && am is StringArgumentMarshaler)
		{
		  return ((StringArgumentMarshaler) am).stringValue;
		}
		else
		{
		  return "";
		}
	  }
	}

}