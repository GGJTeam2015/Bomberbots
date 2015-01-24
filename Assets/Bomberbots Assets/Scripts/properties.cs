using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class properties : MonoBehaviour {

    public int startHealth = 100;
    public List<Tags> tags = new List<Tags>(5);
    public string itemName = "";

    private int health;

	// Use this for initialization
	void Start () {
        health = startHealth;
	}


    public bool isDestructable()
    {
        return tags.Exists(x => x == Tags.Destructable);
    }

    public bool isPlayer()
    {
        return tags.Exists(x => x == Tags.Player);
    }

    public bool isItem()
    {
        return tags.Exists(x => x == Tags.Item);
    }

    public void damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            if (tags.Exists(x => x == Tags.Box))
            {
                // Send destroy message to box
            }

            else if (tags.Exists(x => x == Tags.Item))
            {
                // Send destroy message to item
            }

            else if (tags.Exists(x => x == Tags.Player))
            {
                // Send destroy message to player
                this.GetComponent<playerBehaviour>().kill();
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public enum Tags {
        Box,
        Player,
        Item,
        Destructable
    };
}
