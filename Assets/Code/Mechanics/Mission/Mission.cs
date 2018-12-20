using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Mission : ScriptableObject
{
    public abstract void StartMission(GameObject obj);
    public abstract bool MissionStatus(GameObject obj);
}
