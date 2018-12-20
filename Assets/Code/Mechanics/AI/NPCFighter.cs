using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFighter : MonoBehaviour
{
    public Enums.MissionStatus MissionStatus;

    [SerializeField]
    private StarshipNavigation starshipNavigation;
    public StarshipNavigation StarshipNavigation
    {
        get { return starshipNavigation; }
        private set { starshipNavigation = value; }
    }

    [SerializeField]
    private int currentPatrolPoint;
    public int CurrentPatrolPoint
    {
        get { return currentPatrolPoint; }
        private set { currentPatrolPoint = value; }
    }
    [SerializeField]
    private Transform defensePosition;
    public Transform DefensePosition
    {
        get { return defensePosition; }
        private set { defensePosition = value; }
    }

    [SerializeField]
    private WeaponComponent weaponComponent;
    public WeaponComponent WeaponComponent
    {
        get { return weaponComponent; }
        private set { weaponComponent = value; }
    }
    [SerializeField]
    private TargetController targetController;
    public TargetController TargetController
    {
        get { return targetController; }
        private set { targetController = value; }
    }

    public List<Transform> patrolPoints;
    public void Initialize()
    {
        targetController = GetComponentInChildren<TargetController>();
    }
    // Use this for initialization
    void Start ()
    {
        Initialize();
        StarshipInit();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(targetController.CurrentTarget != null)
        {
            starshipNavigation.GoToPosition(targetController.CurrentTarget.transform.position);
            MissionStatus = Enums.MissionStatus.ENGAGING;
        }

        switch (MissionStatus)
        {
            case Enums.MissionStatus.ENGAGING:
                starshipNavigation.StopDistance = GetComponentInChildren<WeaponComponent>().WeaponRange;
                FireWeapon(weaponComponent);
                break;
            case Enums.MissionStatus.DEFENDING:
                DefendPosition();
                break;
            case Enums.MissionStatus.PATROLING:
                starshipNavigation.StopDistance = 1f;
                ContinuePatrol();               
                break;
            default:
                break;
        }

    }

    public void FireWeapon(WeaponComponent weapon)
    {
        if (targetController.CurrentTarget == null)
        {
            MissionStatus = Enums.MissionStatus.PATROLING;
            return;
        }

        if (((Vector2.Distance(transform.position, targetController.CurrentTarget.transform.position)) < weapon.WeaponRange))
        {
            weapon.Fire();
        }
        starshipNavigation.StopDistance = 0f;
    }
    public void EngageEnemy()
    {
        starshipNavigation.StopDistance = weaponComponent.WeaponRange;
        FireWeapon(weaponComponent);
    }
    public void DefendPosition()
    {
        if(defensePosition == null)
        {
            MissionStatus = Enums.MissionStatus.IDLE;
            return;
        }
        starshipNavigation.GoToPosition(defensePosition.position);
    }
    public void ContinuePatrol()
    {
        if (patrolPoints.Count == 0)
            return;
        starshipNavigation.StopDistance = 0.1f;
        if (starshipNavigation.DistanceToDestination < starshipNavigation.StopDistance)
            currentPatrolPoint = (currentPatrolPoint + 1) % patrolPoints.Count;
        starshipNavigation.GoToPosition(patrolPoints[currentPatrolPoint].position);       
    }
    public void RecieveDistressCall(ResourceField resourceField)
    {
        for (int i = 0; i < resourceField.patrolPoints.Length; i++)
        {
            patrolPoints.Add(resourceField.patrolPoints[i]);
        }
        MissionStatus = Enums.MissionStatus.DEFENDING;
    }
    private void StarshipInit()
    {
        StartCoroutine("InitSequence");
    }

    IEnumerator InitSequence()
    {
        yield return new WaitForSeconds(.01f);
        weaponComponent = GetComponentInChildren<WeaponComponent>();

    }
}
