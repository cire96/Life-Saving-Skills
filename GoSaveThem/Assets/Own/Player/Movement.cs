using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public float speed;
    public GameObject HUD;
    public Rigidbody rb;
    public Animator anim;

    private BtnReact BtnReact;
    private float Freeze = 0.0f;
    private float moveHorizontal;
    private bool alive = true;
    private float moveVertical;
    private Vector3 movement;
    private Vector3 angleVelocity;
    private GameObject GoS;
    private Countdown countDown;

    protected Joystick joystick;
    
    // Start is called before the first frame update
    void Start()
    {
        BtnReact = HUD.GetComponent<BtnReact>();
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
        
        if (Freeze > 0){
            moveHorizontal = 0.0f;
            moveVertical = 0.0f;
            Freeze -= Time.deltaTime;
        }

        movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed*Time.deltaTime);

        if ( rb.velocity.magnitude > 0.01f ){
            Vector3 vector =  new Vector3(rb.velocity.x, 0, rb.velocity.z);
            transform.rotation  = Quaternion.LookRotation(vector, Vector3.up);
        }

        //angleVelocity = new Vector3(0.0f, moveHorizontal, 0.0f);
        if (!(Freeze > 0) && !alive)
        {
            GoS = HUD.transform.Find("GameOverLayer").gameObject;
            GameObject Feedback = GoS.transform.Find("Feedback").gameObject;
            Text txtField = Feedback.GetComponent<Text>();
            txtField.text = "Be aware of hazards!";
            //BtnReact.ShowGameOverLayer();

            //countDown = HUD.GetComponent<Countdown>();
            GameObject counter = HUD.transform.Find("countdownTxt").gameObject;
            //countDown.ResetTimeLeft();
            counter.GetComponent<Countdown>().ResetTimeLeft();
            //countDown.timeLeft = 0;
            BtnReact.ShowGameOverLayer();


        }
    }

        //Quaternion deltaRotation = Quaternion.Euler(angleVelocity * Time.deltaTime);
        //rb.MoveRotation(rb.rotation * deltaRotation);

    


    private void Update()
    {
        //Animation update
        anim.SetFloat("Movement", (Mathf.Abs(moveHorizontal) + Mathf.Abs(moveVertical)));
    }


    public void CrouchMovment(){
        anim.SetTrigger("crouchTrigger");
        Freeze = 2.5f;
    }

    public void TalkMovment(){
        anim.SetTrigger("TalkTrigger");
    }

    public void Die(){
        Debug.Log("U died");
        alive = false;
        //anim.SetTrigger("DieTrigger");
        Freeze = 2.5f;
  


    }

    // Animation footing methods (rpg animations are read only)
    public void FootR()
    {
    }

    public void FootL()
    {
    }
}
