using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpanManager : MonoBehaviour
{
    public GameObject[] balloonPreFab; //Array to store balloons that will be spawned
    public float startDelay = 0.5f; //how long before balloons start spawing
    public float spawnInterval = 1.5f; //time inbetween balloons spawning
    public float xRange = 10.0f;
    public float yPos; //set as positve, where its used will automaticly turn to negative

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnRandomBalloon", startDelay, spawnInterval);
    }

    void spawnRandomBalloon()
    {
        //get Random x position
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), -yPos, 0);
        //pick a random balloon from the array to spawn
        int balloonIndex = Random.Range(0, balloonPreFab.Length);
        //Spawn the balloon at the x position
        Instantiate(balloonPreFab[balloonIndex], spawnPos, balloonPreFab[balloonIndex].transform.rotation);
    }
}
