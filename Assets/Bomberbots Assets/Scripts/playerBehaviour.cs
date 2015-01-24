using UnityEngine;
using System.Collections;

public class playerBehaviour : MonoBehaviour {

	public void kill()
    {
        Debug.Log("It is dead...");
    }

    void OnTriggerEnter(Collider coll)
    {
        
        // If it is a object with property
        if (coll.GetComponent<properties>() != null)
        {
            // If it is an craft item
            if (coll.GetComponent<properties>().isItem())
            {

                // Add item to backpack
                string itemName = coll.GetComponent<properties>().itemName;


                Debug.Log(itemName);

                gameObject.GetComponent<backpack>().addItem(itemName);

                // Destroy item
                Destroy(coll.gameObject);
            }
        }
    }
    
    // Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
