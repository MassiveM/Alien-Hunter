using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Vector2 movement = new Vector2(0f, 0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlMovement();
    }

    void ControlMovement()
    {
        movement.x = 0f;
        movement.y = 0f;

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            movement.x = 1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            movement.x = -1f;
        }
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement.y = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            movement.y = -1f;
        }
    }

}
