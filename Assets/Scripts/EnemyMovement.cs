
using UnityEngine;

public class EnemyMovement: MonoBehaviour
{

    GameObject[] Clouds;
    GameObject Waypoint;
    GameObject[] Waypoints;
    int WaypointIndex; 
    
    float Speed = 0.002f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        
        Waypoint = GameObject.Find("Waypoint");

    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 Direction = Cloud.transform.position - transform.position;

        //Direction.Normalize();
        //transform.Translate(Direction*Speed)
        

        if (Vector2.Distance(transform.position, Waypoints[WaypointIndex].transform.position) < 1) {
            WaypointIndex = Random.Range(0,5);
        }
            


        //transform.position = Vector2.MoveTowards(transform.position, Waypoint.transform.position, Speed);
        transform.position = Vector2.MoveTowards(transform.position, Waypoints[WaypointIndex].transform.position, Speed);
        

        
        
    }
}
