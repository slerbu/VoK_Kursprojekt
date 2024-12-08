using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;


public class Slingshot : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    bool isPressed;

    Rigidbody2D Asteroid;
    SpringJoint2D Sling;
    float maxStretch = 3f;
    //Vector2 force;
    Rigidbody2D SlingRb;
    Vector2 mousePosition;
   
    
    

    void Start() {
        Asteroid = GetComponent<Rigidbody2D>();
        Sling = GetComponent<SpringJoint2D>();
        SlingRb = Sling.connectedBody;
        

        
        
        
    

        
    }



    // Update is called once per frame
    void Update()
    {
        if(isPressed){
            Drag();
            //Debug.Log("pressed");
        }
        
        if (Input.GetKey(KeyCode.Mouse0)){
            isPressed = true;
            //Debug.Log("klick");
            Asteroid.bodyType = RigidbodyType2D.Kinematic;
            }
        if (Input.GetKeyUp(KeyCode.Mouse0)){
            isPressed = false;
            //Debug.Log("Swag");
            Asteroid.bodyType = RigidbodyType2D.Dynamic;
            Release();
        }
 
    }

   void Drag(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
        float distance = Vector2.Distance(mousePosition, SlingRb.position);
    

        if (distance > maxStretch) {
            Vector2 direction = (mousePosition - SlingRb.position).normalized;
            Asteroid.position = SlingRb.position + direction * maxStretch;

        }
        else{
            Asteroid.position = mousePosition;
        }
    }

   /* void OnMouseDown(){
        isPressed = true;
        Debug.Log("Mouse Down");
    }

    void OnMouseUp(){
        isPressed = false;
    }*/

    void Release() {
        
        float distance = Vector2.Distance(Asteroid.position, SlingRb.position);
        Vector2 direction = (SlingRb.position - Asteroid.position).normalized;
        Vector2 force = direction * distance*60;
        Asteroid.AddForce(force, ForceMode2D.Impulse);
        Sling.enabled = false;
        Debug.Log(force.magnitude);
        float angleInDegrees = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Debug.Log(angleInDegrees);
        
    }
    

}
