//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using Xunit;
using static com.cleancoder.args.ArgsException;

namespace Args
{
    //using TestCase = junit.framework.TestCase;

    //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
    //	import static ErrorCode.*;

    public class ArgsExceptionTest
    {
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testUnexpectedMessage() throws Exception
        [Fact]
        public virtual void TestUnexpectedMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.UNEXPECTED_ARGUMENT, 'x', null);
            Assert.Equal("Argument -x unexpected.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testMissingStringMessage() throws Exception
        [Fact]
        public virtual void TestMissingStringMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.MISSING_STRING, 'x', null);
            Assert.Equal("Could not find string parameter for -x.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testInvalidIntegerMessage() throws Exception
        [Fact]
        public virtual void TestInvalidIntegerMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.INVALID_INTEGER, 'x', "Forty two");
            Assert.Equal("Argument -x expects an integer but was 'Forty two'.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testMissingIntegerMessage() throws Exception
        [Fact]
        public virtual void TestMissingIntegerMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.MISSING_INTEGER, 'x', null);
            Assert.Equal("Could not find integer parameter for -x.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testInvalidDoubleMessage() throws Exception
        [Fact]
        public virtual void TestInvalidDoubleMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.INVALID_DOUBLE, 'x', "Forty two");
            Assert.Equal("Argument -x expects a double but was 'Forty two'.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testMissingDoubleMessage() throws Exception
        [Fact]
        public virtual void TestMissingDoubleMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.MISSING_DOUBLE, 'x', null);
            Assert.Equal("Could not find double parameter for -x.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testMissingMapMessage() throws Exception
        [Fact]
        public virtual void TestMissingMapMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.MISSING_MAP, 'x', null);
            Assert.Equal("Could not find map string for -x.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testMalformedMapMessage() throws Exception
        [Fact]
        public virtual void TestMalformedMapMessage()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.MALFORMED_MAP, 'x', null);
            Assert.Equal("Map string for -x is not of form k1:v1,k2:v2...", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testInvalidArgumentName() throws Exception
        [Fact]
        public virtual void TestInvalidArgumentName()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.INVALID_ARGUMENT_NAME, '#', null);
            Assert.Equal("'#' is not a valid argument name.", e.errorMessage());
        }

        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        //ORIGINAL LINE: public void testInvalidFormat() throws Exception
        [Fact]
        public virtual void TestInvalidFormat()
        {
            var e = new com.cleancoder.args.ArgsException(ErrorCode.INVALID_ARGUMENT_FORMAT, 'x', "$");
            Assert.Equal("'$' is not a valid argument format.", e.errorMessage());
        }
    }


}