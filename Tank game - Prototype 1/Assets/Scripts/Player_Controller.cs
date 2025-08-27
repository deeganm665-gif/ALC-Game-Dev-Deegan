using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_Controller : MonoBehaviour
{
    public float speed;
    public float rotspeed;
    public float hInput;
    public float vInput;
    public float jumpforce;
    public Rigidbody playerRB;

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up, hInput * rotspeed * Time.deltaTime); //Move vehicle left and right
        transform.Translate(Vector3.forward * vInput * speed * Time.deltaTime); //Move vehicle forward and back
    }
}
