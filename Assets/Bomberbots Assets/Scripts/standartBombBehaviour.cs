using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class standartBombBehaviour : MonoBehaviour {

	// Standart bomb is triggered as it is laid out.
	// Countdown is started when triggered. When coundown ends
	// It explodes and deals the damage to the characters and boxes
	// around.

	public int damageAmount = 10;
	public int radius = 5;
	public int secForExplode = 3;
 	
	private float timeToExplode;
	private bool isActivated;
	
	// Use this for initialization
	void Start () {
		isActivated = false;
		timeToExplode = 100.0f;
	}

    // Explode!
	public void activate()
	{

		// Get all objects to damage if in range
        List<GameObject> gos = getDestructablesWithinRange();

		// Deal damage
        foreach (GameObject go in gos)
        {
            go.GetComponent<properties>().damage(damageAmount);
        }

		// Destroy this bomb
		Destroy(this.gameObject);
	}

    private List<GameObject> getDestructablesWithinRange()
    {
        List<GameObject> gos = new List<GameObject>(5);
        
        Collider[] colls = Physics.OverlapSphere(this.transform.position, this.radius);

        foreach (Collider coll in colls)
        {
            if (coll.GetComponent<properties>() != null)
            {
                if (coll.gameObject.GetComponent<properties>().isDestructable())
                {
                    Debug.Log(coll.GetInstanceID());
                    gos.Add(coll.gameObject);
                }
            }

            
        }

        return gos;
    }

    // Trigger the bomb
	public void trigger()
	{ isActivated = true; timeToExplode = secForExplode; }

	// Update is called once per frame
	void Update () {

		// Countdown if activated
		if (isActivated)
		{
			timeToExplode -= Time.deltaTime;

            Debug.Log(timeToExplode);
		}

		// If it is time to explode
		if (timeToExplode < 0.0f)
		{
			activate();
		}

	}
}
