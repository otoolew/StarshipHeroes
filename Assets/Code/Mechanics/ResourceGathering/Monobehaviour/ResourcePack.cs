using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResourcePack : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private Vector3 spawnOrigin;
    public Vector3 SpawnOrigin
    {
        get { return spawnOrigin; }
        private set { spawnOrigin = value; }
    }
    [SerializeField]
    private int resourceAmount;
    public int ResourceAmount
    {
        get { return resourceAmount; }
        set { resourceAmount = value; }
    }
    [SerializeField]
    private bool packageClaimed;
    public bool PackageClaimed
    {
        get { return packageClaimed; }
        set { packageClaimed = value; }
    }
    [SerializeField]
    private ResourceCollector claimingCollector;
    public ResourceCollector ClaimingCollector
    {
        get { return claimingCollector; }
        private set { claimingCollector = value; }
    }
    #endregion
    public event Action<ResourcePack> onTaken;
    public event Action<ResourcePack> onReleased;

    // Use this for initialization
    private void OnEnable()
    {
        spawnOrigin = transform.position;
        
    }
    void Start()
    {

    }
    private void Update()
    {
        if (claimingCollector != null)
            transform.position = claimingCollector.transform.position;
    }
    private void OnDisable()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Depot"))
            return;
        try
        {
            other.GetComponent<ResourceDepot>().ResourceAmount += resourceAmount;
            claimingCollector.ReleasePackage();
        }
        catch (System.NullReferenceException)
        {
            Debug.Log(gameObject.name + "  try catch");
        }
    }
    public void TakeClaim(ResourceCollector resourceCollector)
    {
        claimingCollector = resourceCollector;
        onTaken.Invoke(this);
    }
    public void ReturnResourcePack()
    {
        claimingCollector = null;
        packageClaimed = false;
        transform.parent = null;
        transform.position = spawnOrigin;
        onReleased.Invoke(this);
    }
}
