public class SimpleGoal : Goal
{
    public override void Complete()
    {
        Goaltotalpoints += GetGoalPoints();
        SetCompleted();
    }
}