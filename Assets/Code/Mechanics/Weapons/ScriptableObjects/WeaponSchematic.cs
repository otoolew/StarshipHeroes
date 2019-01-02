using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponSchematic", menuName = "Starship Parts/Weapon Schematic")]
public class WeaponSchematic : PartSchematic
{
    public int weaponDamage;
    public int weaponRange;
    public float weaponCooldown;

    public void InitComponent(WeaponComponent weaponComponent)
    {
        weaponComponent.WeaponDamage = weaponDamage;
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
            GameObject munition = weaponComponent.munitionPrefab;
            munition.GetComponentInChildren<MeshRenderer>().material = weaponComponent.FactionAlignment.laserMaterial;
            Instantiate(munition, weaponComponent.FirePoint);
            weaponComponent.WeaponTimer = weaponCooldown;
            weaponComponent.WeaponReady = false;
        }
    }
}
