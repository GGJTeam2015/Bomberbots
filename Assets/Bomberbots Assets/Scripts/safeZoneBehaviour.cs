using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class safeZoneBehaviour : MonoBehaviour {

	// List for craft piece lists
    public List<string> craftPieceTags = new List<string>(5);

    // Parameters for random gen. goal
    public int totalNumOfObj;


    // Counts for craft pieces
    public int[] numOfItemNeeded;

	// Use this for initialization
	void Start () {

        // Initialize num of items needed
        numOfItemNeeded = new int[craftPieceTags.Count];
        for (int i = 1; i != numOfItemNeeded.Length; i++ )
        {
            numOfItemNeeded[i] = 0;
        }

        // Generate goals
        genGoals();
	}




    // Fill *numOfItemNeeded* for generating random goals
    void genGoals()
    {
        int counta = 0;

        while (true)
        {
            int idx = Random.Range(0, numOfItemNeeded.Length);
            int count = Random.Range(0, totalNumOfObj - sumArray(numOfItemNeeded) + 1);
            numOfItemNeeded[idx] += count;


            if (sumArray(numOfItemNeeded) >= totalNumOfObj || counta > 500)
            {
                break;
            }

            counta++;
        }
    }

	
	// Update is called once per frame
	void Update () {
	
	}

    int sumArray(int[] array)
    {
        int sum = 0;
        for(int i = 0; i != array.Length; i++)
        {
            sum += array[i];
        }

        return sum;
    }

    // Check if goal is reached!
    bool checkEndCondition()
    {
        bool isCondReached = true;

        for (int i = 1; i != numOfItemNeeded.Length; i++ )
        {
            if(numOfItemNeeded[i] > 0)
            {
                isCondReached = false;
            }
        }

        return isCondReached;
    }

    // Check if craft objects entered the safe zone
    void OnTriggerEnter(Collider coll) 
    {
        string tagOfCollider = coll.gameObject.tag;

        if (craftPieceTags.Exists(x => x == tagOfCollider))
        {
            // Increment Count
            int idx = craftPieceTags.FindIndex(x => x == tagOfCollider);
            numOfItemNeeded[idx]--;

            // Destroy other object
            // Destroy(coll.gameObject);

            // Check end condition
            checkEndCondition();
        }
    }


    // ACCESSORS(GETTERS)
    public List<string> getCraftPieceTags()
    {
        return craftPieceTags;
    }

    public int[] getNumOfPiecesNeeded()
    {
        return numOfItemNeeded;
    }

    
}
