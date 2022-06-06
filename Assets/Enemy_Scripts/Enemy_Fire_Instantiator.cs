using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fire_Instantiator : MonoBehaviour
{
    GameObject temp;
    public GameObject enemyBullet;

    [SerializeField] float timeBetweenBullets;
    [SerializeField] float timeDecreaser;
    float maxTimeBetweenBullets;

    public Enemy_Health you;
    void Start()
    {
        maxTimeBetweenBullets = timeBetweenBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (you.enemyHealth > 0)
        {
            if (timeBetweenBullets > 0)
            {
                timeBetweenBullets -= timeDecreaser * Time.deltaTime;
            }

            if (timeBetweenBullets <= 0)
            {
                temp = Instantiate(enemyBullet, transform.position, transform.rotation);
                timeBetweenBullets = maxTimeBetweenBullets;

                Destroy(temp, 2f);
            }
        }
        
    }
}
