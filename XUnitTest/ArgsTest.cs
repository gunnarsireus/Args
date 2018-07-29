//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================
using System;
using Xunit;
using System.Collections.Generic;
using com.cleancoder.args;
using static com.cleancoder.args.ArgsException;

namespace Args
{
    //using Test = org.junit.Test;

    //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
    //	import static ErrorCode.*;
    //JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
    //	import static org.junit.Assert.*;

    public class ArgsTest
    {
        private void Fail(ErrorCode e, char errorArgumentId, string errorParameter)
        {
            throw new ArgsException(e, errorArgumentId, errorParameter);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testCreateWithNoSchemaOrArguments() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestCreateWithNoSchemaOrArguments()
        {
            var args = new com.cleancoder.args.Args("", new string[0]);
            Assert.Equal(0, args.nextArgument());
        }


        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testWithNoSchemaButWithOneArgument() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestWithNoSchemaButWithOneArgument()
        {
            try
            {
                new com.cleancoder.args.Args("", new string[] { "-x" });
                //Fail(ErrorCode.UNEXPECTED_ARGUMENT, 'x', "");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.UNEXPECTED_ARGUMENT, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testWithNoSchemaButWithMultipleArguments() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestWithNoSchemaButWithMultipleArguments()
        {
            try
            {
                new com.cleancoder.args.Args("", new string[] { "-x", "-y" });
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.UNEXPECTED_ARGUMENT, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
            }

        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testNonLetterSchema() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestNonLetterSchema()
        {
            try
            {
                new com.cleancoder.args.Args("*", new string[] { });
                //fail("Args constructor should have thrown exception");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.INVALID_ARGUMENT_NAME, e.getErrorCode());
                Assert.Equal('*', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testInvalidArgumentFormat() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestInvalidArgumentFormat()
        {
            try
            {
                new com.cleancoder.args.Args("f~", new string[] { });
                //fail("Args constructor should have throws exception");
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.INVALID_ARGUMENT_FORMAT, e.getErrorCode());
                Assert.Equal('f', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testSimpleBooleanPresent() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestSimpleBooleanPresent()
        {
            var args = new com.cleancoder.args.Args("x", new string[] { "-x" });
            Assert.True(args.getBoolean('x'));
            Assert.Equal(1, args.nextArgument());
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testSimpleStringPresent() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestSimpleStringPresent()
        {
            var args = new com.cleancoder.args.Args("x*", new string[] { "-x", "param" });
            Assert.True(args.has('x'));
            Assert.Equal("param", args.getString('x'));
            Assert.Equal(2, args.nextArgument());
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testMissingStringArgument() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestMissingStringArgument()
        {
            try
            {
                new com.cleancoder.args.Args("x*", new string[] { "-x" });
                //fail();
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.MISSING_STRING, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testSpacesInFormat() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestSpacesInFormat()
        {
            var args = new com.cleancoder.args.Args("x, y", new string[] { "-xy" });
            Assert.True(args.has('x'));
            Assert.True(args.has('y'));
            Assert.Equal(1, args.nextArgument());
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testSimpleIntPresent() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestSimpleIntPresent()
        {
            var args = new com.cleancoder.args.Args("x#", new string[] { "-x", "42" });
            Assert.True(args.has('x'));
            Assert.Equal(42, args.getInt('x'));
            Assert.Equal(2, args.nextArgument());
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testInvalidInteger() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:       
        [Fact]
        public virtual void TestInvalidInteger()
        {
            try
            {
                new com.cleancoder.args.Args("x#", new string[] { "-x", "Forty two" });
                //fail();
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.INVALID_INTEGER, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
                Assert.Equal("Forty two", e.ErrorParameter);
            }

        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testMissingInteger() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestMissingInteger()
        {
            try
            {
                new com.cleancoder.args.Args("x#", new string[] { "-x" });
                //fail();
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.MISSING_INTEGER, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testSimpleDoublePresent() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestSimpleDoublePresent()
        {
            var args = new com.cleancoder.args.Args("x##", new string[] { "-x", "42.3" });
            Assert.True(args.has('x'));
            Assert.Equal(42.3, args.getDouble('x'), 3);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testInvalidDouble() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestInvalidDouble()
        {
            try
            {
                var args = new com.cleancoder.args.Args("x##", new string[] { "-x", "Forty two" });
                //fail();
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.INVALID_DOUBLE, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
                Assert.Equal("Forty two", e.ErrorParameter);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testMissingDouble() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestMissingDouble()
        {
            try
            {
                new com.cleancoder.args.Args("x##", new string[] { "-x" });
                //fail();
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.MISSING_DOUBLE, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testStringArray() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestStringArray()
        {
            var args = new com.cleancoder.args.Args("x[*]", new string[] { "-x", "alpha" });
            Assert.True(args.has('x'));
            string[] result = args.getStringArray('x');
            Assert.Single(result);
            Assert.Equal("alpha", result[0]);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testMissingStringArrayElement() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestMissingStringArrayElement()
        {
            try
            {
                new com.cleancoder.args.Args("x[*]", new string[] { "-x" });
                //fail();
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.MISSING_STRING, e.getErrorCode());
                Assert.Equal('x', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void manyStringArrayElements() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void ManyStringArrayElements()
        {
            var args = new com.cleancoder.args.Args("x[*]", new string[] { "-x", "alpha", "-x", "beta", "-x", "gamma" });
            Assert.True(args.has('x'));
            string[] result = args.getStringArray('x');
            Assert.Equal(3, result.Length);
            Assert.Equal("alpha", result[0]);
            Assert.Equal("beta", result[1]);
            Assert.Equal("gamma", result[2]);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void MapArgument() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void MapArgument()
        {
            var args = new com.cleancoder.args.Args("f&", new string[] { "-f", "key1:val1,key2:val2" });
            Assert.True(args.has('f'));
            IDictionary<string, string> map = args.getMap('f');
            Assert.Equal("val1", map["key1"]);
            Assert.Equal("val2", map["key2"]);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test(expected=ArgsException.class) public void malFormedMapArgument() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void MalFormedMapArgument()
        {
            try
            {
                var args = new com.cleancoder.args.Args("f&", new string[] { "-f", "key1:val1,key2" });
            }
            catch (ArgsException e)
            {
                Assert.Equal(ErrorCode.MALFORMED_MAP, e.getErrorCode());
                Assert.Equal('f', e.ErrorArgumentId);
            }
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void oneMapArgument() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void OneMapArgument()
        {
            var args = new com.cleancoder.args.Args("f&", new string[] { "-f", "key1:val1" });
            Assert.True(args.has('f'));
            IDictionary<string, string> map = args.getMap('f');
            Assert.Equal("val1", map["key1"]);
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testExtraArguments() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestExtraArguments()
        {
            var args = new com.cleancoder.args.Args("x,y*", new string[] { "-x", "-y", "alpha", "beta" });
            Assert.True(args.getBoolean('x'));
            Assert.Equal("alpha", args.getString('y'));
            Assert.Equal(3, args.nextArgument());
        }

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testExtraArgumentsThatLookLikeFlags() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void TestExtraArgumentsThatLookLikeFlags()
        {
            var args = new com.cleancoder.args.Args("x,y", new string[] { "-x", "alpha", "-y", "beta" });
            Assert.True(args.has('x'));
            Assert.False(args.has('y'));
            Assert.True(args.getBoolean('x'));
            Assert.False(args.getBoolean('y'));
            Assert.Equal(1, args.nextArgument());
        }
    }

}