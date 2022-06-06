using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public int frames;
    public bool capFrames;

    public GameObject pause;
    public GameObject gameOver;
    public Text power;
    bool paused;

    PlayerHealth health;
    bool death;
    Bullet_Physics bullet;
    Level_Finished level;
    
    void Start()
    {
        if (capFrames == true)
        {
            Application.targetFrameRate = frames;
        }
        paused = false;
        health = FindObjectOfType<PlayerHealth>();
        bullet = FindObjectOfType<Bullet_Physics>();
        level = FindObjectOfType<Level_Finished>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (level.levelFinished == true && Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(1);
        } else if (level.levelFinished == true && Input.GetButtonDown("Fire1"))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused == true)
        {
            pause.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            pause.SetActive(false);
            Time.timeScale = 1;
        }

        OnDeath();
        Retry();
        power.text = "Power: " + bullet.powerValue; 
    }

    void OnDeath()
    {
        if (health.playerHealth <= 0)
        {
            death = true;
        }

        if (death == true)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
        } else
        {
            gameOver.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void Retry()
    {
        if (death == true && Input.GetButtonDown("Submit"))
        {
            SceneManager.LoadScene(1);
        }
    }

}
