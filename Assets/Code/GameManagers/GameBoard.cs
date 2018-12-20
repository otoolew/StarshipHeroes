using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField]
    private Mothership mothershipPrefab;

    public FactionAlignment[] factions;
    public Transform[] factionSpawnPonts;

    private void SetUp()
    {
        for (int i = 0; i < factions.Length; i++)
        {
            Mothership mothership = Instantiate(mothershipPrefab, factionSpawnPonts[i]);
            mothership.FactionAlignment = factions[i];
            mothership.transform.parent = null;
        }
    }
}
