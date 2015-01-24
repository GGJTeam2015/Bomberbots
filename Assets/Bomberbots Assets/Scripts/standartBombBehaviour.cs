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
    public List<string> objTagsToDamage = new List<string>(5);
    

    private float timeToExplode;
    private bool isActivated;

	// Use this for initialization
	void Start () {

        isActivated = false;
        timeToExplode = 100.0f;
	
	}

    public void activate()
    {
        // Get all objects to damage
        List<GameObject> gosToDamage = getAllDamageObjects();

        // Deal damage if in range
        foreach (GameObject go in gosToDamage)
        {
            if (Vector3.Distance(this.transform.position, go.transform.position) < radius)
            {
                go.GetComponent<healthProperty>().damage(damageAmount);
            }
        }

        // Destroy this bomb
        Destroy(this.gameObject);
    }

    private List<GameObject> getAllDamageObjects()
    {
        List<GameObject> allGameObjects = new List<GameObject>(15);

        foreach (string tag in objTagsToDamage)
        {
            GameObject[] taggos = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject go in taggos)
            {
                allGameObjects.Add(go);
            }
        }

        return allGameObjects;
    }

    public void trigger()
    { isActivated = true; timeToExplode = secForExplode; }

	// Update is called once per frame
	void Update () {

        // Countdown if activated
        if (isActivated)
        {
            timeToExplode -= Time.deltaTime;

            Debug.Log("Time: " + timeToExplode);
        }

        // If it is time to explode
        if (timeToExplode < 0.0f)
        {
            activate();
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            trigger();
            Debug.Log("Triggered");
        }
	}
}
