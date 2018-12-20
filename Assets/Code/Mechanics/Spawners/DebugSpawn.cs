using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSpawn : MonoBehaviour
{
    public Starship starshipPrefab;
    public FactionAlignment faction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            SpawnObject();
    }
    void SpawnObject()
    {
        starshipPrefab.GetComponent<Faction>().FactionAlignment = faction;
        Starship ship = Instantiate(starshipPrefab, transform);
        ship.transform.parent = null;
    }
}
