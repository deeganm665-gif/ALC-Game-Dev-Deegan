using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class particle_Del : MonoBehaviour
{
    public int timer;
    public GameObject gameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, timer);
    }

   
}
