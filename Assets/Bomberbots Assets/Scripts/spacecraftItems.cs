using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spacecraftItems : MonoBehaviour {

	// Space craft item enums
	static public string[] craftItems = new string[]
	{
		"Wrench",
		"Engine",
		"Thrusters",
		"Propellant",
		"Health Shield"
	};

    // Space craft prefabs

	public string[] getCraftItems()
	{ return craftItems; }

	// Use this for initialization
	void Start () {
	
	}

    static public bool doesExist(string item)
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
	
	// Update is called once per frame
	void Update () {
	
	}
}
