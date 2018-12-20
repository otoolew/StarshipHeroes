using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDefender : MonoBehaviour {

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
    private ResourceField fieldAssignment;
    public ResourceField FieldAssignment
    {
        get { return fieldAssignment; }
        set { fieldAssignment = value; }
    }

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
        MissionStatus = Enums.MissionStatus.REQUEST_ASSIGNMENT;
    }
    /// <summary>
    /// Update is called once per frame. It is the main workhorse function for frame updates.
    /// </summary>
    private void Update()
    {
        if(fieldAssignment == null)
        {
            RequestFieldAssignment();
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
        fieldAssignment = GetComponent<Faction>().Mothership.ResourceDepot.RequestFieldAssignment();
        if (fieldAssignment != null)
        {
            starshipNavigation.GoToPosition(fieldAssignment.transform.position);
            //starshipNavigation.GoToPosition(fieldAssignment.transform.position + new Vector3(0,0,0));
            MissionStatus = Enums.MissionStatus.DEFENDING;
            return;
        }
        MissionStatus = Enums.MissionStatus.REQUEST_ASSIGNMENT;
    }

}
