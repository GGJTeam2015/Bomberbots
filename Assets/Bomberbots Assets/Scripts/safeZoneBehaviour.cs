using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class safeZoneBehaviour : MonoBehaviour {

	// Do not forget to add this to safe zone

    public GameObject scItems;

	public int totalNumOfObj; // Parameters for random gen. goal
	private int[] numOfItemNeeded; // Counts for craft pieces


	private string[] craftPieceTags; // List for craft piece lists

	// Use this for initialization
	void Start () {

		// Get craft pieces
		craftPieceTags = scItems.GetComponent<spacecraftItems>().craftItems;

		// Initialize num of items needed
		numOfItemNeeded = new int[craftPieceTags.Length];
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
			int idx = UnityEngine.Random.Range(0, numOfItemNeeded.Length);
            int count = UnityEngine.Random.Range(0, totalNumOfObj - sumArray(numOfItemNeeded) + 1);
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

		for (int i = 0; i != numOfItemNeeded.Length; i++ )
		{
			if(numOfItemNeeded[i] > 0)
			{
				isCondReached = false;
			}
		}


		if (isCondReached)
		{
			Debug.Log("Goal is reached...");
		}

		return isCondReached;
	}

	// Check if craft objects entered the safe zone
	void OnTriggerEnter(Collider coll) 
	{
		string tagOfCollider = coll.gameObject.tag;

		if (tagOfCollider == "Player")
		{
			// Get script and tags
			backpack bpscript = coll.GetComponent<backpack>();
			List<string> tagsFromPlayer = bpscript.getTags();
			List<string> itemsToRemove = new List<string>(5);

			// Loose craft pieces
			foreach (string item in tagsFromPlayer)
			{
				if ( scItems.GetComponent<spacecraftItems>().doesExist(item) )
				{
					// Get item count
					int count = bpscript.getCount(item);

					// Decrement Count
					int idx = Array.IndexOf(craftPieceTags, item);
					numOfItemNeeded[idx] -= count;

					// Add to remove
					itemsToRemove.Add(item);

					// Check end condition
					checkEndCondition();
				}
			}

			// Destroy other object
			foreach (string item in itemsToRemove)
			{
				bpscript.destroyItem(item);
			}
			
		}
	}


	// ACCESSORS(GETTERS)
	
	public int[] getNumOfPiecesNeeded()
	{
		return numOfItemNeeded;
	}

	
}
