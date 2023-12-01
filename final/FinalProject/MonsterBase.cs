using System;

public enum TerrainType
{
    Arctic,
    Coast,
    Desert,
    Forest,
    Grassland,
    Hill,
    Mountain,
    Swamp,
    Underdark,
    Underwater,
    Urban
}

public class Monster
{
    public string Name { get; set; }
    public string Type { get; set; }
    public string Alignment { get; set; }
    public string Size { get; set; }
    public double CRDecimal { get; set; }
    public int AC { get; set; }
    public int HP { get; set; }
    public bool Spellcasting { get; set; }
    public string Attack1Damage { get; set; }
    public string Attack2Damage { get; set; }
    public int Page { get; set; }
    public bool Arctic { get; set; }
    public bool Coast { get; set; }
    public bool Desert { get; set; }
    public bool Forest { get; set; }
    public bool Grassland { get; set; }
    public bool Hill { get; set; }
    public bool Mountain { get; set; }
    public bool Swamp { get; set; }
    public bool Underdark { get; set; }
    public bool Underwater { get; set; }
    public bool Urban { get; set; }

    public Monster()
    {
        // Initialize properties with default values
        CRDecimal = 0.0;
        AC = 0;
        HP = 0;
        Page = 0;
    }

    public override string ToString()
    {
        return $"{Name}, {Type}, {Alignment}, {Size}, {CRDecimal}, {AC}, {HP}, {Spellcasting}, {Attack1Damage}, {Attack2Damage}, {Page}, {Arctic}, {Coast}, {Desert}, {Forest}, {Grassland}, {Hill}, {Mountain}, {Swamp}, {Underdark}, {Underwater}, {Urban}";
    }

    public bool MatchTerrain(TerrainType terrain)
    {
        return Arctic && terrain == TerrainType.Arctic ||
               Coast && terrain == TerrainType.Coast ||
               Desert && terrain == TerrainType.Desert ||
               Forest && terrain == TerrainType.Forest ||
               Grassland && terrain == TerrainType.Grassland ||
               Hill && terrain == TerrainType.Hill ||
               Mountain && terrain == TerrainType.Mountain ||
               Swamp && terrain == TerrainType.Swamp ||
               Underdark && terrain == TerrainType.Underdark ||
               Underwater && terrain == TerrainType.Underwater ||
               Urban && terrain == TerrainType.Urban;
    }
}
