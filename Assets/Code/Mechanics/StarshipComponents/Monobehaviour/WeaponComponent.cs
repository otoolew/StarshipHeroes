using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    #region Variable Declarations
    [SerializeField]
    private WeaponSchematic weaponSchematic;
    public WeaponSchematic WeaponSchematic
    {
        get { return weaponSchematic; }
        set { weaponSchematic = value; }
    }
    public GameObject munitionPrefab;

    public float WeaponDamage;
    public float WeaponRange;
    public float WeaponCooldown;
    public float WeaponTimer;
    public bool WeaponReady;
    [SerializeField]
    private FactionAlignment factionAlignment;
    public FactionAlignment FactionAlignment
    {
        get { return factionAlignment; }
        set { factionAlignment = value; }
    }
    [SerializeField]
    private Transform firePoint;
    public Transform FirePoint
    {
        get { return firePoint; }
        set { firePoint = value; }
    }

    #endregion
    #region Events

    #endregion

    #region Monobehaviour
    // Use this for initialization
    private void Awake()
    {

    }
    private void Start()
    {
        factionAlignment = GetComponentInParent<Faction>().FactionAlignment;
        WeaponSchematic.InitComponent(this);       
    }

    // Update is called once per frame
    private void Update()
    {
        CooldownWeapon();
    }
    #endregion

    private void CooldownWeapon()
    {
        WeaponSchematic.CooldownWeapon(this);
    }
    public void Fire()
    {
        WeaponSchematic.FireWeapon(this);
    }
}
