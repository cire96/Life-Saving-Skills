﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Animator anim;
    
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private Vector3 angleVelocity;

    protected Joystick joystick;
    
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //rb.constraints = RigidbodyConstraints.FreezePositionY;
        joystick = FindObjectOfType<Joystick>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = joystick.Horizontal + Input.GetAxis("Horizontal");
        moveVertical = joystick.Vertical + Input.GetAxis("Vertical");
  
        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed*Time.deltaTime);

        if ( rb.velocity.magnitude > 0.01f ){
            Vector3 vector =  new Vector3(rb.velocity.x, 0, rb.velocity.z);
            transform.rotation  = Quaternion.LookRotation(vector, Vector3.up);
        }

        //angleVelocity = new Vector3(0.0f, moveHorizontal, 0.0f);
        

        //Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.deltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);

    }

    private void Update()
    {
        //Animation update
        anim.SetFloat("Movement", (Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical)));
    }




    // Animation footing methods (rpg animations are read only)
    public void FootR()
    {
    }

    public void FootL()
    {
    }
}