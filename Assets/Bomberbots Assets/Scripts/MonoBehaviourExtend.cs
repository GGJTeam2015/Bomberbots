using UnityEngine;

public class MonoBehaviourExtend : MonoBehaviour
{
    private Transform cachedTransform = null;
    private Rigidbody cachedRigidbody = null;

    public Transform CachedTransform
    {
        get { return cachedTransform ?? (cachedTransform = transform); }
    }

    public Rigidbody CachedRigidbody
    {
        get { return cachedRigidbody ?? (cachedRigidbody = rigidbody); }
    }
}
