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
                    // Make the object kinematic to prevent physics from affecting it.
                    rb.isKinematic = true;

                    // Set the object’s position to the grab point.
                    grabbedObject.transform.position = grabPoint.position;

                    // Set the object as a child of the grab point so it follows the player.
                    grabbedObject.transform.SetParent(grabPoint);
                }
            }
            // If space key is pressed again, release the object.
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grabbedObject != null)
                {
                    Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();

                    // Restore the object’s physics behavior.
                    rb.isKinematic = false;

                    // Detach the object from the parent (stop following the grab point).
                    grabbedObject.transform.SetParent(null);

                    // Reset the grabbed object reference.
                    grabbedObject = null;
                }
            }
        }

        // Visualize the ray in the Scene view (for debugging).
        Debug.DrawRay(rayPoint.position, transform.right * rayDistance, Color.red);

        // If there is a grabbed object, update its position to follow the grab point.
        if (grabbedObject != null)
        {
            grabbedObject.transform.position = grabPoint.position;  // Keep it at the grab point.
        }
    }
}





