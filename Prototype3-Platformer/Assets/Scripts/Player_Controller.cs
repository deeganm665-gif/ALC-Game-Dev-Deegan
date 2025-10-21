using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class Player_Controller : MonoBehaviour
{
    [Header("Player Settings")]
    public float movespeed;
    public float jumpForce;
    public bool isGrounded;
    public bool isWalled;
    public int bottomBound = -4;
    private SpriteRenderer sr;
    private Vector2 startPos;
    private Vector2 targetPos;
    private bool jumping;
    private float t;

    [Header("Score")]
    public int score;

    public Rigidbody2D rb;
    public TextMeshProUGUI scoreText;

    public GameObject wall;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        float movInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movInput * movespeed, rb.linearVelocity.y);
        if (movInput < 0)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (transform.position.y < bottomBound)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && isWalled == true)
        {
            startPos = transform.position;
            if (sr.flipX == true)
            {
                targetPos = new Vector2(transform.position.x + 1, transform.position.y + 3);
            }
            else
            {
                targetPos = new Vector2(transform.position.x - 1, transform.position.y + 3);
            }
            jumping = true;

        }
        if (jumping)
        {
            if (t < 1)
            {
                t += .5f * Time.deltaTime;
            }
            else
            {
                jumping = false;
            }

            transform.position = new Vector2(Mathf.Lerp(startPos, targetPos, t));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.GetContact(0).normal == Vector2.up)
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            isWalled = true;
            wall = collision.gameObject;
            Debug.Log("Touching wall");
        }
        else
        {
            isWalled = false;
        }

    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
