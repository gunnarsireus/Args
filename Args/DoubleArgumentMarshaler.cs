//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;
using static Args.ArgsException;

namespace Args
{
	using static ErrorCode;

	public class DoubleArgumentMarshaler : ArgumentMarshaler
	{
	  private double doubleValue = 0;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void set(Iterator<String> currentArgument) throws ArgsException
	  public virtual void set(IEnumerator<string> currentArgument)
	  {
		string parameter = null;
		try
		{
//JAVA TO C# CONVERTER TODO TASK: Java iterators are only converted within the context of 'while' and 'for' loops:
		  parameter = currentArgument.Current;
		  doubleValue = double.Parse(parameter);
		}
		catch (NoSuchElementException)
		{
		  throw new ArgsException(MISSING_DOUBLE);
		}
		catch (System.FormatException)
		{
		  throw new ArgsException(INVALID_DOUBLE, parameter);
		}
	  }

	  public static double getValue(ArgumentMarshaler am)
	  {
		if (am != null && am is DoubleArgumentMarshaler)
		{
		  return ((DoubleArgumentMarshaler) am).doubleValue;
		}
		else
		{
		  return 0.0;
		}
	  }
	}

}