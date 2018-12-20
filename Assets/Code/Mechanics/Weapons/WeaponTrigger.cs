using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponTrigger : MonoBehaviour
{
    #region Variable Declarations
    public WeaponComponent weaponComponent;
    public TargetController targetController;
    private Ray ray;
    private RaycastHit rayHit;
    [SerializeField]
    [Range(0, 360)]
    private float viewAngle;
    public float ViewAngle
    {
        get { return viewAngle; }
        set { viewAngle = value; }
    }

    public LayerMask targetLayer;
    #endregion
    #region Events

    #endregion
    #region Initializations
    // Use this for initialization
    void Start()
    {
        weaponComponent = GetComponent<WeaponComponent>();
        targetController = weaponComponent.GetComponentInParent<TargetController>();
    }
    #endregion
    // Update is called once per frame
    void Update()
    {
        if (weaponComponent.WeaponReady)
        {
            if (targetController.CurrentTarget != null)
            {
                float distanceToTarget = Vector3.Distance(transform.position, targetController.CurrentTarget.transform.position);
                if (distanceToTarget < weaponComponent.WeaponRange)
                {
                    Vector3 directionToTarget = (targetController.CurrentTarget.transform.position - transform.position).normalized;
                    if (Vector3.Angle(transform.forward, directionToTarget) < ViewAngle / 2)
                    {
                        weaponComponent.Fire();
                    }
                }
            }
        }
    }

    //Editor Code Here
#if UNITY_EDITOR

#endif
}
