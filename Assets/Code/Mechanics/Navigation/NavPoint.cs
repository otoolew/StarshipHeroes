using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NavPoint
{
    [SerializeField]
    private Enums.NavStatus navStatus;
    public Enums.NavStatus NavStatus
    {
        get { return navStatus; }
        private set { navStatus = value; }
    }
    [SerializeField]
    private Vector3 destination;
    public Vector3 Destination
    {
        get { return destination; }
        private set { destination = value; }
    }

}
