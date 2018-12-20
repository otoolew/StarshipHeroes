using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Starship : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private FactionAlignment faction;
    public FactionAlignment Faction
    {
        get { return faction; }
        set { faction = value; }
    }

    [SerializeField]
    private Enums.StarshipType starshipType;
    public Enums.StarshipType StarshipType
    {
        get { return starshipType; }
        private set { starshipType = value; }
    }

    [SerializeField]
    private EngineComponent engineComponent;
    public EngineComponent EngineComponent
    {
        get { return engineComponent; }
        private set { engineComponent = value; }
    }
    [SerializeField]
    private HullComponent hullComponent;
    public HullComponent HullComponent
    {
        get { return hullComponent; }
        private set { hullComponent = value; }
    }

    [SerializeField]
    private bool dead;
    public bool Dead
    {
        get { return dead; }
        private set { dead = value; }
    }
    #endregion

    #region Events and Handlers
    public event Action<Starship> removed;
    public UnityEvent OnStarshipDeath;
    #endregion

    #region Monobehaviour
    private void Awake()
    {
        faction = GetComponent<Faction>().FactionAlignment;
    }

    private void OnEnable()
    {

    }
    private void Start()
    {
        SetUp();
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {

    }
    private void OnDisable()
    {

    }
    private void OnDestroy()
    {

    }
    #endregion

    private void SetUp()
    {
        //faction = GetComponent<Faction>().FactionAlignment;
        hullComponent = GetComponentInChildren<HullComponent>();
        if (hullComponent)
        {
            hullComponent.Faction = faction;
            hullComponent.DamageComponent.OnDead.AddListener(StarshipDeath);
        }
        engineComponent = GetComponentInChildren<EngineComponent>();
    }

    private void StarshipDeath()
    {
        dead = true;
        if (removed != null)
        {
            removed(this);
        }
        hullComponent.DamageComponent.OnDead.RemoveListener(StarshipDeath);
        StartCoroutine("DeathSequence");
    } 

    IEnumerator DeathSequence()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
