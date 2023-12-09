
using System.Dynamic;
using System;

class CharacterLevel
{
    private int _characterLevel;

    // Example XP progression table for levels 1 to 20
    private int[] xpTable = new int[]
    {
        0,      // Level 1
        300,    // Level 2
        900,    // Level 3
        2700,   // Level 4
        6500,   // Level 5
        14000,  // Level 6
        23000,  // Level 7
        34000,  // Level 8
        48000,  // Level 9
        64000,  // Level 10
        85000,  // Level 11
        100000, // Level 12
        120000, // Level 13
        140000, // Level 14
        165000, // Level 15
        195000, // Level 16
        225000, // Level 17
        265000, // Level 18
        305000, // Level 19
        355000  // Level 20
    };

    public int ReturnCharacterLevel()
    {
        return _characterLevel;
    }

    public void LevelUp(int totalXP)
    {
        for (int level = 1; level <= xpTable.Length; level++)
        {
            if (totalXP < xpTable[level - 1])
            {
                _characterLevel = level;
                break;
            }
        }
    }
}


