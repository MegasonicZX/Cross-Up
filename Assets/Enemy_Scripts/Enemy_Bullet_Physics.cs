using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet_Physics : MonoBehaviour
{
    public float bulletSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
