using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceDepot : MonoBehaviour
{
    #region Fields and Properties
    [SerializeField]
    private Mothership mothership;

    public List<ResourceField> AvailableResourceFields;

    [SerializeField]
    private int resourceAmount;
    public int ResourceAmount
    {
        get { return resourceAmount; }
        set { resourceAmount = value; }
    }

    [SerializeField]
    private Transform dropPoint;
    public Transform DropPoint
    {
        get { return dropPoint; }
        set { dropPoint = value; }
    }

    #endregion
    #region Events

    #endregion

    #region Debug
    public Text textLabel;
    public Text resourceLabel;
    public Text factionLabel;
    #endregion


    #region Monobehaviour
    // Use this for initialization
    void Start()
    {
        mothership.GetComponentInParent<Mothership>();
        mothership.resourceFields = FindObjectsOfType<ResourceField>();
        AvailableResourceFields = new List<ResourceField>();

        for (int i = 0; i < mothership.resourceFields.Length; i++)
        {
            //mothership.resourceFields[i].OnCapture.AddListener(OnFieldCapture);

            if (mothership.resourceFields[i].FactionAlignment == mothership.FactionAlignment)
                AddToAvailable(mothership.resourceFields[i]);
        }       
    }

    // Update is called once per frame
    void Update()
    {
        resourceLabel.text = resourceAmount.ToString();
    }
    public ResourceField RequestFieldAssignment()
    {
        if (AvailableResourceFields.Count > 0)
        {
            ResourceField lessWorkedField = AvailableResourceFields[0];
            for (int i = 1; i < AvailableResourceFields.Count; i++)
            {
                if (AvailableResourceFields[i].assignmentCount < lessWorkedField.assignmentCount)
                    lessWorkedField = AvailableResourceFields[i];
            }
            return lessWorkedField;         
        }
        return null;

    }
    public Vector3 ResourceLocation(ResourceField resourceField)
    {
        if (resourceField.AvailablePacks.Count > 0)
            return resourceField.AvailablePacks[0].transform.position;
        return DropPoint.position;
    }
    public void OnFieldCapture(ResourceField resource)
    {
        if (resource.FactionAlignment == mothership.FactionAlignment)
            AddToAvailable(resource);
        else
            RemoveFromAvailable(resource);
    }
    public void AddToAvailable(ResourceField field)
    {
        if (!AvailableResourceFields.Contains(field))
            AvailableResourceFields.Add(field);
    }
    public void RemoveFromAvailable(ResourceField field)
    {
        if (AvailableResourceFields.Contains(field))
            AvailableResourceFields.Remove(field);
    }
    #endregion

}
