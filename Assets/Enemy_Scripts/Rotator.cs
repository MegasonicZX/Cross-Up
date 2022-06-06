using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotSpeed;
    GameObject[] firePoints;
    int firePointIndex;

    //public GameObject enemyBullet;
    GameObject temp;

    /*[SerializeField] float timeBetweenBullets;
    [SerializeField] float timeDecreaser;
    float maxTimeBetweenBullets;*/
    Enemy_Health you;
    void Start()
    {
        //maxTimeBetweenBullets = timeBetweenBullets;
        //firePoints = GameObject.FindGameObjectsWithTag("Enemy FirePoint");
        you = GetComponent<Enemy_Health>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if (you.enemyHealth > 0)
        {
            transform.Rotate(0, 0, rotSpeed * Time.deltaTime);

           /* if (timeBetweenBullets > 0)
            {
                timeBetweenBullets -= timeDecreaser * Time.deltaTime;
            }

            if (timeBetweenBullets <= 0)
            {
                FireOnAllSides();
                timeBetweenBullets = maxTimeBetweenBullets;
            }*/

        }
        
    }

    void FireOnAllSides()
    {
        /*for (firePointIndex = 0; firePointIndex < firePoints.Length; firePointIndex++)
        {
            temp = Instantiate(enemyBullet, firePoints[firePointIndex].transform.position, firePoints[firePointIndex].transform.rotation);
            Destroy(temp, 1.5f);
        }*/
    }
}
