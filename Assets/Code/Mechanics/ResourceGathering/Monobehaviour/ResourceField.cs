using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourceField : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private ResourceFieldConfig resourceFieldConfig;

    [Header("Owning Faction")]
    [SerializeField]
    private FactionAlignment factionAlignment;
    public FactionAlignment FactionAlignment
    {
        get { return factionAlignment; }
        set { factionAlignment = value; }
    }

    [SerializeField]
    private int totalResourcePack;
    public int TotalResourcePack
    {
        get { return totalResourcePack; }
        private set { totalResourcePack = value; }
    }
    [SerializeField]
    private float captureRadius;
    public float CaptureRadius
    {
        get { return captureRadius; }
        private set { captureRadius = value; }
    }
    [SerializeField]
    private int attackerCount;
    public int AttackerCount
    {
        get { return attackerCount; }
        private set { attackerCount = value; }
    }
    [SerializeField]
    private int defenderCount;
    public int DefenderCount
    {
        get { return defenderCount; }
        private set { defenderCount = value; }
    }
    public int assignmentCount;
    public Transform[] packageSpawnPoints;
    public ResourcePack[] resourcePacks;
    public List<ResourcePack> AvailablePacks = new List<ResourcePack>();
    public List<Starship> defendersInRange = new List<Starship>();
    public Transform[] patrolPoints;

    #endregion

    #region Events
    public event Action<Starship> defenderEntersRange;
    public event Action<Starship> defenderExitsRange;
    public UnityEvent<ResourceField> OnCapture;

    #endregion
    #region Debug
    public Text textLabel;
    public Text resourceLabel;
    public Text factionLabel;
    #endregion
    public void InitConfig(ResourceFieldConfig resourceFieldConfig)
    {
        totalResourcePack = resourceFieldConfig.maxResourcePacks;
    }
    public void InitResourcePacks()
    {
        for (int i = 0; i < resourceFieldConfig.maxResourcePacks; i++)
        {
            var resourcePack = Instantiate(resourceFieldConfig.resourcePackPrefab, packageSpawnPoints[i]);
            resourcePacks[i] = resourcePack;
            resourcePack.onReleased += AddToAvailable;
            resourcePack.onTaken += RemoveFromAvailable;
            AddToAvailable(resourcePack);
            resourcePack.transform.parent = null;
        }

        totalResourcePack = resourceFieldConfig.maxResourcePacks;
    }
    #region Monobehaviour
    private void Awake()
    {
        InitConfig(resourceFieldConfig);
    }
    private void Start() {

        resourcePacks = new ResourcePack[totalResourcePack];
        InitResourcePacks();
    }

    // Update is called once per frame
    void Update()
    {
        resourceLabel.text = TotalResourcePack.ToString();
        factionLabel.text = FactionAlignment.factionName;
    }
    private void OnTriggerEnter(Collider other)
    {
        var defender = other.GetComponent<Starship>();
        if (defender != null)
        {
            if (defender.StarshipType.Equals(Enums.StarshipType.DEFENDER))
            {
                defender.removed += OnDefenderDeath;
                defendersInRange.Add(defender);
                if (defenderEntersRange != null)
                {
                    defenderEntersRange(defender);
                }
            }
            if (defender.GetComponent<Faction>().IsAlly(FactionAlignment))
                defenderCount++;
            else
                attackerCount++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        var defender = other.GetComponent<Starship>();
        if (defender)
        {
            defender.removed -= OnDefenderDeath;
            defendersInRange.Remove(defender);
            if (defenderExitsRange != null)
            {
                defenderExitsRange(defender);
            }
            if (defender.GetComponent<Faction>().IsAlly(FactionAlignment))
                defenderCount++;
            else
                attackerCount++;
        }
    }
    #endregion

    public void AddToAvailable(ResourcePack pack)
    {
        if (!AvailablePacks.Contains(pack))
            AvailablePacks.Add(pack);
    }
    public void RemoveFromAvailable(ResourcePack pack)
    {
        if (AvailablePacks.Contains(pack))
            AvailablePacks.Remove(pack);
    }
    public void UpdateDefenderCount()
    {
        int tempDefenderCount = 0;
        int tempAttackerCount = 0;

        for (int i = 0; i < defendersInRange.Count; i++)
        {
            if (defendersInRange[i].StarshipType.Equals(Enums.StarshipType.DEFENDER))
            {
                if (defendersInRange[i].GetComponent<Faction>().IsAlly(FactionAlignment))
                    tempDefenderCount++;
                else
                    tempAttackerCount++;
            }
        }
    }

    void OnDefenderDeath(Starship defender)
    {
        defender.removed -= OnDefenderDeath;
        for (int i = 0; i < defendersInRange.Count; i++)
        {
            if (defendersInRange[i] == defender)
            {
                defendersInRange.RemoveAt(i);
                if (defender.GetComponent<Faction>().IsAlly(FactionAlignment))
                    defenderCount--;
                else
                    attackerCount--;
                break;
            }
        }
    }
}