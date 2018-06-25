using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    protected Joystick joystick;
    protected Joybutton joyButton;

    protected bool jump;

	// Use this for initialization
	void Start () {
        joystick = FindObjectOfType<Joystick>();
        joyButton = FindObjectOfType<Joybutton>();
	}
	
	// Update is called once per frame
	void Update () {

        var rigidbody = GetComponent<Rigidbody>();

        rigidbody.velocity = new Vector3(joystick.Horizontal * 100f + 
            Input.GetAxis("Horizontal") * 100f,
            rigidbody.velocity.y, joystick.Vertical * 100f + 
            Input.GetAxis("Vertical") * 100f);


        if(!jump && (joyButton.Pressed || Input.GetButton("Fire2")))
        {
            jump = true;
            rigidbody.velocity += Vector3.up * 100f;
        }

        if(jump && !joyButton.Pressed || Input.GetButton("Fire2"))
        {
            jump = false;
        }
	}
}
