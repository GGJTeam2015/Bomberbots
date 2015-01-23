using UnityEngine;
using System.Collections;

public class followObject : MonoBehaviour {

	public Transform objectToFollow;

    private Vector3 initialDistance = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {

        initialDistance.x = objectToFollow.transform.position.x - this.transform.position.x;
        initialDistance.y = objectToFollow.transform.position.y - this.transform.position.y;
        initialDistance.z = objectToFollow.transform.position.z - this.transform.position.z;
	
	}
	
	// Update is called once per frame
	void Update () {

        // Determine point to go
        Vector3 pointToGo = objectToFollow.transform.position - initialDistance;

        // Look at object
        this.transform.LookAt(objectToFollow);

        // Follow object
        float t =  Vector3.Distance(this.transform.position, pointToGo);
        this.transform.position = Vector3.Lerp(this.transform.position, pointToGo, t);
	
	}

    
}
