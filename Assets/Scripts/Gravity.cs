using UnityEngine;

public class CustomGravity : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public Transform planet;  // Reference to the planet (the object causing gravity)
    public float gravitationalConstant = 0.1f;  // Controls the strength of gravity (adjust as needed)
    public float playerMass = 1f;  // Mass of the player
    public float planetMass = 100f;  // Mass of the planet (gravity source)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component for applying forces
    }

    void FixedUpdate()
    {
        if (rb != null && planet != null)
        {
            // Calculate the vector from the player to the planet
            Vector2 directionToPlanet = planet.position - transform.position;

            // Calculate the distance between the player and the planet
            float distance = directionToPlanet.magnitude;

            // Ensure the distance is not zero to avoid division by zero
            if (distance > 0)
            {
                // Calculate the gravitational force using Newton's law of gravitation
                float forceMagnitude = gravitationalConstant * (playerMass * planetMass) / (distance * distance);

                // Normalize the direction to get a unit vector (this gives the direction of the force)
                Vector2 forceDirection = directionToPlanet.normalized;

                // Apply the gravitational force to the player's Rigidbody2D
                rb.AddForce(forceDirection * forceMagnitude);
            }
        }
    }
}


