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
    private float wallJumpTime = 1;
    public int bottomBound = -4;
    private SpriteRenderer sr;

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
        scoreText.text = "Spores: " + score;
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

        if(Input.GetKeyDown(KeyCode.Space) && !isGrounded && isWalled)
        {
            isWalled = false;
            wallJumpTime = wallJumpTime;

            rb.AddForce(Vector2.up * (jumpForce + 5), ForceMode2D.Impulse);
            wallJumpTime -= 1;

            if (wallJumpTime <= 0)
            {
                isWalled = true;
            }
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
