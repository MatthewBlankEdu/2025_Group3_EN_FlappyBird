using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public TextMeshProUGUI currentsPoints;
    public TextMeshProUGUI gameOverPoints;
    public TextMeshProUGUI highscorePoints;
    public GameObject gameOverPanel;
    
    public Rigidbody2D rb2D;
    public float jumpForce;

    public static bool hasStarted;    
    public static bool gameOver;

    private float originalGravityScale;
    private int points;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver = false;
        hasStarted = false;
        
        originalGravityScale = rb2D.gravityScale;
        rb2D.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true)
        {
            return;
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            if (hasStarted == false)
            {
                rb2D.gravityScale = originalGravityScale;
                hasStarted = true;
            }
            
            rb2D.linearVelocity = Vector2.zero;
            rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameOver = true;
        gameOverPanel.SetActive(true);
        
        gameOverPoints.text = points.ToString();
        highscorePoints.text = points.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        points++;
        currentsPoints.text = points.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
