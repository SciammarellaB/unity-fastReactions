using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charact : MonoBehaviour {

    public bool canJump; //Value set by Physics Linecast looking to the ground
    public bool background; //Used to change the background material color
    public bool gameOver; //Used to determine when the player missed the plataform and is falling
    public bool audioRepeat; // Used to make the audios to play only once

    public Transform groundDetect; //Used to make the player to jump only once

    public GameObject whitePlataform; //Used to set on and off the plataform when needed
    public GameObject blackPlataform; //Used to set on and off the plataform when needed
    public GameObject canvas1; //Used to appear the UI when game is running
    public GameObject canvas2; //Used to appear the UI when Game is over
    public GameObject gameOverBack; //Used to apper the UI text because of color

    public LayerMask groundLayer; //Used to determine the objects that can make the player to jump again

    public float jumpForce; //Select the force amount that is going to be used to make the player jump
    public float speed; //Used to select the speed of the player
    public float speedFactor; //Used to make the player to go faster acording to its point
    public float points; //Used to obtain points
   
    public Material backgroundMat;  //Used to change the background material color
    
    public Text pointText; //Used to show the points and to change the color
       
    Rigidbody2D rb2D; //Access to the rigidbody

    public AudioClip[] aClip; //Audios that are going to be played

	public string levelName;
    	
	void Start ()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        backgroundMat.color = Color.black;
        gameOver = false;
    }
	
	
	void Update ()
    {
        GameOver();

        Points();

        SpeedFac();

        Debug.Log(speed + speedFactor);

        Debug.DrawLine(gameObject.transform.position, groundDetect.position, Color.green); //Used to see the line that detects the ground

        if (gameOver == false)
        {
            canJump = Physics2D.Linecast(gameObject.transform.position, groundDetect.position, groundLayer); //Used to make the player jump again
            gameObject.transform.Translate(Vector2.right * (speed + speedFactor) * Time.deltaTime);
            BackGround();
            canvas1.SetActive(true);
            canvas2.SetActive(false);
            gameOverBack.SetActive(false);
        }

        else
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);
            gameOverBack.SetActive(true);
        }
        
    }

    public void Jump()
    {
        background = !background;

        if (canJump == true)
        {
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            
        }
    }

    void BackGround()
    {
        if(background == true)
        {
            backgroundMat.color = Color.white;
            pointText.color = Color.black;
            whitePlataform.SetActive(false);
            blackPlataform.SetActive(true);
        }

        else
        {
            backgroundMat.color = Color.black;
            pointText.color = Color.white;
            whitePlataform.SetActive(true);
            blackPlataform.SetActive(false);
        }
    }

    void GameOver()
    {
        if(transform.position.y < -7)
        {
            if(audioRepeat == false)
            {
                gameObject.GetComponent<AudioSource>().PlayOneShot(aClip[0]);
                audioRepeat = true;
            }
            gameOver = true;
            
        }
    }

    void Points()
    {
        if(canJump == true && gameOver == false)
        {
            points++;
            pointText.text = string.Format("Pontos: {0:0000}", points);
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.tag == "Black" || c.gameObject.tag == "White")
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(aClip[1]);
        }
    }

    void SpeedFac()
    {
        speedFactor = points / 1000;
    }

	public void Restart()
	{
		levelName = SceneManager.GetActiveScene ().name;
		SceneManager.LoadScene (levelName);
	}

    
}
