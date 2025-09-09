using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Balloon : MonoBehaviour
{
    public int clickToPop;
    public float scaleToIncrease = 0.1f;
    public int scoreToGive;
    private ScoreManager scoreManager;
    public GameObject popEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    void OnMouseDown()
    {
        clickToPop -= 1;
        transform.localScale += Vector3.one * scaleToIncrease;

        if (clickToPop == 0)
        {
            //scoreManager.IncreaseScoreText(scoreToGive);
            //Instantiate(popEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
