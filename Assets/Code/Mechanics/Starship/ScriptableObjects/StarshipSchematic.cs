using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newStarshipSchematic", menuName = "Starship Schematic")]
public class StarshipSchematic : ScriptableObject
{
    public string modelName;
    public Starship starshipPrefab;
    public Enums.StarshipType starshipType;
    public HullSchematic hullSchematic;
    public EngineSchematic[] engineSchematics;
    public WeaponSchematic[] weaponSchematics;
}

