namespace Chess
{
    class SameCellMoveRule : IRule
    {
        public Result Validate(Board board, MoveCommand move) => move.From == move.To ? Result.Error("Destination cell should differ from the source cell") : Result.Ok;
    }
}
