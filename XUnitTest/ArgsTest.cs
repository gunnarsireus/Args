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

        //JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
        //ORIGINAL LINE: @Test public void testCreateWithNoSchemaOrArguments() throws Exception
        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
        [Fact]
        public virtual void testCreateWithNoSchemaOrArguments()
	  {
        com.cleancoder.args.Args args = new com.cleancoder.args.Args("", new string[0]);
		Assert.Equal(0, args.nextArgument());
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWithNoSchemaButWithOneArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testWithNoSchemaButWithOneArgument()
	  {
		try
		{
		  new com.cleancoder.args.Args("", new string[]{"-x"});
		  //fail();
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
	  public virtual void testWithNoSchemaButWithMultipleArguments()
	  {
		try
		{
		  new com.cleancoder.args.Args("", new string[]{"-x", "-y"});
		  //fail();
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
	  public virtual void testNonLetterSchema()
	  {
		try
		{
		  new com.cleancoder.args.Args("*", new string[]{});
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
	  public virtual void testInvalidArgumentFormat()
	  {
		try
		{
		  new com.cleancoder.args.Args("f~", new string[]{});
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
	  public virtual void testSimpleBooleanPresent()
	  {
        var args = new com.cleancoder.args.Args("x", new string[]{"-x"});
		Assert.True(args.getBoolean('x'));
		Assert.Equal(1, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleStringPresent() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSimpleStringPresent()
	  {
        var args = new com.cleancoder.args.Args("x*", new string[]{"-x", "param"});
		Assert.True(args.has('x'));
		Assert.Equal("param", args.getString('x'));
		Assert.Equal(2, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingStringArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testMissingStringArgument()
	  {
		try
		{
		  new com.cleancoder.args.Args("x*", new string[]{"-x"});
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
	  public virtual void testSpacesInFormat()
	  {
            com.cleancoder.args.Args args = new com.cleancoder.args.Args("x, y", new string[]{"-xy"});
		Assert.True(args.has('x'));
		Assert.True(args.has('y'));
		Assert.Equal(1, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleIntPresent() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSimpleIntPresent()
	  {
            com.cleancoder.args.Args args = new com.cleancoder.args.Args("x#", new string[]{"-x", "42"});
		Assert.True(args.has('x'));
		Assert.Equal(42, args.getInt('x'));
		Assert.Equal(2, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInvalidInteger() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testInvalidInteger()
	  {
		try
		{
		  new com.cleancoder.args.Args("x#", new string[]{"-x", "Forty two"});
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
	  public virtual void testMissingInteger()
	  {
		try
		{
		  new com.cleancoder.args.Args("x#", new string[]{"-x"});
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
	  public virtual void testSimpleDoublePresent()
	  {
            var args = new com.cleancoder.args.Args("x##", new string[]{"-x", "42.3"});
		Assert.True(args.has('x'));
		Assert.Equal(42.3, args.getDouble('x'),3);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInvalidDouble() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testInvalidDouble()
	  {
		try
		{
		  var args = new com.cleancoder.args.Args("x##", new string[]{"-x", "Forty two"});
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
	  public virtual void testMissingDouble()
	  {
		try
		{
		  new com.cleancoder.args.Args("x##", new string[]{"-x"});
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
	  public virtual void testStringArray()
	  {
            com.cleancoder.args.Args args = new com.cleancoder.args.Args("x[*]", new string[]{"-x", "alpha"});
		Assert.True(args.has('x'));
		string[] result = args.getStringArray('x');
		Assert.Equal(1, result.Length);
		Assert.Equal("alpha", result[0]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingStringArrayElement() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testMissingStringArrayElement()
	  {
		try
		{
		  new com.cleancoder.args.Args("x[*]", new string[] {"-x"});
		  //fail();
		}
		catch (ArgsException e)
		{
		  Assert.Equal(ErrorCode.MISSING_STRING,e.getErrorCode());
		  Assert.Equal('x', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void manyStringArrayElements() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void manyStringArrayElements()
	  {
            com.cleancoder.args.Args args = new com.cleancoder.args.Args("x[*]", new string[]{"-x", "alpha", "-x", "beta", "-x", "gamma"});
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
	  public virtual void MapArgument()
	  {
		var args = new com.cleancoder.args.Args("f&", new string[] {"-f", "key1:val1,key2:val2"});
		Assert.True(args.has('f'));
		IDictionary<string, string> map = args.getMap('f');
		Assert.Equal("val1", map["key1"]);
		Assert.Equal("val2", map["key2"]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=ArgsException.class) public void malFormedMapArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void malFormedMapArgument()
	  {
		var args = new com.cleancoder.args.Args("f&", new string[] {"-f", "key1:val1,key2"});
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void oneMapArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void oneMapArgument()
	  {
		var args = new com.cleancoder.args.Args("f&", new string[] {"-f", "key1:val1"});
		Assert.True(args.has('f'));
		IDictionary<string, string> map = args.getMap('f');
		Assert.Equal("val1", map["key1"]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtraArguments() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testExtraArguments()
	  {
		var args = new com.cleancoder.args.Args("x,y*", new string[]{"-x", "-y", "alpha", "beta"});
		Assert.True(args.getBoolean('x'));
		Assert.Equal("alpha", args.getString('y'));
		Assert.Equal(3, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtraArgumentsThatLookLikeFlags() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testExtraArgumentsThatLookLikeFlags()
	  {
		var args = new com.cleancoder.args.Args("x,y", new string[]{"-x", "alpha", "-y", "beta"});
		Assert.True(args.has('x'));
		Assert.False(args.has('y'));
		Assert.True(args.getBoolean('x'));
		Assert.False(args.getBoolean('y'));
		Assert.Equal(1, args.nextArgument());
	  }
	}

}