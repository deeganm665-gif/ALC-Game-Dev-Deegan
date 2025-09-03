using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player_move : MonoBehaviour
{
   public float speed;
    public float rotspeed;
    public float hInput;
    public float vInput;
    public float jInput;
    public float jumpforce;
    public Rigidbody playerRB;

    void Update()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        jInput = Input.GetAxis("Jump");

        transform.Rotate(Vector3.up, hInput * rotspeed * Time.deltaTime); //Move vehicle left and right
        transform.Translate(Vector3.forward * vInput * speed * Time.deltaTime); //Move vehicle forward and back
        transform.Translate(Vector3.up * jInput * jumpforce * Time.deltaTime); //Scuffed jump

    }
}
