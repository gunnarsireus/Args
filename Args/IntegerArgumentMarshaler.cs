//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace Args
{
	using static Args.ArgsException.ErrorCode;

	public class IntegerArgumentMarshaler : ArgumentMarshaler
	{
	  private int intValue = 0;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void set(Iterator<String> currentArgument) throws ArgsException
	  public virtual void set(IEnumerator<string> currentArgument)
	  {
		string parameter = null;
		try
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  parameter = currentArgument.next();
		  intValue = int.Parse(parameter);
		}
		catch (NoSuchElementException)
		{
		  throw new ArgsException(MISSING_INTEGER);
		}
		catch (System.FormatException)
		{
		  throw new ArgsException(INVALID_INTEGER, parameter);
		}
	  }

	  public static int getValue(ArgumentMarshaler am)
	  {
		if (am != null && am is IntegerArgumentMarshaler)
		{
		  return ((IntegerArgumentMarshaler) am).intValue;
		}
		else
		{
		  return 0;
		}
	  }
	}

}