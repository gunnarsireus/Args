//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================
using System;
using Xunit;
using System.Collections.Generic;

namespace Args
{
	using Test = org.junit.Test;

//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static ErrorCode.*;
//JAVA TO C# CONVERTER TODO TASK: This Java 'import static' statement cannot be converted to C#:
//	import static org.junit.Assert.*;

	public class ArgsTest
	{

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testCreateWithNoSchemaOrArguments() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testCreateWithNoSchemaOrArguments()
	  {
		Args args = new Args("", new string[0]);
		assertEquals(0, args.nextArgument());
	  }


//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWithNoSchemaButWithOneArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testWithNoSchemaButWithOneArgument()
	  {
		try
		{
		  new Args("", new string[]{"-x"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(UNEXPECTED_ARGUMENT, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testWithNoSchemaButWithMultipleArguments() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testWithNoSchemaButWithMultipleArguments()
	  {
		try
		{
		  new Args("", new string[]{"-x", "-y"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(UNEXPECTED_ARGUMENT, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		}

	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testNonLetterSchema() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testNonLetterSchema()
	  {
		try
		{
		  new Args("*", new string[]{});
		  fail("Args constructor should have thrown exception");
		}
		catch (ArgsException e)
		{
		  assertEquals(INVALID_ARGUMENT_NAME, e.ErrorCode);
		  assertEquals('*', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInvalidArgumentFormat() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testInvalidArgumentFormat()
	  {
		try
		{
		  new Args("f~", new string[]{});
		  fail("Args constructor should have throws exception");
		}
		catch (ArgsException e)
		{
		  assertEquals(INVALID_ARGUMENT_FORMAT, e.ErrorCode);
		  assertEquals('f', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleBooleanPresent() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSimpleBooleanPresent()
	  {
		Args args = new Args("x", new string[]{"-x"});
		assertEquals(true, args.getBoolean('x'));
		assertEquals(1, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleStringPresent() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSimpleStringPresent()
	  {
		Args args = new Args("x*", new string[]{"-x", "param"});
		assertTrue(args.has('x'));
		assertEquals("param", args.getString('x'));
		assertEquals(2, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingStringArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testMissingStringArgument()
	  {
		try
		{
		  new Args("x*", new string[]{"-x"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(MISSING_STRING, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSpacesInFormat() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSpacesInFormat()
	  {
		Args args = new Args("x, y", new string[]{"-xy"});
		assertTrue(args.has('x'));
		assertTrue(args.has('y'));
		assertEquals(1, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleIntPresent() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSimpleIntPresent()
	  {
		Args args = new Args("x#", new string[]{"-x", "42"});
		assertTrue(args.has('x'));
		assertEquals(42, args.getInt('x'));
		assertEquals(2, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInvalidInteger() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testInvalidInteger()
	  {
		try
		{
		  new Args("x#", new string[]{"-x", "Forty two"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(INVALID_INTEGER, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		  assertEquals("Forty two", e.ErrorParameter);
		}

	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingInteger() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testMissingInteger()
	  {
		try
		{
		  new Args("x#", new string[]{"-x"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(MISSING_INTEGER, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testSimpleDoublePresent() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testSimpleDoublePresent()
	  {
		Args args = new Args("x##", new string[]{"-x", "42.3"});
		assertTrue(args.has('x'));
		assertEquals(42.3, args.getDouble('x'), .001);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testInvalidDouble() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testInvalidDouble()
	  {
		try
		{
		  new Args("x##", new string[]{"-x", "Forty two"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(INVALID_DOUBLE, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		  assertEquals("Forty two", e.ErrorParameter);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingDouble() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testMissingDouble()
	  {
		try
		{
		  new Args("x##", new string[]{"-x"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(MISSING_DOUBLE, e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testStringArray() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testStringArray()
	  {
		Args args = new Args("x[*]", new string[]{"-x", "alpha"});
		assertTrue(args.has('x'));
		string[] result = args.getStringArray('x');
		assertEquals(1, result.Length);
		assertEquals("alpha", result[0]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testMissingStringArrayElement() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testMissingStringArrayElement()
	  {
		try
		{
		  new Args("x[*]", new string[] {"-x"});
		  fail();
		}
		catch (ArgsException e)
		{
		  assertEquals(MISSING_STRING,e.ErrorCode);
		  assertEquals('x', e.ErrorArgumentId);
		}
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void manyStringArrayElements() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void manyStringArrayElements()
	  {
		Args args = new Args("x[*]", new string[]{"-x", "alpha", "-x", "beta", "-x", "gamma"});
		assertTrue(args.has('x'));
		string[] result = args.getStringArray('x');
		assertEquals(3, result.Length);
		assertEquals("alpha", result[0]);
		assertEquals("beta", result[1]);
		assertEquals("gamma", result[2]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void MapArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void MapArgument()
	  {
		Args args = new Args("f&", new string[] {"-f", "key1:val1,key2:val2"});
		assertTrue(args.has('f'));
		IDictionary<string, string> map = args.getMap('f');
		assertEquals("val1", map["key1"]);
		assertEquals("val2", map["key2"]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test(expected=ArgsException.class) public void malFormedMapArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void malFormedMapArgument()
	  {
		Args args = new Args("f&", new string[] {"-f", "key1:val1,key2"});
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void oneMapArgument() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void oneMapArgument()
	  {
		Args args = new Args("f&", new string[] {"-f", "key1:val1"});
		assertTrue(args.has('f'));
		IDictionary<string, string> map = args.getMap('f');
		assertEquals("val1", map["key1"]);
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtraArguments() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testExtraArguments()
	  {
		Args args = new Args("x,y*", new string[]{"-x", "-y", "alpha", "beta"});
		assertTrue(args.getBoolean('x'));
		assertEquals("alpha", args.getString('y'));
		assertEquals(3, args.nextArgument());
	  }

//JAVA TO C# CONVERTER TODO TASK: Most Java annotations will not have direct .NET equivalent attributes:
//ORIGINAL LINE: @Test public void testExtraArgumentsThatLookLikeFlags() throws Exception
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
	  public virtual void testExtraArgumentsThatLookLikeFlags()
	  {
		Args args = new Args("x,y", new string[]{"-x", "alpha", "-y", "beta"});
		assertTrue(args.has('x'));
		assertFalse(args.has('y'));
		assertTrue(args.getBoolean('x'));
		assertFalse(args.getBoolean('y'));
		assertEquals(1, args.nextArgument());
	  }
	}

}