using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    
    private float moveHorizontal;
    private float moveVertical;
    private Vector3 movement;
    private Vector3 angleVelocity;
    
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody>();    
        //rb.constraints = RigidbodyConstraints.FreezePositionY;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed);

        if ( rb.velocity.magnitude > 0.01f ){
            Vector3 vector =  new Vector3(rb.velocity.x, 0, rb.velocity.z);
            transform.rotation  = Quaternion.LookRotation(vector, Vector3.up);
        }

        //angleVelocity = new Vector3(0.0f, moveHorizontal, 0.0f);
        

        //Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.deltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);

    }
}
