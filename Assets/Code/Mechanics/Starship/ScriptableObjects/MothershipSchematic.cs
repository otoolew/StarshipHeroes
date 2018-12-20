using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newMothershipSchematic", menuName = "Mothership Schematic")]
public class MothershipSchematic : ScriptableObject
{
    public Mothership mothershipPrefab;
    public string mothershipName;
    public FactionAlignment factionAlignment;

    public void Initialize(Mothership mothership)
    {
        mothership.FactionAlignment = factionAlignment;
    }
}
