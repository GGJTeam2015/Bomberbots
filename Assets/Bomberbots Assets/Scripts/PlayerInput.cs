using UnityEngine;

public class PlayerInput : MonoBehaviourExtend
{
    [SerializeField]
    private float movementSpeed = 1;

    [SerializeField]
    private Vector3 direction = Vector3.zero;

	void Start () 
    {
	
	}
	
	void LateUpdate () 
    {
        Vector3 velocity = direction.normalized * movementSpeed;
        velocity.y = CachedRigidbody.velocity.y;
        CachedRigidbody.velocity = velocity;

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            CachedTransform.rotation = Quaternion.LookRotation(direction, Vector3.up);
        }
	}
}
