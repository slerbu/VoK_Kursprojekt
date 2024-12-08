using UnityEngine;

public class GrabObjects : MonoBehaviour
{
    [SerializeField]
    private Transform grabPoint;  

    [SerializeField]
    private Transform rayPoint;  

    [SerializeField]
    private float rayDistance;    

    private GameObject grabbedObject; 
    private int layerIndex;            
    private FixedJoint2D joint;       

    private void Start()
    {
        layerIndex = LayerMask.NameToLayer("objects");  
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            Debug.Log("Hit object: " + hitInfo.collider.gameObject.name);

            if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                Rigidbody2D rb = grabbedObject.GetComponent<Rigidbody2D>();

                if (rb != null)
                {
                    joint = grabbedObject.AddComponent<FixedJoint2D>();

                    joint.connectedBody = GetComponent<Rigidbody2D>();

                    joint.anchor = grabbedObject.transform.InverseTransformPoint(grabPoint.position);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (grabbedObject != null && joint != null)
                {
                    Destroy(joint);

                    grabbedObject = null;
                }
            }
        }

        Debug.DrawRay(rayPoint.position, rayPoint.right * rayDistance, Color.red);

        if (grabbedObject != null)
        {
            grabbedObject.transform.position = grabPoint.position;
        }
    }
}







