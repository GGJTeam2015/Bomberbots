using System;
using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviourExtend
{
    [SerializeField] private GameObject objectPrefab = null;

    [SerializeField] private int enemyCount = 5;

    [SerializeField] private float spawnInterval = 10.0f;

    [SerializeField] private float cooldown = 1.0f;

    private float currentTimeInterval = 0f;
    private float currentTimeCooldown = 0f;
    private int currentSpawnedObjects = 0;

    void Awake()
    {
        if (objectPrefab == null)
        {
            Debug.LogError("Object prefab is empty");
            enabled = false;
        }

    }

    void Update()
    {
        if (currentTimeInterval > spawnInterval)
        {
            if (currentSpawnedObjects < enemyCount)
            {
                if (currentTimeCooldown > cooldown)
                {
                    Instantiate(objectPrefab, CachedTransform.position, Quaternion.identity);
                    currentSpawnedObjects++;
                    currentTimeCooldown = 0;
                }
                else
                {
                    currentTimeCooldown += Time.deltaTime;
                }
            }
            else
            {
                currentSpawnedObjects = 0;
                currentTimeInterval = 0;
            }
        }
        else
        {
            currentTimeInterval += Time.deltaTime;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(CachedTransform.position, 0.5f);
    }
}
