using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Finished : MonoBehaviour
{

    public GameObject congratulations;
    public bool levelFinished;

    void Start()
    {
        levelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelFinished == true)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            congratulations.SetActive(true);
            
            levelFinished = true;
        }
    }
}
