using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    private void Start()
    {
        for (int i = 0; i < weaponComponents.Length; i++)
        {
            weaponComponents[i].FactionAlignment = GetComponent<Faction>().FactionAlignment;
        }
    }

    [SerializeField]
    private WeaponComponent[] weaponComponents;
    public WeaponComponent[] WeaponComponents
    {
        get { return weaponComponents; }
        set { weaponComponents = value; }
    }

    public void Fire(int index)
    {
        WeaponComponents[index].Fire();
    }
}
