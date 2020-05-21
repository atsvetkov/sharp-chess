namespace Chess
{
    interface IRule
	{
		Result Validate(Board board, MoveCommand move);
	}
}
