namespace Chess
{
    class Result
	{
		private Result(bool isValid, string message)
		{
			IsValid = isValid;
			Message = message;
		}

		public bool IsValid { get; }
		public string Message { get; }

		public static Result Ok => new Result(true, null);
		public static Result Error(string message) => new Result(false, message);
	}
}
