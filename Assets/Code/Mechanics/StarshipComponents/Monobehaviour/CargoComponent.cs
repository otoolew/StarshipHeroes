using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CargoComponent : MonoBehaviour
{
    #region Variable Declarations
    //public Transform cargoHold;

    //[SerializeField]
    //private CargoSchematic cargoSchematic;
    //public float CargoLimit { get; set; }
    //public float CargoLoadCooldown { get; set; }
    #endregion
    //public void InitComponent(CargoSchematic cargoSchematic)
    //{
    //    GetComponentInChildren<SpriteRenderer>().sprite = cargoSchematic.partSprite;
    //    CargoLimit = cargoSchematic.cargoLoadCapacity;
    //    CargoLoadCooldown = cargoSchematic.cargoLoadCooldown;
    //}
    #region Monobehaviour
    private void Awake()
    {
        //InitComponent(cargoSchematic);
    }
    #endregion

}
