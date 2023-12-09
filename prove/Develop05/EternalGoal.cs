public class EternalGoal : Goal
{
    private int _repeatTracker = 0;

    public int GetRepeatTracker()
    {
        return _repeatTracker;
    }

    public void AddRepeatTracker()
    {
        _repeatTracker += 1;
    }
    public void SetRepeatTracker(int tracker)
    {
        _repeatTracker = tracker;
    }

    public override void Complete()
    {
        Goaltotalpoints += GetGoalPoints();
        AddRepeatTracker();
    }
}