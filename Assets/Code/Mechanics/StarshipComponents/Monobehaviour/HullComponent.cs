using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HullComponent : MonoBehaviour
{
    #region Properties and Variables
    [SerializeField]
    private FactionAlignment faction;
    public FactionAlignment Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    [SerializeField]
    private HullSchematic hullSchematic;

    [SerializeField]
    private DamageComponent damageComponent;
    public DamageComponent DamageComponent
    {
        get { return damageComponent; }
        set { damageComponent = value; }
    }

    public int Armor { get; set; }
    public float RotationSpeed { get; set; }
    #endregion

    public void InitComponent(HullSchematic hullSchematic)
    {
        Armor = hullSchematic.armorRating;
        RotationSpeed = hullSchematic.rotationSpeed;
    }
    private void Awake()
    {
        InitComponent(hullSchematic);
    }
    private void Start()
    {
        faction = GetComponentInParent<Faction>().FactionAlignment;
        damageComponent = GetComponent<DamageComponent>();
        if (damageComponent)
        {
            damageComponent.Faction = faction;
            damageComponent.healthPoints = Armor;
        }        
    }
}
