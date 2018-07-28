﻿//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

using System;
using System.Collections.Generic;
using static Args.ArgsException;

namespace Args
{
	public class Args
	{
	  private IDictionary<char, ArgumentMarshaler> marshalers;
	  private ISet<char> argsFound;
	  private IEnumerator<string> currentArgument;

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: public Args(String schema, String[] args) throws ArgsException
	  public Args(string schema, string[] args)
	  {
		marshalers = new Dictionary<char, ArgumentMarshaler>();
		argsFound = new HashSet<char>();

		parseSchema(schema);
		parseArgumentStrings(args);
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void parseSchema(String schema) throws ArgsException
	  private void parseSchema(string schema)
	  {
		foreach (string element in schema.Split(",", true))
		{
		  if (element.Length > 0)
		  {
			parseSchemaElement(element.Trim());
		  }
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void parseSchemaElement(String element) throws ArgsException
	  private void parseSchemaElement(string element)
	  {
		char elementId = element[0];
		string elementTail = element.Substring(1);
		validateSchemaElementId(elementId);
		if (elementTail.Length == 0)
		{
		  marshalers[elementId] = new BooleanArgumentMarshaler();
		}
		else if (elementTail.Equals("*"))
		{
		  marshalers[elementId] = new StringArgumentMarshaler();
		}
		else if (elementTail.Equals("#"))
		{
		  marshalers[elementId] = new IntegerArgumentMarshaler();
		}
		else if (elementTail.Equals("##"))
		{
		  marshalers[elementId] = new DoubleArgumentMarshaler();
		}
		else if (elementTail.Equals("[*]"))
		{
		  marshalers[elementId] = new StringArrayArgumentMarshaler();
		}
		else if (elementTail.Equals("&"))
		{
		  marshalers[elementId] = new MapArgumentMarshaler();
		}
		else
		{
		  throw new ArgsException(ErrorCode.INVALID_ARGUMENT_FORMAT, elementId, elementTail);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void validateSchemaElementId(char elementId) throws ArgsException
	  private void validateSchemaElementId(char elementId)
	  {
		if (!char.IsLetter(elementId))
		{
		  throw new ArgsException(ErrorCode.INVALID_ARGUMENT_NAME, elementId, null);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void parseArgumentStrings(List<String> argsList) throws ArgsException
	  private void parseArgumentStrings(IList<string> argsList)
	  {
            foreach (var argString in argsList)
            {
                if (argString.StartsWith("-", StringComparison.Ordinal))
                {
                    parseArgumentCharacters(argString.Substring(1));
                }
            }
//JAVA TO C# CONVERTER WARNING: Unlike Java's ListIterator, enumerators in .NET do not allow altering the collection:
		//for (currentArgument = argsList.GetEnumerator(); currentArgument.MoveNext();)
		//{
		//  string argString = currentArgument.Current;
		//  if (argString.StartsWith("-", StringComparison.Ordinal))
		//  {
		//	parseArgumentCharacters(argString.Substring(1));
		//  }
		//  else
		//  {
		//	currentArgument.previous();
		//	break;
		//  }
		//}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void parseArgumentCharacters(String argChars) throws ArgsException
	  private void parseArgumentCharacters(string argChars)
	  {
		for (int i = 0; i < argChars.Length; i++)
		{
		  parseArgumentCharacter(argChars[i]);
		}
	  }

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: private void parseArgumentCharacter(char argChar) throws ArgsException
	  private void parseArgumentCharacter(char argChar)
	  {
		ArgumentMarshaler m = marshalers[argChar];
		if (m == null)
		{
		  throw new ArgsException(ErrorCode.UNEXPECTED_ARGUMENT, argChar, null);
		}
		else
		{
		  argsFound.Add(argChar);
		  try
		  {
			m.set(currentArgument);
		  }
		  catch (ArgsException e)
		  {
			e.ErrorArgumentId = argChar;
			throw e;
		  }
		}
	  }

	  public virtual bool has(char arg)
	  {
		return argsFound.Contains(arg);
	  }

	  public virtual string nextArgument()
	  {
		return currentArgument.Current;
	  }

	  public virtual bool getBoolean(char arg)
	  {
		return BooleanArgumentMarshaler.getValue(marshalers[arg]);
	  }

	  public virtual string getString(char arg)
	  {
		return StringArgumentMarshaler.getValue(marshalers[arg]);
	  }

	  public virtual int getInt(char arg)
	  {
		return IntegerArgumentMarshaler.getValue(marshalers[arg]);
	  }

	  public virtual double getDouble(char arg)
	  {
		return DoubleArgumentMarshaler.getValue(marshalers[arg]);
	  }

	  public virtual string[] getStringArray(char arg)
	  {
		return StringArrayArgumentMarshaler.getValue(marshalers[arg]);
	  }

	  public virtual IDictionary<string, string> getMap(char arg)
	  {
		return MapArgumentMarshaler.getValue(marshalers[arg]);
	  }
	}
}