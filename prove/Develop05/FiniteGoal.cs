public class FiniteGoal : Goal
{
    private int _repeats;

    public int GetRepeats()
    {
        return _repeats;
    }
 
    public void SetRepeats(int repeat)
    {
       _repeats = repeat;
    }
    private int _repeatTracker;

    public int GetRepeatTracker()
    {
        return _repeatTracker;
    }
    public void SetRepeatTracker(int tracker)
    {
        _repeatTracker = tracker;
    }

    public void AddRepeatTracker()
    {
        _repeatTracker += 1;
    }
 

    public override void Complete()
    {
        Goaltotalpoints += GetGoalPoints();
        AddRepeatTracker();
        if (_repeatTracker == _repeats)
        {
            SetCompleted();
            Goaltotalpoints += GetGoalPoints() * _repeats;
        }
    }
}