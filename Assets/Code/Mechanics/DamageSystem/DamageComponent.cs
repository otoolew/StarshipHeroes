using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class DamageComponent : MonoBehaviour {
    [SerializeField]
    private FactionAlignment faction;
    public FactionAlignment Faction
    {
        get { return faction; }
        set { faction = value; }
    }
    public int healthPoints;
    public UnityEvent OnDead;
   // public GameObject deathAnimation;
    // Use this for initialization
    void Start ()
    {
        //deathAnimation.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ApplyDamage(int amount)
    {
        healthPoints -= amount;
        if (healthPoints <= 0)
        {
            OnDead.Invoke();
            //deathAnimation.SetActive(true);
        }   
    }
}
