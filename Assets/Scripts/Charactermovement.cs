using UnityEngine;

public class Charactermovement : MonoBehaviour
{
    Vector2 Speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Speed = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //Varje frame ökar vektorer med Speed
        transform.Translate(Speed * Time.deltaTime);
        KeyboardController();
        


    }

    void KeyboardController()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Speed.x = 2;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Speed.x = -2;
        }

        else if (Input.GetKey(KeyCode.UpArrow))
        {
            Speed.y = 2;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Speed.y = -2;
        }



        else
        {
            Speed.x = 0;
            Speed.y = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D c){
        Debug.Log("Rip");
    }
}
