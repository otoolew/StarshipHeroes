using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EngineComponent : MonoBehaviour
{
    #region Properties and Variables

    [SerializeField]
    private EngineSchematic engineSchematic;
    public EngineSchematic EngineSchematic
    {
        get { return engineSchematic; }
        set { engineSchematic = value; }
    }

    //public float EngineThrust { get; set; }
    public float EnginePower { get; set; }
    #endregion

    public void InitComponent(EngineSchematic engineSchematic)
    {
        EnginePower = engineSchematic.enginePower;
    }
    private void Awake()
    {
        InitComponent(engineSchematic);
    }
    private void Start()
    {
        //InitComponent(engineSchematic);
    }

}
