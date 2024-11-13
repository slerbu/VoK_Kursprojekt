
using UnityEngine;

public class EnemyMovement: MonoBehaviour
{

    GameObject[] Clouds;
    GameObject Cloud;
    
    float Speed = 0.01f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Clouds = GameObject.FindGameObjectsWithTag("Cloud");
        
        Cloud = GameObject.Find("Cloud");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 Direction = Cloud.transform.position - transform.position;

        //Direction.Normalize();
        //transform.Translate(Direction*Speed)

        
            


        transform.position = Vector2.MoveTowards(transform.position, Cloud.transform.position, Speed);

        
        
    }
}
