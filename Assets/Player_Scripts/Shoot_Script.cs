using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Script : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;

    public float reload;
    public float cooldown;

    float maxReload;
    GameObject temp;
    void Start()
    {
        maxReload = reload;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            
            reload -= cooldown * Time.deltaTime;
            if (reload <= 0)
            {
                CrossGun();
                reload = maxReload;
            }
        }

        if (!Input.GetButton("Fire2"))
        {
            reload = 0;
        }
    }

    void CrossGun()
    {
        temp = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        Destroy(temp, 2f);
    }
}
