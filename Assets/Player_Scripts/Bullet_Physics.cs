using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Physics : MonoBehaviour
{
    public float bulletSpeed;
    public int powerValue;
    void Start()
    {
        
    }

    private void Update()
    {
        if (powerValue >= 3)
        {
            powerValue = 3;
        }
    }
    void FixedUpdate()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Turning Point")
        {
            Destroy(gameObject);
        }
        
    }
}
