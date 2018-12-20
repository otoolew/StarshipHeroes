using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionAgent : MonoBehaviour
{
    public Stack<NavPoint> navPoints;
	// Use this for initialization
	void Start ()
    {
        navPoints = new Stack<NavPoint>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
