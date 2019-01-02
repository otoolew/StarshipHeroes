using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newSensorSchematic", menuName = "Starship Parts/Sensor Schematic")]
public class SensorSchematic : PartSchematic
{
    public GameObject sensorPrefab;
    public float sensorRange;
    public float sensorCooldown;
}
