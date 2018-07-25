//========================================================================
// This conversion was produced by the Free Edition of
// Java to C# Converter courtesy of Tangible Software Solutions.
// Purchase the Premium Edition at https://www.tangiblesoftwaresolutions.com
//========================================================================

namespace Args
{
    using System;

	public class ArgsException : Exception
	{
	  private char errorArgumentId = '\0';
	  private string errorParameter = null;
        private ErrorCode errorCode = ErrorCode.OK;

	  public ArgsException()
	  {
	  }

	  public ArgsException(string message) : base(message)
	  {
	  }

	  public ArgsException(ErrorCode errorCode)
	  {
		this.errorCode = errorCode;
	  }

	  public ArgsException(ErrorCode errorCode, string errorParameter)
	  {
		this.errorCode = errorCode;
		this.errorParameter = errorParameter;
	  }

	  public ArgsException(ErrorCode errorCode, char errorArgumentId, string errorParameter)
	  {
		this.errorCode = errorCode;
		this.errorParameter = errorParameter;
		this.errorArgumentId = errorArgumentId;
	  }

	  public virtual char ErrorArgumentId
	  {
		  get
		  {
			return errorArgumentId;
		  }
		  set
		  {
			this.errorArgumentId = value;
		  }
	  }


	  public virtual string ErrorParameter
	  {
		  get
		  {
			return errorParameter;
		  }
		  set
		  {
			this.errorParameter = value;
		  }
	  }


	  public virtual ErrorCode getErrorCode()
	  {
		return errorCode;
	  }

	  public virtual void setErrorCode(ErrorCode errorCode)
	  {
		this.errorCode = errorCode;
	  }

	  public virtual string errorMessage()
	  {
		switch (errorCode)
		{
		  case OK:
			return "TILT: Should not get here.";
		  case Args.ArgsException.ErrorCode.UNEXPECTED_ARGUMENT:
			return string.Format("Argument -{0} unexpected.", errorArgumentId);
		  case Args.ArgsException.ErrorCode.MISSING_STRING:
			return string.Format("Could not find string parameter for -{0}.", errorArgumentId);
		  case Args.ArgsException.ErrorCode.INVALID_INTEGER:
			return string.Format("Argument -{0} expects an integer but was '{1}'.", errorArgumentId, errorParameter);
		  case Args.ArgsException.ErrorCode.MISSING_INTEGER:
			return string.Format("Could not find integer parameter for -{0}.", errorArgumentId);
		  case Args.ArgsException.ErrorCode.INVALID_DOUBLE:
			return string.Format("Argument -{0} expects a double but was '{1}'.", errorArgumentId, errorParameter);
		  case Args.ArgsException.ErrorCode.MISSING_DOUBLE:
			return string.Format("Could not find double parameter for -{0}.", errorArgumentId);
		  case Args.ArgsException.ErrorCode.INVALID_ARGUMENT_NAME:
			return string.Format("'{0}' is not a valid argument name.", errorArgumentId);
		  case Args.ArgsException.ErrorCode.INVALID_ARGUMENT_FORMAT:
			return string.Format("'{0}' is not a valid argument format.", errorParameter);
		  case Args.ArgsException.ErrorCode.MISSING_MAP:
			return string.Format("Could not find map string for -{0}.", errorArgumentId);
		  case Args.ArgsException.ErrorCode.MALFORMED_MAP:
			return string.Format("Map string for -{0} is not of form k1:v1,k2:v2...", errorArgumentId);
		}
		return "";
	  }

	  public enum ErrorCode
	  {
		OK,
		INVALID_ARGUMENT_FORMAT,
		UNEXPECTED_ARGUMENT,
		INVALID_ARGUMENT_NAME,
		MISSING_STRING,
		MISSING_INTEGER,
		INVALID_INTEGER,
		MISSING_DOUBLE,
		MALFORMED_MAP,
		MISSING_MAP,
		INVALID_DOUBLE
	  }
	}

}