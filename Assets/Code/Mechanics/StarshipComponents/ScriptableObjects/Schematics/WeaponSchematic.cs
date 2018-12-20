using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponSchematic", menuName = "Starship Parts/Weapon Schematic")]
public class WeaponSchematic : PartSchematic
{
    public GameObject munitionPrefab;
    public float weaponRange;
    public float weaponPower;
    public float weaponCooldown;
    public void InitComponent(WeaponComponent weaponComponent)
    {
        //weaponComponent.FactionAlignment = weaponComponent.GetComponentInParent<Faction>().FactionAlignment;
        weaponComponent.WeaponPower = weaponPower;
        weaponComponent.WeaponRange = weaponRange;
        weaponComponent.WeaponCooldown = weaponCooldown;
    }
    public void CooldownWeapon(WeaponComponent weaponComponent)
    {
        if (weaponComponent.WeaponTimer <= 0)
        {
            weaponComponent.WeaponTimer = 0;
            weaponComponent.WeaponReady = true;
        }
        else
        {
            weaponComponent.WeaponTimer -= Time.deltaTime;
            weaponComponent.WeaponReady = false;
        }

    }
    public void FireWeapon(WeaponComponent weaponComponent)
    {
        if (weaponComponent.WeaponReady)
        {
            Instantiate(munitionPrefab, weaponComponent.FirePoint);
            weaponComponent.WeaponTimer = weaponCooldown;
            weaponComponent.WeaponReady = false;
        }
    }
}
