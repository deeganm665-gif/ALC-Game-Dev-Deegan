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

    [Header("Score")]
    public int score;

    public Rigidbody2D rb;
    public TextMeshProUGUI scoreText;

    public GameObject wall;

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        float movInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(movInput * movespeed, rb.linearVelocity.y);
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
            Debug.Log("You should be Wall jumping!");
            // Calculate direction away from the reference object
            Vector2 direction = (Vector2)transform.position - (Vector2)wall.transform.position;

            // Normalize the direction to get a unit vector
            direction.Normalize();

            isWalled = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);
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
