using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy_Script : MonoBehaviour
{
    PlayerHealth player;
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            player.playerHealth -= 1;
        }
    }
}
