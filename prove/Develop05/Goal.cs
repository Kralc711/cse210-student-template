public abstract class Goal
{
    private int _goaltype;
    public void SetGoalType(int type)
    {
        _goaltype = type;
    }
    public int GetGoalType()
    {
        return _goaltype;
    }
    private string _goalname;

    public void SetGoalName(string GoalName)
    {
        _goalname = GoalName;
    }
    public string GetGoalName()
    {
        return _goalname;
    }
    private string _goaldescription;

    public void SetGoalDescription(string SetGoalDescription)
    {
        _goaldescription = SetGoalDescription;
    }
    public string GetGoalDescription()
    {
        return _goaldescription;
    }

    private int _goalpoints;
    public void SetGoalPoints(int GoalPoints)
    {
        _goalpoints = GoalPoints;
    }
    public int GetGoalPoints()
    {
        return _goalpoints;
    }
    public int Goaltotalpoints;
    public void SetGoalTotalPoints(int points)
    {
        Goaltotalpoints = points;
    }


    public int GetTotalPoints()
    {
        return Goaltotalpoints;
    }
    private int _completed = 0;
    public void SetCompleted()
    {
        _completed += 1;
    } 
    public void AssignCompleted(int completed)
    {
        _completed = completed;
    }
    public int GetCompleted()
    {
        return _completed;
    }
    
    public abstract void Complete();
}
