using UnityEngine;
using System.Collections;

public class healthProperty : MonoBehaviour {

    public int startHealth = 100; // Starting health of player

    public int health; // Current health of the player


    public void damage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            die();
        }
    }

    private void die()
    {
        Debug.Log("I died...");
    }

    public int getHealth()
    { return health; }

    // Use this for initialization
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
