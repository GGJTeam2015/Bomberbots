using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class spacecraftItems : MonoBehaviour {

	// Space craft item enums
	public string[] craftItems;

	// Space craft prefabs
	public GameObject[] craftItemPrefabs;
	

	public GameObject getCraftItemPrefab(string name)
	{
		return craftItemPrefabs[getItemIdx(name)];
	}

	public int getItemIdx(string name)
	{ return Array.IndexOf(craftItems, name); }

	public bool doesExist(string item)
	{
		bool has = false;

		foreach (string str in craftItems)
		{
			if (string.Compare(str, item) == 0)
			{
				has = true;
			}
		}

		return has;
	}

}
