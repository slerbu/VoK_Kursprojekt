using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;  // The point where the object will be held.

    [SerializeField]
    private Transform rayPoint;   // The point from which the ray is cast.

    [SerializeField]
    private float rayDistance;    // The distance the ray will check.

    private GameObject grabbedObject;  // The currently grabbed object.
    private int layerIndex;            // Layer for "objects"
    private FixedJoint2D joint;        // The FixedJoint2D component for attaching the object.

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("objects");  // Assign the layer for objects.
    }

    void Update()
    {
        // Cast a ray from rayPoint position in the direction of the object.
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        // Check if the ray hits a valid object on the specified layer.
        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);

            // If the space key is pressed and no object is grabbed, grab the object.
            if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    // Create and attach the FixedJoint2D component.
                    joint = grabbedObject.AddComponent<FixedJoint2D>();

                    // Set the joint's connected body to the player's Rigidbody2D.
                    joint.connectedBody = GetComponent<Rigidbody2D>();

                    // Optionally, set the joint's anchor to the grab point.
                    joint.anchor = grabbedObject.transform.InverseTransformPoint(grabPoint.position);
                }
            }
            // If space key is pressed again, release the object.
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grabbedObject != null && joint != null)
                {
                    // Destroy the FixedJoint2D when the object is released.
                    Destroy(joint);

                    // Reset the grabbed object reference.
                    grabbedObject = null;
                }
            }
        }

        // Visualize the ray in the Scene view (for debugging).
        Debug.DrawRay(rayPoint.position, rayPoint.right * rayDistance, Color.red);

        // If there is a grabbed object, update its position to follow the grab point.
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = grabPoint.position;
        }
    }
}







