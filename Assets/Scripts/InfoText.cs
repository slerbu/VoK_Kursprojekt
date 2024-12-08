using UnityEngine;
public class TextMeshExample : MonoBehaviour
{
    TextMesh textMesh;
    GameObject Asteroid;
    GameObject Sling;

    void Start()
    {
        // Get the TextMesh component attached to this GameObject
        textMesh = GetComponent<TextMesh>();
        
        
        if (textMesh != null)
        {
            // Set the text
            textMesh.text = "Dra på asteroiden med musen";
            Debug.Log("Textmesh finns");
        }
        else
        {
            Debug.LogError("error ingen textmesh");
        }

        Asteroid = GameObject.Find("Asteroid");
        Sling = GameObject.Find("Sling");
    }

    void Update()
    {
         if (Input.GetKey(KeyCode.Mouse0)){
 
            float distance = Vector2.Distance(Asteroid.transform.position, Sling.transform.position);
            Vector2 direction = (Sling.transform.position - Asteroid.transform.position).normalized;
            Vector2 force = direction * distance*60;

            float angleInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            textMesh.text = $"Force: {Mathf.RoundToInt(force.magnitude)} Angle: {Mathf.RoundToInt(angleInDegrees)}";
            //Debug.Log("klick");
            
            }

        if (Input.GetKeyUp(KeyCode.Mouse0)){
            textMesh.text = "";
        }

        
    }
    
}
