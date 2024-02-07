using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float jetSpeed = 15f;
    public float jetSpeedMultiplier = .3f;
    private bool isGrounded = true;
    public Vector2 maxVelocity = new Vector2(3f, 5f);

    private Controller control;

    private Animator anim;

    private Rigidbody2D myBody;
    
    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<Controller>();
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        isGrounded = (Mathf.Abs(myBody.velocity.y) < .0001f) ? true : false;
        
        if (control.movement.x != 0)
        {
            if (Mathf.Abs(myBody.velocity.x) < maxVelocity.x)
            {
                float velocityX = control.movement.x * (isGrounded ? speed : speed * jetSpeedMultiplier);
                myBody.AddForce(new Vector2(velocityX, 0f));
                anim.SetInteger("AnimState", 1);
            }
        }
        else
        {
            anim.SetInteger("AnimState", 0);
        }

        if (control.movement.y > 0)
        {
            if (Mathf.Abs(myBody.velocity.y) < maxVelocity.y)
            {
                myBody.AddForce(new Vector2(0f, jetSpeed));
            }
            anim.SetBool("JetTrigger", true);
        }
        else if (Mathf.Abs(myBody.velocity.y) > 0f)
        {
            anim.SetInteger("AnimState", 2);
            anim.SetBool("JetTrigger", false);
        }

    }
}
