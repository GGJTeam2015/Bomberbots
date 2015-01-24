using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviourExtend
{
    [SerializeField] private float chaseRange = 10.0f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawWireSphere(CachedTransform.position, chaseRange);
    }
}
