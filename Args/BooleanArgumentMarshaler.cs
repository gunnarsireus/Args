//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System.Collections.Generic;

namespace com.cleancoder.args
{

	public class BooleanArgumentMarshaler : IArgumentMarshaler
	{
	  private bool booleanValue = false;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void set(java.util.Iterator<String> currentArgument) throws ArgsException
	  public virtual void set(IEnumerator<string> currentArgument)
	  {
		booleanValue = true;
	  }

	  public static bool getValue(IArgumentMarshaler am)
	  {
		if (am != null && am is BooleanArgumentMarshaler)
		{
		  return ((BooleanArgumentMarshaler) am).booleanValue;
		}
		else
		{
		  return false;
		}
	  }
	}

}