using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourceCollector : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private Starship starship;
    public Starship Starship
    {
        get { return starship; }
        private set { starship = value; }
    }
    [SerializeField]
    private ResourcePack currentResource;
    public ResourcePack CurrentResource
    {
        get { return currentResource; }
        set { currentResource = value; }
    }
    [SerializeField]
    private bool hasPackage;
    public bool HasPackage
    {
        get { return hasPackage; }
        set { hasPackage = value; }
    }
    #endregion

    #region Events

    #endregion

    #region Monobehaviour
    private void Start()
    {
        starship = GetComponent<Starship>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (hasPackage || starship.Dead)        
            return;
        
        if (!other.tag.Equals("Resource"))
            return;
        try
        {
            ResourcePack resourcePack = other.GetComponent<ResourcePack>();
            if(!resourcePack.PackageClaimed)
                PickUpPackage(resourcePack);
        }
        catch (System.NullReferenceException)
        {
            Debug.Log(gameObject.name + " Resource Collector Error");
        }

    }
    #endregion

    public void PickUpPackage(ResourcePack resourcePack)
    {
        hasPackage = true;
        resourcePack.TakeClaim(this);
        currentResource = resourcePack;
        resourcePack.PackageClaimed = true;
        starship.removed += HandleDeath;
    }
    public void ReleasePackage()
    {
        hasPackage = false;
        CurrentResource.ReturnResourcePack();
        CurrentResource = null;
        starship.removed -= HandleDeath;
    }
    private void HandleDeath(Starship starship)
    {
        ReleasePackage();
    }
}
