using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float JumpForce; 
    public GameObject LoseScreenUI;

    public int score, hiScore;
    public Text scoreUI,hiScoreUI;
    public string HISCORE="HISCORE";

    private void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        hiScore=PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
    }

    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity= Vector2.up*JumpForce;
            AudioManager.singleton.playSound(0);
        }
    }
    void playerLose()
    {
        AudioManager.singleton.playSound(1);
        if (score>hiScore)
        {
            hiScore=score;
            PlayerPrefs.SetInt(HISCORE,hiScore);
        }

        hiScoreUI.text="Hiscore:"+ hiScore.ToString();
        LoseScreenUI.SetActive(true);
        Time.timeScale=0;
    }

     void addScore()
    {
        score++;
        scoreUI.text="Score:"+score.ToString();
        AudioManager.singleton.playSound(2);
    }

    public void RestartGame()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            playerLose();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            addScore();
        }
    }
}
