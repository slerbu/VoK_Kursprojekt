using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public Transform planet;  
    public float gravitationalConstant = 0.1f;  
    public float objectMass = 1f;  
    public float planetMass = 100f; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  
    }

    void FixedUpdate()
    {
        if (rb != null && planet != null)
        {
            
            Vector2 directionToPlanet = planet.position - transform.position;

            float distance = directionToPlanet.magnitude;

            if (distance > 0)
            {
                float forceMagnitude = gravitationalConstant * (objectMass * planetMass) / (distance * distance);

                Vector2 forceDirection = directionToPlanet.normalized;

                rb.AddForce(forceDirection * forceMagnitude);
            }
        }
    }
}


