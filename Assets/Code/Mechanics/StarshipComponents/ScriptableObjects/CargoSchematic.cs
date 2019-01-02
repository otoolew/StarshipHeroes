using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newCargoSchematic", menuName = "Starship Parts/Cargo Schematic")]
public class CargoSchematic : PartSchematic
{
    // Use this for initialization
    public GameObject cargoPrefab;
    public int cargoLoadCapacity;
    public float cargoLoadCooldown;
    public float cargoLoadTimer;

}
