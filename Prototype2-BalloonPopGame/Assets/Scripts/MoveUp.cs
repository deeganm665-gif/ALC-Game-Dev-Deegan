using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MoveUp : MonoBehaviour
{
    public float speed;
    public float upperBound;
    private ScoreManager scoreManager;
    private Balloon balloon;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        balloon = GetComponent<Balloon>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

        if (transform.position.y >= upperBound)
        {
            scoreManager.DecreaseScoreText(balloon.scoreToGive / 2);
            Destroy(gameObject);
        }
    }
}
