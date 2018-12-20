using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Missions/Neutralize Target")]
public class NeutralizeTarget : Mission
{
    //private NPCFighter fighter;

    public override bool MissionStatus(GameObject obj)
    {

        throw new System.NotImplementedException();
    }

    public override void StartMission(GameObject obj)
    {
        //fighter = obj.GetComponent<NPCFighter>();

    }
    private void TargetNeutralized(NPCFighter fighter)
    {

    }

}
