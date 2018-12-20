using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWorker : MonoBehaviour
{
    #region Fields and Properties
    public Enums.MissionStatus MissionStatus;

    [SerializeField]
    private StarshipNavigation starshipNavigation;
    public StarshipNavigation StarshipNavigation
    {
        get { return starshipNavigation; }
        private set { starshipNavigation = value; }
    }
    [SerializeField]
    private ResourceCollector resourceCollector;
    public ResourceCollector ResourceCollector
    {
        get { return resourceCollector; }
        private set { resourceCollector = value; }
    }
    [SerializeField]
    private ResourceDepot resourceDepot;
    public ResourceDepot ResourceDepot
    {
        get { return resourceDepot; }
        set { resourceDepot = value; }
    }
    [SerializeField]
    private ResourceField fieldAssignment;
    public ResourceField FieldAssignment
    {
        get { return fieldAssignment; }
        set { fieldAssignment = value; }
    }

    public bool Deploying;
    #endregion


    #region Monobehaviour
    /// <summary>
    /// This function is always called before any Start functions and also just after a prefab is instantiated.
    /// (If a GameObject is inactive during start up Awake is not called until it is made active.)
    /// </summary>
    private void Awake()
    {
        transform.parent = null;
    }
    /// <summary>
    /// (only called if the Object is active): This function is called just after the object is enabled. 
    /// This happens when a MonoBehaviour instance is created, such as when a level is loaded or a GameObject with the script component is instantiated.
    /// </summary>
    private void OnEnable()
    {

    }
    /// <summary>
    /// Start is called before the first frame update only if the script instance is enabled.
    /// </summary>
    private void Start()
    {
        starshipNavigation = GetComponent<StarshipNavigation>();
        resourceCollector = GetComponent<ResourceCollector>();
        MissionStatus = Enums.MissionStatus.IDLE;
        StopCoroutine("DeploymentSequence");
        StartCoroutine("DeploymentSequence");
    }
    /// <summary>
    /// Update is called once per frame. It is the main workhorse function for frame updates.
    /// </summary>
    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.F))
        //    DoWork();
        if (resourceCollector.HasPackage)
            MissionStatus = Enums.MissionStatus.DELIVERING;

        switch (MissionStatus)
        {
            case Enums.MissionStatus.REQUEST_ASSIGNMENT:
                RequestFieldAssignment();
                break;
            case Enums.MissionStatus.FETCHING:
                RequestResourceLocation();
                break;
            case Enums.MissionStatus.DELIVERING:
                starshipNavigation.GoToPosition(resourceDepot.DropPoint.position);
                if (!resourceCollector.HasPackage)
                    MissionStatus = Enums.MissionStatus.REQUEST_ASSIGNMENT;
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// All physics calculations and updates occur immediately after FixedUpdate. 
    /// </summary>
    void FixedUpdate()
    {

    }
    private void OnDisable()
    {

    }
    private void OnDestroy()
    {

    }
    #endregion

    public void RequestFieldAssignment()
    {
        fieldAssignment = resourceDepot.RequestFieldAssignment();
        if(fieldAssignment != null)
        {
            starshipNavigation.GoToPosition(fieldAssignment.transform.position);
            fieldAssignment.assignmentCount++;
            MissionStatus = Enums.MissionStatus.FETCHING;
            return;
        }
        MissionStatus = Enums.MissionStatus.REQUEST_ASSIGNMENT;
    }
    public void RequestResourceLocation()
    {
        if (fieldAssignment != null)
        {
            starshipNavigation.GoToPosition(resourceDepot.ResourceLocation(fieldAssignment));
            MissionStatus = Enums.MissionStatus.FETCHING;
            return;
        }
        MissionStatus = Enums.MissionStatus.REQUEST_ASSIGNMENT;
    }

    IEnumerator DeploymentSequence()
    {
        yield return new WaitForSeconds(1f);
        MissionStatus = Enums.MissionStatus.REQUEST_ASSIGNMENT;
    }
}
