using System;

public class Activity
{
    private string _name;

    private string _description;

    private int _duration;

    public void SetName()
    {
        _name = Console.ReadLine();

    }

    public void SetDescription()
    {
        _description = Console.ReadLine();
    }

    public void SetDuration()
    {
        _duration = int.Parse(Console.ReadLine());
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetDuration()
    {
        return _duration;
    }

};