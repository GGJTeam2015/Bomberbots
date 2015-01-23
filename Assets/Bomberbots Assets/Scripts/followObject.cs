using UnityEngine;
using System.Collections;

public class followObject : MonoBehaviour {

	public Transform objectToFollow;
    public float smoothness;

    private Vector3 initialDistance = new Vector3(0.0f, 0.0f, 0.0f);

	// Use this for initialization
	void Start () {

        initialDistance = objectToFollow.transform.position - this.transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {

        // Determine point to go
        Vector3 pointToGo = objectToFollow.transform.position - initialDistance;

        // Look at object
        this.transform.LookAt(objectToFollow);

        // Follow object
        float t =  Vector3.Distance(this.transform.position, pointToGo) / smoothness;
        this.transform.position = Vector3.Lerp(this.transform.position, pointToGo, t);

	}

    
}
