using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
    public int enemyHealth;
    Collider2D col;
    SpriteRenderer spr;

    Bullet_Physics bullet;
    Movement player;
    
    void Start()
    {
        col = GetComponent<Collider2D>();
        spr = GetComponent<SpriteRenderer>();
        bullet = FindObjectOfType<Bullet_Physics>();
        player = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth <= 0)
        {
            spr.enabled = false;
            col.enabled = false;
            
            Destroy(gameObject, 3f);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet")
        {
            enemyHealth -= bullet.powerValue;
        }

         if (collision.gameObject.tag == "Player Bullet" && enemyHealth <= 0)
        {
            bullet.powerValue += 1;
        }

         if (collision.gameObject.tag == "Player" && player.isDashing == true && bullet.powerValue >= 3)
        {
            enemyHealth = 0;
        }
    }
}
