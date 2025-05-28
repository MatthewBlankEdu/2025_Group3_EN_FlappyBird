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
    public Animator anim;
    
    public Rigidbody2D rb2D;
    public float jumpForce;

    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    public AudioClip scoreSFX;
    
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
            
            anim.SetTrigger("FlapWings");
            AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        gameOver = true;
        gameOverPanel.SetActive(true);

        int currentHighscore = PlayerPrefs.GetInt("Highscore");

        if (currentHighscore < points)
        {
            currentHighscore = points;
            PlayerPrefs.SetInt("Highscore", currentHighscore);
        }

        gameOverPoints.text = points.ToString();
        highscorePoints.text = currentHighscore.ToString();
        
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        points++;
        currentsPoints.text = points.ToString();
        
        AudioSource.PlayClipAtPoint(scoreSFX, Camera.main.transform.position);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("FlappyBird");
    }
    
    public void ExitToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
