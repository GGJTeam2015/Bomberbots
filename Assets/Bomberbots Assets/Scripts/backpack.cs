using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class backpack : MonoBehaviour {

    // Do not forget to add this to the player!

	public List<string> itemTags = new List<string>(5);
	public List<int> itemCounts = new List<int>(5);

	// Use this for initialization
	void Start () {


	}

	// Add item to backpack
	// If backpack already has that item, increase its count
	public void addItem(string tag)
	{
		// Backpack has the item
		if (itemTags.Exists(x => x == tag))
		{
			int idx = itemTags.FindIndex(x => x == tag);
			itemCounts[idx]++;
		}

		// Backpack has not the item
		else
		{
			itemTags.Add(tag);
			itemCounts.Add(1);
		}
	}

	// Just remove one of them
	public void removeItem(string tag)
	{
		// Backpack has the item
		if (itemTags.Exists(x => x == tag))
		{
			int idx = itemTags.FindIndex(x => x == tag);
			itemCounts[idx]--;

			if (itemCounts[idx] <= 0)
			{
				destroyItem(tag);
			}
		}
	}

	// Loose all of those items
	public void destroyItem(string tag)
	{
		// Backpack has the item
		if (itemTags.Exists(x => x == tag))
		{
			int idx = itemTags.FindIndex(x => x == tag);
			itemTags.RemoveAt(idx);
			itemCounts.RemoveAt(idx);
		}
	}

	// Get all taks
	public List<string> getTags()
	{
		return itemTags;
	}

	// Get counts of a specified item
	public int getCount(string item)
	{
		// Backpack has the item
		if (itemTags.Exists(x => x == item))
		{
			int idx = itemTags.FindIndex(x => x == item);
			return itemCounts[idx];
		}

		else
		{
			return 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
