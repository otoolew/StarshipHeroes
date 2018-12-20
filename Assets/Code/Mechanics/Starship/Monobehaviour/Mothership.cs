using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mothership : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private FactionAlignment factionAlignment;
    public FactionAlignment FactionAlignment
    {
        get { return factionAlignment; }
        set { factionAlignment = value; }
    }

    public ResourceField[] resourceFields;

    [SerializeField]
    private ResourceDepot resourceDepot;
    public ResourceDepot ResourceDepot
    {
        get { return resourceDepot; }
        private set { resourceDepot = value; }
    }

    public KeyCode debugSpawnMiner;
    public KeyCode debugSpawnDefender;
    public KeyCode debugSpawnFighter;

    public Transform[] spawnPoints;

    [SerializeField]
    private NPCFighter fighterPrefab;
    [SerializeField]
    private NPCDefender defenderPrefab;
    [SerializeField]
    private NPCWorker workerPrefab;

    public bool Deploying;
    #endregion

    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < resourceFields.Length; i++)
        {
            if(factionAlignment.Equals(resourceFields[i].FactionAlignment))
                resourceDepot.AddToAvailable(resourceFields[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(debugSpawnMiner) && !Deploying)
        {
            SpawnMinerStarship();
        }
        if (Input.GetKeyDown(debugSpawnDefender) && !Deploying)
        {
            SpawnDefenderStarship();
        }
        if (Input.GetKeyDown(debugSpawnFighter) && !Deploying)
        {
            SpawnFighterStarship();
        }
    }
    public void Initialize(FactionAlignment faction)
    {
        factionAlignment = faction;
    }
    public void SpawnMinerStarship()
    {
        NPCWorker worker = Instantiate(workerPrefab, spawnPoints[0]);
        worker.transform.parent = null;
        worker.GetComponent<Faction>().FactionAlignment = FactionAlignment;
        worker.GetComponent<Faction>().Mothership = this;
        worker.ResourceDepot = resourceDepot;
    }

    public void SpawnDefenderStarship()
    {
        NPCDefender defender = Instantiate(defenderPrefab, spawnPoints[0]);
        defender.transform.parent = null;
        defender.GetComponent<Faction>().Mothership = this;
        defender.GetComponent<Faction>().FactionAlignment = FactionAlignment;
    }

    public void SpawnFighterStarship()
    {
        NPCFighter fighter = Instantiate(fighterPrefab, spawnPoints[0]);
        fighter.transform.parent = null;
        fighter.GetComponent<Faction>().Mothership = this;
        fighter.GetComponent<Faction>().FactionAlignment = FactionAlignment;
        fighter.RecieveDistressCall(resourceDepot.RequestFieldAssignment());
        fighter.MissionStatus = Enums.MissionStatus.PATROLING;
    }

}
