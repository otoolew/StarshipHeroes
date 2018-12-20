using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilityComponent : MonoBehaviour {
    #region Variable Declarations

    [SerializeField]
    private float utilityCooldown;
    public float UtilityCooldown
    {
        get { return utilityCooldown; }
        set { utilityCooldown = value; }
    }

    [SerializeField]
    private float utilityTimer;
    public float UtilityTimer
    {
        get { return utilityTimer; }
        set { utilityTimer = value; }
    }

    [SerializeField]
    private bool utilityReady;
    public bool UtilityReady
    {
        get { return utilityReady; }
        set { utilityReady = value; }
    }

    [SerializeField]
    private bool operational;
    public bool Operational
    {
        get { return operational; }
        private set { operational = value; }
    }

    #endregion
    #region Events

    #endregion
    #region Init
    public void InitComponent(UtilitySchematic schematic)
    {
        UtilityCooldown = schematic.utilityCooldown;
        UtilityTimer = schematic.utilityCooldown;
        Operational = true;
    }
    #endregion

    #region Monobehaviour
    // Use this for initialization
    private void Awake()
    {

    }
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (operational)
            CooldownUtility();
    }
    #endregion

    private void CooldownUtility()
    {
        if (UtilityTimer <= 0)
        {
            UtilityTimer = 0;
            UtilityReady = true;
        }
        else
        {
            UtilityTimer -= Time.deltaTime;
            UtilityReady = false;
        }

    }
    public void Fire()
    {
        if (UtilityReady)
        {
            Debug.Log("Utility Fired");
            UtilityTimer = UtilityCooldown;
            UtilityReady = false;
        }
    }
}
