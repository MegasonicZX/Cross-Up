using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    string ENEMY_BULLET = "Enemy Bullet";

    public bool isDamaged;

    public float lengthOfStun;
    float maxLengthOfStun;
    [SerializeField] float timeTilRecovery;
    public SpriteRenderer spr;

    public bool invincibility;
    [SerializeField] float invincibleTime;
    float maxInvincibleTime;
    [SerializeField] float invincibilityDetractor;

    GameObject[] hearts;
    int heartsIndex;
    Movement player;
    Bullet_Physics bullet;

    void Start()
    {
        maxLengthOfStun = lengthOfStun;
        isDamaged = false;

        maxInvincibleTime = invincibleTime;

        hearts = GameObject.FindGameObjectsWithTag("Hearts");
        heartsIndex = hearts.Length - 1;
        player = FindObjectOfType<Movement>();
        bullet = FindObjectOfType<Bullet_Physics>();
    }

    
    void Update()
    {
        if (isDamaged == true)
        {
            spr.color = Color.red;
            lengthOfStun -= timeTilRecovery * Time.deltaTime;
        }

        if (lengthOfStun <= 0)
        {
            isDamaged = false;
            lengthOfStun = maxLengthOfStun;
            spr.color = Color.white;
            invincibility = true;
        }

       

        if (invincibility == true)
        {
            invincibleTime -= invincibilityDetractor * Time.deltaTime;
            spr.color = Color.blue;
        }

        if (invincibleTime <= 0)
        {
            invincibility = false;
            invincibleTime = maxInvincibleTime;
            spr.color = Color.white;
        }

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ENEMY_BULLET && invincibility == false && isDamaged == false && player.isDashing == false)
        {
            if (bullet.powerValue > 1)
            {
                bullet.powerValue -= 1;
            }
            playerHealth -= 1;
            Destroy(hearts[heartsIndex]);
            heartsIndex -= 1;
            isDamaged = true;
        }

        

        if (collision.gameObject.tag == "Death")
        {
            playerHealth = 0;
        }
    }
}
