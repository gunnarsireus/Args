//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

namespace Args
{
	using TestCase = junit.framework.TestCase;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static ErrorCode.*;

	public class ArgsExceptionTest : TestCase
	{
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testUnexpectedMessage() throws Exception
	  public virtual void testUnexpectedMessage()
	  {
		ArgsException e = new ArgsException(UNEXPECTED_ARGUMENT, 'x', null);
		assertEquals("Argument -x unexpected.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testMissingStringMessage() throws Exception
	  public virtual void testMissingStringMessage()
	  {
		ArgsException e = new ArgsException(MISSING_STRING, 'x', null);
		assertEquals("Could not find string parameter for -x.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testInvalidIntegerMessage() throws Exception
	  public virtual void testInvalidIntegerMessage()
	  {
		ArgsException e = new ArgsException(INVALID_INTEGER, 'x', "Forty two");
		assertEquals("Argument -x expects an integer but was 'Forty two'.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testMissingIntegerMessage() throws Exception
	  public virtual void testMissingIntegerMessage()
	  {
		ArgsException e = new ArgsException(MISSING_INTEGER, 'x', null);
		assertEquals("Could not find integer parameter for -x.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testInvalidDoubleMessage() throws Exception
	  public virtual void testInvalidDoubleMessage()
	  {
		ArgsException e = new ArgsException(INVALID_DOUBLE, 'x', "Forty two");
		assertEquals("Argument -x expects a double but was 'Forty two'.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testMissingDoubleMessage() throws Exception
	  public virtual void testMissingDoubleMessage()
	  {
		ArgsException e = new ArgsException(MISSING_DOUBLE, 'x', null);
		assertEquals("Could not find double parameter for -x.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testMissingMapMessage() throws Exception
	  public virtual void testMissingMapMessage()
	  {
		ArgsException e = new ArgsException(MISSING_MAP, 'x', null);
		assertEquals("Could not find map string for -x.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testMalformedMapMessage() throws Exception
	  public virtual void testMalformedMapMessage()
	  {
		ArgsException e = new ArgsException(MALFORMED_MAP, 'x', null);
		assertEquals("Map string for -x is not of form k1:v1,k2:v2...", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testInvalidArgumentName() throws Exception
	  public virtual void testInvalidArgumentName()
	  {
		ArgsException e = new ArgsException(INVALID_ARGUMENT_NAME, '#', null);
		assertEquals("'#' is not a valid argument name.", e.errorMessage());
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public void testInvalidFormat() throws Exception
	  public virtual void testInvalidFormat()
	  {
		ArgsException e = new ArgsException(INVALID_ARGUMENT_FORMAT, 'x', "$");
		assertEquals("'$' is not a valid argument format.", e.errorMessage());
	  }
	}


}